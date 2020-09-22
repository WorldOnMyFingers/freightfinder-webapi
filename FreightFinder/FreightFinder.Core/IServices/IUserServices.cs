using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.ViewModels;
using User = FreightFinder.Core.Model.User;


namespace FreightFinder.Core.IServices
{
    public interface IUserServices
    {
        UserViewModel GetUserById(string id);
        Domain.User Get(string email);

        bool Add(Domain.User user);

        Domain.User Update(PostUserViewModel user);

        Credentials GetCredentials(string id);

        void ConfirmUser(string id);

    }
}
