using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.IDAL;
using FreightFinder.Core.Domain;

namespace FreightFinder.DAL.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public void AttachToUser(Company company, User user)
        {
            user.Company = company;
        }
    }
}
