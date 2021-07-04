using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetGraphqlExample.UserService.Models;

namespace NetGraphqlExample.UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        static List<User> _users = new List<User>();

        static UserController()
        {
            var id = 1;
            var userGenerator = new Bogus.Faker<User>()
                .RuleFor(u => u.Id, f => id++)
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
                .RuleFor(u => u.Address, (f, u) => new Address()
                {
                    Street = f.Address.StreetAddress(),
                    City = f.Address.City(),
                });

            _users = userGenerator.Generate(10);
        }

        [HttpPost]
        public List<User> GetUsers(List<int> ids)
            => _users.Where(u => ids.Contains(u.Id)).ToList();
    }
}
