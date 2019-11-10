using System.Linq;
using System.Collections.Generic;

using Forum.Data;
using Forum.Models;
using Forum.App.UserInterface.ViewModels;

namespace Forum.App.Services
{
    public static class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            Category category = forumData.Categories.First(c => c.Id == categoryId);

            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();

            ICollection<int> replyIds = forumData
                .Posts
                .First(post => post.Id == postId)
                .ReplyIds;

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (int replyId in replyIds)
            {
                Reply reply = forumData.Replies.First(r => r.Id == replyId);

                ReplyViewModel replyViewModel = new ReplyViewModel(reply);

                replies.Add(replyViewModel);
            }

            return replies;
        }

        public static string[] GetAllGategoryNames()
        {
            string[] allCategoryNames = new ForumData()
                .Categories
                .Select(category => category.Name)
                .ToArray();

            return allCategoryNames;
        }

        internal static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            IEnumerable<Post> posts = forumData.Posts
                .Where(post => post.CategoryId == categoryId);
            
            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            PostViewModel postViewModel = new PostViewModel(post);

            return postViewModel;
        }

        private static Category EnsureCategory(PostViewModel postViewModel, ForumData forumdata)
        {
            string categoryName = postViewModel.Category;

            Category category = forumdata.Categories.Find(c => c.Name == categoryName);

            if (category == null)
            {
                //List<Category> categories = forumdata.Categories;
                //int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                int categoryId = forumdata.Categories.Count + 1;

                category = new Category(categoryId, categoryName);

                forumdata.Categories.Add(category);
            }

            return category;
        }

        public static bool TrySavePost(PostViewModel postViewModel)
        {
            bool isCategoryEmpty = string.IsNullOrWhiteSpace(postViewModel.Category);
            bool isTitleEmpty = string.IsNullOrWhiteSpace(postViewModel.Title);
            bool isContentEmpty = !postViewModel.Content.Any();

            if (isCategoryEmpty || isTitleEmpty || isContentEmpty)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            Category category = EnsureCategory(postViewModel, forumData);

            //int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;
            int postId = forumData.Posts.Count + 1;

            User author = UserService.GetUser(postViewModel.Author, forumData);

            int authorId = author.Id;
            string content = string.Join(string.Empty, postViewModel.Content);

            Post post = new Post(postId, postViewModel.Title, content, category.Id, authorId);
            
            forumData.Posts.Add(post);
            author.PostIds.Add(postId);
            category.PostIds.Add(postId);
            
            forumData.SaveChanges();

            postViewModel.PostId = postId;

            return true;
        }

        public static bool TrySaveReply(ReplyViewModel replyViewModel, int postId)
        {
            if (!replyViewModel.Content.Any())
            {
                return false;
            }

            ForumData forumData = new ForumData();

            User author = UserService.GetUser(replyViewModel.Author, forumData);
            int replyId = forumData.Replies.Count + 1;
            string content = string.Join(string.Empty, replyViewModel.Content);

            Reply reply = new Reply(replyId, content, author.Id, postId);

            Post post = forumData.Posts.First(p => p.Id == postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            
            forumData.SaveChanges();

            return true;
        }
    }
}