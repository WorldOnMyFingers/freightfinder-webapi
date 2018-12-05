using System.ComponentModel.DataAnnotations;

namespace FreightFinder.Core.Domain
{
    public class TransportationCompany : Company
    {
        public decimal Balance { get; set; }

    }
}
