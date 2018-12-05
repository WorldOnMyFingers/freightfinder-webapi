using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Model;
using FreightFinder.Core.Services;

namespace FreightFinder.DataAccess
{
    public class UserServices: IUserService
    {


        public List<Core.Model.User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Core.Model.User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetUserType(string userName)
        {
            User user= new User();
            using (var context = new FreightFinder())
            {
                user = context.Users.FirstOrDefault(x => x.Email == userName);
            }
            return user.UserType_Id;
        }

        public bool AddNewUser(Core.Model.User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(Core.Model.User user)
        {
            throw new NotImplementedException();
        }

        public bool AddNewTransportationCompanyUser(Core.Model.User user, Core.Model.TransportationCompanyUser transportationCompanyUser)
        {
            throw new NotImplementedException();
        }
    }
}
