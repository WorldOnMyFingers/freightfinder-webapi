using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FreightFinder.Core.IServices;
using FreightFinder.Core.Model;
using FreightFinder.Service;
using User = FreightFinder.Core.Domain.User;


namespace WebApiFreightFinder.Controllers
{
    
    public class UserController : ApiController
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        
        [HttpPost]
        public bool Post(User user)
        {
            var result = _userServices.Add(user);

            return result;
        }

        public User Put(User user)
        {
            var result = _userServices.Update(user);

            return result;
        }


    }
}
