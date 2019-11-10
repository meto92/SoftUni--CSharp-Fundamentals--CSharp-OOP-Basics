using Forum.Models;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Forum.Data
{
    public static class DataMapper
    {
        private const string DataPath = "../data/";
        private const string ConfigPath = "config.ini";
        private const string DefaultConfig = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DataPath);

            config = LoadConfig(DataPath + ConfigPath);
        }

        private static void EnsureConfigFile(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                File.WriteAllText(configFilePath, DefaultConfig);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);

            string[] lines = File.ReadAllLines(path);

            return lines;
        }

        private static Dictionary<string, string> LoadConfig(string configFilePath)
        {
            EnsureConfigFile(configFilePath);

            string[] contents = ReadLines(configFilePath);

            Dictionary<string, string> config = contents.
                Select(line => line.Split('='))
                .ToDictionary(t => t[0], t => $"{DataPath}{t[1]}");

            return config;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();

            string[] dataLines = ReadLines(config["categories"]);

            foreach (string line in dataLines)
            {
                string[] tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(tokens[0]);
                string name = tokens[1];
                int[] postIds = tokens[2]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Category category = new Category(id, name, postIds);

                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();

            foreach (Category category in categories)
            {
                object[] values =
                {
                    category.Id,
                    category.Name,
                    string.Join(",", category.PostIds)
                };

                string line = string.Join(";", values);

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();

            string[] dataLines = ReadLines(config["users"]);

            foreach (string line in dataLines)
            {
                string[] tokens = line.Split(';');

                int id = int.Parse(tokens[0]);
                string username = tokens[1];
                string password = tokens[2];
                int[] postIds = tokens[3]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                
                User user = new User(id, username, password, postIds);

                users.Add(user);
            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (User user in users)
            {
                object[] values =
                {
                    user.Id,
                    user.Username,
                    user.Password,
                    string.Join(",", user.PostIds)
                };
                
                string line = string.Join(";", values);

                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();

            string[] dataLines = ReadLines(config["posts"]);

            foreach (string line in dataLines)
            {
                string[] tokens = line.Split(';');

                int id = int.Parse(tokens[0]);
                string title = tokens[1];
                string content = tokens[2];
                int categoryId = int.Parse(tokens[3]);
                int authorId = int.Parse(tokens[4]);
                int[] replyIds = tokens[5]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Post post = new Post(id, title, content, categoryId, authorId, replyIds);

                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();

            foreach (Post post in posts)
            {
                object[] values =
                {
                    post.Id,
                    post.Title,
                    post.Content,
                    post.CategoryId,
                    post.AuthorId,
                    string.Join(",", post.ReplyIds)
                };

                string line = string.Join(";", values);

                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();

            string[] dataLines = ReadLines(config["replies"]);

            foreach (string line in dataLines)
            {
                string[] tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(tokens[0]);
                string content = tokens[1];
                int authorId = int.Parse(tokens[2]);
                int postId = int.Parse(tokens[3]);

                Reply reply = new Reply(id, content, authorId, postId);

                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (Reply reply in replies)
            {
                object[] values = 
                {
                    reply.Id,
                    reply.Content,
                    reply.AuthorId,
                    reply.PostId
                };

                string line = string.Join(";", values);

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}