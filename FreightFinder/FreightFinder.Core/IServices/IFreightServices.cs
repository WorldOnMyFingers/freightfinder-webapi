using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Core.IServices
{
    public interface IFreightServices
    {
        void Add(Freight freight);
        void Update(Freight freight);
        void Delete(int freightId);
        IEnumerable<FreightViewModel> GetFreights(CurrentLocationViewModel userCoordinates);
        FreightViewModel GetFreight(long id);

    }
}
