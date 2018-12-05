using System.Collections.Generic;
using FreightFinder.Core.Model;

namespace FreightFinder.Core.Services
{
    public interface IUserService
    {
        List<User> GetUsers(); 
        User GetUser(int userId);
        int GetUserType(string userName);
        bool AddNewUser(User user);
        bool UpdateUser(User user);
        bool AddNewTransportationCompanyUser(User user, TransportationCompanyUser transportationCompanyUser);

        //bool UpdateDriver
    }
}