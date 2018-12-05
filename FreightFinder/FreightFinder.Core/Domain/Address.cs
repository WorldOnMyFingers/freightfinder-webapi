using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightFinder.Core.Domain
{
    [Table("Address")]
    public class Address
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(100)]
        public string AddressLine { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual County County { get; set; }

        public virtual State State { get; set; }

    }
}
