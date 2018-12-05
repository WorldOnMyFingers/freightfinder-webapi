using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightFinder.Core.ViewModels
{
    public class AddressViewModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string AddressLine { get; set; }
    }
}
