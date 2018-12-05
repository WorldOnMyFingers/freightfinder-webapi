using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;

namespace FreightFinder.Core.IDAL
{
    public interface IUserRepository : IRepository<User>
    {
        void AttachToUser(Company company, User user);
    }
}
