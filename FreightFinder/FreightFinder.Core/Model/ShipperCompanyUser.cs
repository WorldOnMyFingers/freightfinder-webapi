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
    
    public partial class ShipperCompanyUser
    {
        public int Id { get; set; }
        public int UserId_FK { get; set; }
        public int BusinessId { get; set; }
        public int AuthorisationTypeId { get; set; }
    
        public virtual ShipperCompany ShipperCompany { get; set; }
        public virtual UserAuthorisationType UserAuthorisationType { get; set; }
        public virtual User User { get; set; }
    }
}
