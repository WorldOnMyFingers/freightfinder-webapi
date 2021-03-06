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
    
    public partial class Company
    {
        public Company()
        {
            this.ShipperCompanies = new HashSet<ShipperCompany>();
            this.TransportationCompanies = new HashSet<TransportationCompany>();
        }
    
        public int CompanyId { get; set; }
        public int CompanyTypeId { get; set; }
        public string CompanyName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public System.DateTime MembershipDate { get; set; }
    
        public virtual ICollection<ShipperCompany> ShipperCompanies { get; set; }
        public virtual CompanyType CompanyType { get; set; }
        public virtual ICollection<TransportationCompany> TransportationCompanies { get; set; }
    }
}
