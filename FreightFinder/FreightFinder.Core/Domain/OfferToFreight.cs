using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightFinder.Core.Domain
{
    public class OfferToFreight
    {
        public int Id { get; set; }

        public DateTime OfferDate { get; set; }

        public DateTime? DateAccepted { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsActive { get; set; }
    
        public virtual Vehicle Vehicle { get; set; }

        public virtual Freight Freight { get; set; }
    }
}
