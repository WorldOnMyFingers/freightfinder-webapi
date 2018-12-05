using FreightFinder.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightFinder.Core.ViewModels
{
    public class OfferToFreightViewModel
    {
        public int OfferId { get; set; }
        public long FreightId { get; set; }
        public DateTime OfferDate { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime? DateAccepted { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Price { get; set; }
        public string Weight { get; set; }
        public FreightTypeCode FreightType { get; set; }


    }
}
