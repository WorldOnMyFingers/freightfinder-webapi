using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Enums;
using FreightFinder.Core.Model;
using VehicleType = FreightFinder.Core.Enums.VehicleType;

namespace FreightFinder.Core.Domain
{
    public class Freight
    {
        public long Id { get; set; }

        public FreightTypeCode FreightType { get; set; }

        public int? Weight { get; set; }

        public bool IsFullVehicleQuantity { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LoadingDate { get; set; }

        public DateTime? DeliverByDate { get; set; }

        public DateTime? DateTaken { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool IsVatIncluded { get; set; }

        public bool IsDelivered { get; set; }

        public bool IsActive { get; set; }

        public bool IsTaken { get; set; }

        public string Description { get; set; }

        [Column("Destination_Address_Id")]
        public virtual Address DestinationAddress { get; set; }

        public virtual Company Company { get; set; }

        public virtual Address Address { get; set; }
        
        public virtual Location Location { get; set; }

        public virtual Vehicle Vehicle { get; set; }


    }
}
