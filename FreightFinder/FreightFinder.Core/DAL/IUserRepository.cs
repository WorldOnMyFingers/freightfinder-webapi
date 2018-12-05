using System.Collections.Generic;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.DAL
{
    public interface IUserRepository
    {
        List<User> GetUsers(); 
        User GetUser(string email);
        int GetUserType(string userName);
        bool AddNewUser(User user);
        bool UpdateUser(User user);
        bool AddNewTransportationCompanyUser(User user, TransportationCompanyUser transportationCompanyUser);

        //bool UpdateDriver
    }
}