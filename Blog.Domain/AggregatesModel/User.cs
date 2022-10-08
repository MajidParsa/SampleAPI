﻿using Blog.Domain.SeedWork;

namespace Blog.Domain.AggregatesModel
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }

        private User(int id, string username, string passwordHash)
        {
            if (id > 0)
                Id = id;

            Username = !string.IsNullOrWhiteSpace(username) ? username.Trim() :
                throw new ArgumentException("Username is not valid");

            PasswordHash = !string.IsNullOrWhiteSpace(passwordHash) ? passwordHash.Trim() :
                throw new ArgumentException("PasswordHash is not valid");

        }

        public static User Create(int id, string username, string passwordHash)
        {
            return new User(id, username, passwordHash);
        }
    }
}
