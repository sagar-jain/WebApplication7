using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Repository
{
    
        public class UserRepository : IUserRepository
        {
            private readonly ApplicationDbContext _dbContext;

            public UserRepository(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public void Add(User user)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }

            public bool Exists(string username)
            {
                return _dbContext.Users.Any(u => u.Username == username);
            }

            // Other implementations of IUserRepository methods
        }
    
}
