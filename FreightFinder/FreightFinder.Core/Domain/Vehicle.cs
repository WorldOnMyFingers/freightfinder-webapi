using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Enums;

namespace FreightFinder.Core.Domain
{
    public class Vehicle
    {
        [Column("Id"), Key]
        public int Id { get; set; }

        public int Capacity { get; set; }

        public string PlateNumber { get; set; }

        public VehicleType VehicleType { get; set; }

        public string VehicleIdentificationNumber { get; set; }

        public string EngineNumber { get; set; }

        public string PicturePath { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsLoaded { get; set; }

        public bool IsActive { get; set; }

        public virtual Colour Colour { get; set; }

        public virtual VehicleBrand Brand { get; set; }

        public virtual VehicleModel Model { get; set; }

        public virtual Company Company { get; set; }

        public virtual User Driver { get; set; }
    }
}
