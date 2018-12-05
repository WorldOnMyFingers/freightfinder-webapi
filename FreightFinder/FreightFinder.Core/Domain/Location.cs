using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Enums;

namespace FreightFinder.Core.Domain
{
    public class Location
    {
        [Column("Id")]
        public long Id { get; set; }

        public LocationTypeCodes LocationType { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
