using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;

namespace FreightFinder.Core.IServices
{
    public interface IVehicleServices
    {
        bool Add(Vehicle vehicle);
        Byte[] GetImage(string url);
    }

}
