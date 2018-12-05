using FreightFinder.Core.Model;

namespace FreightFinder.Services 
{
    public class BusinessService : Core.Services.IBusinessService
    {

        public Core.Model.Business GetBusiness(int businessId)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateNewBusiness(Core.Model.Business newBusiness, Core.Model.User newBusinessUser)
        {
            ShipperCompanyUser shipperCompanyUser = new ShipperCompanyUser();
            shipperCompanyUser.Business = newBusiness;
            shipperCompanyUser.User = newBusinessUser;

            shipperCompanyUser.BusinessId = newBusiness.BusinessId;
            shipperCompanyUser.UserId = newBusinessUser.UserId;

            var dbContext = new FreightFinder();
           

            
            return true;
        }

        public bool UpdateBusiness(Core.Model.Business business)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteBusiness(int businessId)
        {
            throw new System.NotImplementedException();
        }
    }
}