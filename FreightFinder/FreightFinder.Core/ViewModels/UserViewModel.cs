using System;
using System.Collections.Generic;
using FreightFinder.Core.Enums;

namespace FreightFinder.Core.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {

        }

        public string Id { get; set; }

        public long NationalIdentity { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public UserType UserType { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }

        public virtual IEnumerable<string> ImagePaths { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
