using System;
namespace FreightFinder.Core.ViewModels
{
    public class FreightOfferDetailsViewModel
    {
        public int Id { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime OfferDate { get; set; }
        public FreightViewModel Freight { get; set; }

        public FreightOfferDetailsViewModel()
        {
        }
    }
}
