using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreightFinder.Core.Domain;

namespace WebApiFreightFinder.Models
{
    public class RegisterUserDto
    {
        public RegisterBindingModel RegisterModel { get; set; }

        public User User { get; set; }
    }
}