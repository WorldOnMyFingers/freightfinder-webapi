using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightFinder.Core.Domain
{
    [Table("Company_Type")]
    public  class CompanyType
    {
        
        public string Code { get; set; }

        [StringLength(50)]
        public string CompanyTypeName { get; set; }

        public bool IsActive { get; set; }

    }

    public enum CompanyTypeCodes
    {
        /// <summary>
        /// Shipper Company
        /// </summary>
        SIC = 1,

        /// <summary>
        /// Transportation Company
        /// </summary>
        TRC = 2
    }
}
