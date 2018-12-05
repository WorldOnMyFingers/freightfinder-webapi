using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Core.Domain
{
    [Table("City")]
    public class City
    {

        public int Id { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public virtual Country Country { get; set; }

        public bool IsActive { get; set; }

        public virtual Location Coordinates { get; set; }


    }
}
