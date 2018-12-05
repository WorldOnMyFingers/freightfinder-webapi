using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightFinder.Core.Domain
{
    public class LocationCounty 
    {
        public virtual County County { get; set; }
    }
}
