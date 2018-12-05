using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;

namespace FreightFinder.Core.IServices
{
    public interface ILocationServices
    {
        void Add(Location location);

        IEnumerable<Location> GetLocationSet(int userId, DateTime startDate);


    }
}
