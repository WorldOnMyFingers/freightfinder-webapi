using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Core.IServices
{
    public interface ILocationServices
    {
        void Add(LocationViewModel location);

        IEnumerable<Location> GetLocationSet(int userId, DateTime startDate);


    }
}
