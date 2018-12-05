using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using User = FreightFinder.Core.Model.User;


namespace FreightFinder.Core.IServices
{
    public interface IUserServices
    {
        Domain.User Get(string email);

        bool Add(Domain.User user);

        Domain.User Update(Domain.User user);

        Credentials GetCredentials(string id);

        void ConfirmUser(string id);

    }
}
