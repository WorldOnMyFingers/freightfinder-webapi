using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightFinder.Core.Domain
{
    public class VehicleModel
    {
        public string Code { get; set; }

        public string ModelName { get; set; }

        public bool IsActive { get; set; }

        public virtual VehicleBrand Brand { get; set; }

    }
}
