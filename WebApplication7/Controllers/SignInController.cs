using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;
using WebApplication7.Repository;

namespace WebApplication7.Controllers
{
    public class SignInController : ControllerBase
    {
       // private readonly IUserService _userService;
        private readonly UserRepository _userRepository;
        private readonly  ApplicationDbContext _dbContext;


        public SignInController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] User model)
        {
            if (_userRepository.Exists(model.Username))
            {
                return BadRequest("Username is already taken");
            }

            var user = new User { Username = model.Username };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}

