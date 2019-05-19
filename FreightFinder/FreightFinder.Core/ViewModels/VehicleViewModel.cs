using System;
using System.Collections.Generic;
using FreightFinder.Core.Enums;

namespace FreightFinder.Core.ViewModels
{
    public class VehicleViewModel
    {
        public VehicleViewModel()
        {
        }

        public int Id { get; set; }

        public int Capacity { get; set; }

        public string PlateNumber { get; set; }

        public VehicleType VehicleType { get; set; }

        public string VehicleIdentificationNumber { get; set; }

        public string EngineNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsLoaded { get; set; }

        public bool IsActive { get; set; }

        public  string Colour { get; set; }

        public  string Brand { get; set; }

        public  string Model { get; set; }

        public  string Company { get; set; }

        public  IEnumerable<string> ImagePaths { get; set; }

    }
}
