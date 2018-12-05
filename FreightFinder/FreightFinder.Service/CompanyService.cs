using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.DAL;

namespace FreightFinder.Service
{
    public class CompanyService : ICompanyService
    {

        private IUnitOfWork _unitOfWork { get; set; }

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Add(Company company, dynamic userId)
        {
            var user = _unitOfWork.UserRepository.Get(userId);
            if (user.Company == null)
            {
                _unitOfWork.CompanyRepository.Add(company);
                _unitOfWork.Complete();
                _unitOfWork.UserRepository.AttachToUser(company, user);
                _unitOfWork.Complete();

                return true;
            }

            return false;
        }

        public Company Get(int id)
        {
           return _unitOfWork.CompanyRepository.Get(id);
        }
    }
}
