using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightFinder.Core.Domain
{
    [Table("Country")]
    public class Country
    {

        public int Id { get; set; }

        [StringLength(50)]
        public string CountryName { get; set; }

        public bool IsActive { get; set; }

    }
}
