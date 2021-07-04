using System.Collections.Generic;

namespace NetGraphqlExample.UserService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }

    public class Address
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
