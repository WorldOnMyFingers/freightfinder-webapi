using System;
using System.Collections.Generic;
using AutoMapper;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;

namespace FreightFinder.Service
{
    public class ListServices : IListServices
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public ListServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DropDownIdNameViewModel> GetCities(int countryId)
        {
            var list = Mapper.Map<IEnumerable<City>, IEnumerable<DropDownIdNameViewModel>>(_unitOfWork.CityRepository.Find(x => x.Country.Id == countryId));
            return list;
        }

        public IEnumerable<DropDownIdNameViewModel> GetCounties(int cityId)
        {
            var list = Mapper.Map<IEnumerable<County>, IEnumerable<DropDownIdNameViewModel>>(_unitOfWork.CountyRepository.Find(x => x.City.Id == cityId));
            return list;
        }

        public IEnumerable<DropDownIdNameViewModel> GetCountries()
        {
            var list = Mapper.Map<IEnumerable<Country>, IEnumerable<DropDownIdNameViewModel>>(_unitOfWork.CountryRepository.GetAll());
            return list;
        }

        public IEnumerable<DropDownNameValueViewModel> GetVehicleBrands()
        {
            try
            {
                var list = Mapper.Map<IEnumerable<VehicleBrand>, IEnumerable<DropDownNameValueViewModel>>(_unitOfWork.VehicleBrandRepository.GetAll());
                return list;
            }
            catch (Exception exception)
            {
                throw;
            }

        }

        public IEnumerable<DropDownNameValueViewModel> GetVehicleModels(string brandCode)
        {
            var list = Mapper.Map<IEnumerable<VehicleModel>, IEnumerable<DropDownNameValueViewModel>>(_unitOfWork.VehicleModelRepository.Find(x => x.Brand.Code == brandCode));
            return list;
        }

        public IEnumerable<DropDownNameValueViewModel> GetColors()
        {
            var list = Mapper.Map<IEnumerable<Colour>, IEnumerable<DropDownNameValueViewModel>>(_unitOfWork.ColourRepository.GetAll());
            return list;
        }
    }
}
