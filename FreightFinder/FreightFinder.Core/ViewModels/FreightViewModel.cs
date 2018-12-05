using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.Enums;

namespace FreightFinder.Core.ViewModels
{
    public class FreightViewModel
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

        public AddressViewModel Address { get; set; }

        public AddressViewModel DestinationAddress { get; set; }

        public Location Location { get; set; }
    }
}
