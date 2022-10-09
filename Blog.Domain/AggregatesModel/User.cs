using Blog.Domain.SeedWork;

namespace Blog.Domain.AggregatesModel
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public ICollection<Blog> Blogs { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        private User(int id, string username, string passwordHash)
        {
            Username = !string.IsNullOrWhiteSpace(username) ? username.Trim() :
                throw new ArgumentException("Username is not valid");

            PasswordHash = !string.IsNullOrWhiteSpace(passwordHash) ? passwordHash.Trim() :
                throw new ArgumentException("PasswordHash is not valid");

            Id = id;
        }

        public static User Create(int id, string username, string passwordHash)
        {
            return new User(id, username, passwordHash);
        }

        public static User CurrentUser() // TODO: We need to JWT (Json Web Token) to get a user info and then we have to move this method to Application layer
        {
            return Create(1, "Majid", "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=");
        }
    }
}
