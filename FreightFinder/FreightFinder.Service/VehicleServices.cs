using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Service
{
    public class VehicleServices : IVehicleServices
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public VehicleServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Add(Vehicle vehicle)
        {
            _unitOfWork.VehicleRepository.Add(vehicle);
            _unitOfWork.Complete();

            return true;
        }

        public Byte[] GetImage(string url)
        {
            var image = System.IO.File.ReadAllBytes(url);
            return image;
        }

        public IEnumerable<string> GetImageList(long id)
        {
            try
            {
                var imageList = _unitOfWork.VehicleRepository.Get(id).ImagePaths.Select(x=> x.Name);
                return imageList;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }

        public VehicleViewModel Get(int id)
        {
            var vehicleViewModel = Mapper.Map<VehicleViewModel>(_unitOfWork.VehicleRepository.Get(id));
            return vehicleViewModel;
        }
    }
}
