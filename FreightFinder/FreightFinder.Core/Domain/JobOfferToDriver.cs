using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightFinder.Core.Domain
{
    public class JobOfferToDriver
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateAccepted { get; set; }

        public bool IsAccepted { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual User Driver { get; set; }    }
}
