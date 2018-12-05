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
    
    public partial class Vehicle
    {
        public Vehicle()
        {
            this.CreditTransfers = new HashSet<CreditTransfer>();
            this.Employments = new HashSet<Employment>();
            this.OffersToFreights = new HashSet<OffersToFreight>();
            this.Transactions = new HashSet<Transaction>();
            this.VehicleAds = new HashSet<VehicleAd>();
            this.VehicleLocations = new HashSet<VehicleLocation>();
        }
    
        public int VehicleId { get; set; }
        public Nullable<int> DriverId { get; set; }
        public string PlateNumber { get; set; }
        public int VehicleTypeId { get; set; }
        public int Capacity { get; set; }
        public string Colour { get; set; }
        public string VehicleIdentificationNumber { get; set; }
        public string EngineNumber { get; set; }
        public string BrandName { get; set; }
        public int CompanyId { get; set; }
        public string PicturePath { get; set; }
        public bool IsLoaded { get; set; }
        public System.DateTime DateAdded { get; set; }
    
        public virtual ICollection<CreditTransfer> CreditTransfers { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<Employment> Employments { get; set; }
        public virtual ICollection<OffersToFreight> OffersToFreights { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual TransportationCompany TransportationCompany { get; set; }
        public virtual ICollection<VehicleAd> VehicleAds { get; set; }
        public virtual ICollection<VehicleLocation> VehicleLocations { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
