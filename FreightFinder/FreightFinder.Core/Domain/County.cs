using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Core.Domain
{
    [Table("County")]
    public class County
    {

        public int Id { get; set; }

        [StringLength(50)]
        public string CountyName { get; set; }

        public virtual City City { get; set; }

        public bool IsActive { get; set; }

        public virtual Location Coordinates { get; set; }


    }
}
