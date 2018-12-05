using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Model;
using FreightFinder.Core.DAL;

namespace FreightFinder.DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {


        public List<Core.Model.User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            User user = new User();
            try
            {
                using (var context = new FreightFinder())
                {
                    user = context.Users.FirstOrDefault(x => x.Email == email);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
                    
                
            return user;
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
