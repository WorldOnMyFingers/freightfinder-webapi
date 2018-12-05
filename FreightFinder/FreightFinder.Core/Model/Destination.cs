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
    
    public partial class Destination
    {
        public int DestinationId { get; set; }
        public string BusinessTitle { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int BusinessId { get; set; }
        public System.DateTime DateAdded { get; set; }
    
        public virtual ShipperCompany ShipperCompany { get; set; }
    }
}
