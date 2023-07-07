using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Repository
{
    
        public interface IUserRepository
        {
            void Add(User user);
            bool Exists(string username);
        }
    
}
