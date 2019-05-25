using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Core.IServices
{
    public interface IVehicleServices
    {
        VehicleViewModel Get(int id);
        bool Add(Vehicle vehicle);
        Byte[] GetImage(string url);
        IEnumerable<string> GetImageList(long id);

    }

}
