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
            // Check if the username is already taken
            if (_userRepository.Exists(model.Username))
            {
                return BadRequest("Username is already taken");
            }

            // Create a new user
            var user = new User { Username = model.Username };

            // Store the user in the database
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            // You can optionally return some response data, such as a success message or the newly created user's ID
            return Ok();
        }
    }
}

