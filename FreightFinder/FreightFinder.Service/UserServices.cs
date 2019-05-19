using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FreightFinder.Core.DAL;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.Core.ViewModels;
using FreightFinder.DataAccess.Repositories;
using Company = FreightFinder.Core.Domain.Company;
using User = FreightFinder.Core.Model.User;


namespace FreightFinder.Service
{
    public class UserServices : IUserServices
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Core.Domain.User Get(string email)
        {
            var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(x => x.Email == email);
            return user;
        }

        public bool Add(Core.Domain.User user)
        {
            user.DateCreated = DateTime.UtcNow;
            user.IsActive = false;

            try
            {
                _unitOfWork.UserRepository.Add(user);
                _unitOfWork.Complete();
                return true;
            }
            catch (DbEntityValidationException e)
            {

                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                return false;
            }

        }

        public Core.Domain.User Update(Core.Domain.User user)
        {

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();

            return null;
        }

        public Credentials GetCredentials(string id)
        {
            var credentials = _unitOfWork.CredentialsRepository.Get(id);
            return credentials;
        }

        public void ConfirmUser(string id)
        {
            var user = _unitOfWork.UserRepository.Get(id);
            user.IsActive = true;
            _unitOfWork.Complete();
        }

        public UserViewModel GetUserById(string id)
        {
            try
            {
                var userViewModel = Mapper.Map<UserViewModel>(_unitOfWork.UserRepository.Get(id));
                return userViewModel;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;
            }

        }
    }
}
