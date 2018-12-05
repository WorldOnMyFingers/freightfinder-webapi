using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightFinder.Core.Domain
{
    public class DriverLocation : Location
    {
        public int DriverId { get; set; }
    }
}
