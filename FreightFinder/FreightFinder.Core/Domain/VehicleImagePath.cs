using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightFinder.Core.Domain
{
    [Table("VehicleImagePaths")]
    public class VehicleImagePath
    {
        public VehicleImagePath()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
