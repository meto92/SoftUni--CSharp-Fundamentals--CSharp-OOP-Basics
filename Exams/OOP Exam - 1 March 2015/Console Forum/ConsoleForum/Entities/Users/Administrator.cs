﻿using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Users
{
    public class Administrator : AbstractUser, IAdministrator
    {
        public Administrator(int id, string name, string password, string email) 
            : base(id, name, password, email)
        { }
    }
}