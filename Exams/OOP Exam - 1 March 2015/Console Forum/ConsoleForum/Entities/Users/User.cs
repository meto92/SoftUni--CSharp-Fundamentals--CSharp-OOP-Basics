namespace ConsoleForum.Entities.Users
{
    using System;
    using System.Collections.Generic;

    using ConsoleForum.Contracts;

    public class User : AbstractUser, IUser
    {
        public User(int id, string name, string password, string email) 
            : base(id, name, password, email)
        { }
    }
}