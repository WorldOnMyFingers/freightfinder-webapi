using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IDAL;

namespace FreightFinder.DAL.Repository
{
    public class JobOfferToDriverRepository : Repository<JobOfferToDriver>, IJobOfferToDriverRepository
    {
        public JobOfferToDriverRepository(DbContext context) : base(context)
        {
        }
    }
}
