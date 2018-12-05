using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreightFinder.Core.IoC;

namespace FreightFinder.Core.Domain
{
    [Table("Company")]
    public class Company
    {

        public int Id { get; set; }

        public int AddressId { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(14)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string TaxNumber { get; set; }

        [StringLength(50)]
        public string TaxOffice { get; set; }

        public DateTime MembershipDate { get; set; }

        public bool IsActive { get; set; }

        public virtual Address Address { get; set; }

        public CompanyTypeCodes CompanyType { get; set; }

    }
}
