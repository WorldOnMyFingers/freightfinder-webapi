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

        public IEnumerable<DropDownIdNameViewModel> GetCities()
        {
            var list = Mapper.Map<IEnumerable<City>, IEnumerable<DropDownIdNameViewModel>>(_unitOfWork.CityRepository.GetAll());
            return list;
        }

        public IEnumerable<DropDownIdNameViewModel> GetCounties()
        {
            var list = Mapper.Map<IEnumerable<County>, IEnumerable<DropDownIdNameViewModel>>(_unitOfWork.CountyRepository.GetAll());
            return list;
        }

        public IEnumerable<DropDownIdNameViewModel> GetCountries()
        {
            var list = Mapper.Map<IEnumerable<Country>, IEnumerable<DropDownIdNameViewModel>>(_unitOfWork.CountryRepository.GetAll());
            return list;
        }
    }
}
