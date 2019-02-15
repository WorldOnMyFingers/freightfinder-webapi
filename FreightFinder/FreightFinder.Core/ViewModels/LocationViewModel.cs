using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Enums;

namespace FreightFinder.Core.ViewModels
{
    public class LocationViewModel
    {
        public long Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public LocationTypeCodes LocationType { get; set; }

    }
}
