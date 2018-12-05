using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;

namespace FreightFinder.Core.ViewModels
{
    public class CurrentLocationViewModel
    {
        public Coordinates Coordinates { get; set; }

        public int Distance { get; set; }
    }
}
