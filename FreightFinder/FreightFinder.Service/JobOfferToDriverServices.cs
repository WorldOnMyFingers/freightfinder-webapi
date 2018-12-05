using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;

namespace FreightFinder.Service
{
    public class JobOfferToDriverServices : IJobOfferToDriverServices
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public JobOfferToDriverServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(JobOfferToDriver jobOfferToDriver)
        {
            _unitOfWork.JobOfferToDriverRepository.Add(jobOfferToDriver);
            _unitOfWork.Complete();
        }

        public void AcceptJobOffer(int jobOfferId, string userId)
        {
            
            var jobOffer = _unitOfWork.JobOfferToDriverRepository.Get(jobOfferId);
            if (jobOffer.Driver.Id == userId)
            {
                jobOffer.Vehicle.Driver = jobOffer.Driver;
                jobOffer.Driver.Company = jobOffer.Vehicle.Company;

                jobOffer.IsAccepted = true;
                jobOffer.DateAccepted = DateTime.Now;

                _unitOfWork.Complete();
            }
        }

        public void DetachDriverFromVehicle(int vehicleId)
        {
            var vehicle = _unitOfWork.VehicleRepository.Get(vehicleId);
            vehicle.Driver.Company = null;
            vehicle.Driver = null;
            _unitOfWork.Complete();
        }

    }
}
