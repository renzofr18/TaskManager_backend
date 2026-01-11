
using System;
using TaskManager.Domain.Common;

namespace TaskManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; private set; } = null;
        public string Email { get; private set; } = null;

        protected User() { }

        public User(string username, string email)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            CreatedAt = DateTime.Now;   
        }
    }
}
