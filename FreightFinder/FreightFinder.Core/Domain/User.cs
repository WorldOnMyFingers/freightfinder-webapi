using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Enums;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;

namespace FreightFinder.Core.Domain
{
    public class User
    {
        public string Id { get; set; }

        public long NationalIdentity { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PicturePath { get; set; }

        public virtual Company Company { get; set; }

        public UserType UserType { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }
    }
}
