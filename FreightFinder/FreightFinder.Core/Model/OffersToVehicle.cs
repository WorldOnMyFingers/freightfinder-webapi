//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FreightFinder.Core.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OffersToVehicle
    {
        public long OfferId { get; set; }
        public int VehiclehAdId { get; set; }
        public int BusinessId { get; set; }
        public int FreightAdId { get; set; }
        public System.DateTime OfferDate { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }
    
        public virtual ShipperCompany ShipperCompany { get; set; }
        public virtual VehicleAd VehicleAd { get; set; }
    }
}
