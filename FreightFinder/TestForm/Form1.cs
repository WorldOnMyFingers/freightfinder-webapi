using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreightFinder.Core.Model;
using FreightFinder.Core.DAL;
using FreightFinder.DataAccess;


namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Destination MakeAdd()
        {
            Destination destination = new Destination();

            destination.BusinessTitle = "Parlak Tarimmmm";
            destination.Telephone = "03243263434";
            destination.Email = "parlaktarim@hotmail.commmmmm";
            destination.Mobile = "05334753545";
            destination.City = "Mersin";
            destination.County = "Merkez";
            destination.Address = "Depolar";
            destination.DateAdded = DateTime.Now;
            destination.BusinessId = 10;

            IDestinationService iDestinationService = new DestinationServices();
            iDestinationService.AddNewDestination(destination);

            return destination;
        }

        private void AddShipperCompany()
        {
            Company company = new Company();
            User user = new User();
            ShipperCompanyUser shipperCompanyUser = new ShipperCompanyUser();
            ShipperCompany shipperCompany = new ShipperCompany();

            //business.BusinessId = 2;
            company.CompanyTypeId = 1;
            company.CompanyName = "Ozbabayigitler";
            company.City = "Yozgat";
            company.County = "Sorgun";
            company.District = "Yeni Bugday Pazari";
            company.Address = "NO: 61";
            company.TaxNumber = "123456789";
            company.TaxOffice = "Sorgun";
            company.Email = "babayigit-emre@gmail.commmm";
            company.Telephone = "05555940264";
            company.MembershipDate = DateTime.Now;
            shipperCompany.Company = company;

            user.UserName = "Emreeeeeeee";
            user.Password = "1234";
            user.Surname = "Babayigit";
            user.Email = "babaygiit-emre@hotmail.com";
            user.TC = 61534400452;
            user.Telephone = "05555940264";
            user.DateOfBirth = new DateTime(1988, 05, 01);
            user.Name = "Emreeeeeee";
            user.Surname = "Babayigit";
            user.UserType_Id = 1;

            shipperCompanyUser.User = user;
            shipperCompanyUser.ShipperCompany = shipperCompany;
            shipperCompanyUser.UserId_FK = user.UserId;
            shipperCompanyUser.AuthorisationTypeId = 1;


            IShipperCompanyService businessService = new ShipperCompanyServices();

            businessService.CreateNewBusiness(shipperCompanyUser);

        }

        private ShipperCompany GetShipperCompany()
        {
            IShipperCompanyService iBusinessService = new ShipperCompanyServices();
            ShipperCompany shipperCompany = new ShipperCompany();
            shipperCompany = iBusinessService.GetBusiness(10);

            return shipperCompany;
        }

        private void UpdateShipperCompany()
        {

            Company company = new Company();
            ShipperCompany shipperCompany = new ShipperCompany();

            company.CompanyId = 4;
            company.CompanyTypeId = 1;
            company.CompanyName = "Ozbabayigitlerrrrrrrtt";
            company.City = "Yozgattttttt";
            company.County = "Sorgun";
            company.District = "Yeni Bugday Pazari";
            company.Address = "NO: 61";
            company.TaxNumber = "123456789";
            company.TaxOffice = "Sorgunnnnnnnn";
            company.Email = "babayigit-emre@gmail.commmm";
            company.Telephone = "05555940264";
            company.MembershipDate = DateTime.Now;


            shipperCompany.Company = company;
            shipperCompany.ShipperCompanyId = 10;
            shipperCompany.CompanyId_FK = company.CompanyId;

            IShipperCompanyService businessService = new ShipperCompanyServices();

            businessService.UpdateBusiness(shipperCompany);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Company business = new Company();
            User user = new User();

            //business.BusinessId = 2;
            business.CompanyName = "Ozbabayigitler";
            business.City = "Yozgat";
            business.County = "Sorgun";
            business.District = "Yeni Bugday Pazari";
            business.Address = "NO: 61";
            business.TaxNumber = "123456789";
            business.TaxOffice = "Sorgun";
            business.Email = "babayigit-emre@gmail.commmm";
            //business.Telephone = "05555940264";
            business.MembershipDate = DateTime.Now;

            user.UserName = "Emre";
            user.Password = "1234";
            user.Surname = "Babayigit";
            user.Email = "babaygiit-emre@hotmail.com";
            user.TC = 61534400452;
            user.Telephone = "05555940264";
            user.DateOfBirth = new DateTime(1988, 05, 01);
            user.Name = "Emre";
            user.Surname = "Babayigit";
            user.UserType_Id = 1;


            IShipperCompanyService businessService = new ShipperCompanyServices();

            //businessService.CreateNewBusiness(business, user);

            //var a = businessService.UpdateBusiness(business);

        }

        private void AddNewShipperCompanyUser()
        {
            ShipperCompanyUser shipperCompanyUser = new ShipperCompanyUser();
            User user = new User();
            user.UserName = "Sukkaggggggggggggg";
            user.Password = "vildan";
            user.Surname = "Babayigit";
            user.Email = "vildan-babayigit@hotmail.com";
            user.TC = 61534400452;
            user.Telephone = "12";
            user.DateOfBirth = new DateTime(2005, 05, 01);
            user.Name = "Vildan";
            user.Surname = "Babayigit";
            user.UserType_Id = 1;

            shipperCompanyUser.BusinessId = 10;
            shipperCompanyUser.AuthorisationTypeId = 2;
            shipperCompanyUser.UserId_FK = user.UserId;
            shipperCompanyUser.User = user;

            IShipperCompanyUserService iShipperCompanyUserService = new ShipperCompanyUserServices();
            iShipperCompanyUserService.AddNewShipperCompanyUser(shipperCompanyUser);


        }

        private void UpdateShipperCompanyUser()
        {
            ShipperCompanyUser shipperCompanyUser = new ShipperCompanyUser();
            User user = new User();
            user.UserId = 11;
            user.UserName = "Sukkag";
            user.Password = "vildan";
            user.Password = PasswordHash.PasswordHash.CreateHash(user.Password);
            user.Surname = "Babayigit";
            user.Email = "vildan-babayigit@hotmail.com";
            user.TC = 61534400452;
            user.Telephone = "0555555555";
            user.DateOfBirth = new DateTime(2005, 05, 01);
            user.Name = "Vildan";
            user.Surname = "Babayigit";
            user.UserType_Id = 1;

            shipperCompanyUser.Id = 9;
            shipperCompanyUser.BusinessId = 10;
            shipperCompanyUser.AuthorisationTypeId = 2;
            shipperCompanyUser.UserId_FK = 11;
            shipperCompanyUser.User = user;

            IShipperCompanyUserService iShipperCompanyUserService = new ShipperCompanyUserServices();
            iShipperCompanyUserService.UpdateShipperCompanyUser(shipperCompanyUser);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetShipperCompany();


        }

        private TransportationCompanyUser GetTransportationCompanyUser()
        {

            Company company = new Company();
            User user = new User();
            TransportationCompanyUser transportationCompanyUser = new TransportationCompanyUser();
            TransportationCompany transportationCompany = new TransportationCompany();

            company.CompanyName = "Babayigitler";
            company.City = "Yozgat";
            company.County = "Sorgun";
            company.District = "Yeni Bugday Pazari";
            company.Address = "NO 61";
            company.TaxNumber = "123456789";
            company.TaxOffice = "Sorgun";
            company.Email = "babayigit-emre@gmail.commmm";
            company.Telephone = "05555940264";
            company.MembershipDate = DateTime.Now;
            company.CompanyTypeId = 2;
            transportationCompany.Company = company;
            transportationCompany.CompanyId_FK = company.CompanyId;
            transportationCompany.KDocumentNumber = "KYozgat1234567890";



            user.UserName = "Merve";
            user.Password = "1234";
            user.Password = PasswordHash.PasswordHash.CreateHash(user.Password);
            user.Surname = "Babayigit";
            user.Email = "merveb@hotmail.com";
            user.TC = 61534400452;
            user.Telephone = "05555940264";
            user.DateOfBirth = new DateTime(1988, 05, 01);
            user.Name = "Merve";
            user.Surname = "Babayigit";
            user.UserType_Id = 1;
            transportationCompanyUser.User = user;
            transportationCompanyUser.UserId_FK = user.UserId;
            transportationCompanyUser.AuthorisationTypeId = 1;
            transportationCompanyUser.CompanyId = transportationCompany.TransportationCompanyId;
            transportationCompanyUser.TransportationCompany = transportationCompany;



            ITransportationCompanyService transportationCompanyService = new TransportationCompanyServices();

            transportationCompanyService.CreateNewTransportationCompany(transportationCompanyUser);
            return null;
        }

        private void UpdateTransportationCompany()
        {
            Company company = new Company();
            TransportationCompany transportationCompany = new TransportationCompany();

            company.CompanyId = 6;
            company.CompanyName = "Babayigitler";
            company.City = "Yozgat";
            company.County = "Sorgun";
            company.District = "Yeni Bugday Pazari";
            company.Address = "NO 61";
            company.TaxNumber = "123456789";
            company.TaxOffice = "Sorgun";
            company.Email = "babayigit-emre@gmail.commmm";
            company.Telephone = "05555940264";
            company.MembershipDate = DateTime.Now;
            company.CompanyTypeId = 2;

            transportationCompany.Company = company;
            transportationCompany.CompanyId_FK = company.CompanyId;
            transportationCompany.KDocumentNumber = "KYozgat1234567890";
            transportationCompany.TransportationCompanyId = 1;

            ITransportationCompanyService iTransportationCompanyService = new TransportationCompanyServices();
            // iTransportationCompanyService.UpdateTransportationCompany(transportationCompany);
            iTransportationCompanyService.GetTransportationCompany(1);
        }

        private void AddNewVehicle()
        {
            Vehicle vehicle = new Vehicle();

            vehicle.VehicleIdentificationNumber = "000918273645";
            vehicle.VehicleTypeId = 1;
            vehicle.BrandName = "Scania";
            vehicle.Capacity = 25300;
            vehicle.Colour = "red";
            vehicle.CompanyId = 1;
            vehicle.DateAdded = DateTime.Now;
            vehicle.EngineNumber = "192837465";
            vehicle.PlateNumber = "66LA999";
            vehicle.IsLoaded = false;

            IVehicleService vehicleService = new VehicleServices();
            vehicleService.AddNewVehicle(vehicle);

        }

        private void UpdateVehicle()
        {
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleId = 4;
            vehicle.VehicleIdentificationNumber = "000918273645";
            vehicle.VehicleTypeId = 1;
            vehicle.BrandName = "ScaniRenayulta";
            vehicle.Capacity = 25300;
            vehicle.Colour = "red";
            vehicle.CompanyId = 1;
            vehicle.DateAdded = DateTime.Now;
            vehicle.EngineNumber = "192837465";
            vehicle.PlateNumber = "66LA888";
            vehicle.IsLoaded = false;

            IVehicleService vehicleService = new VehicleServices();
            vehicleService.UpdateVehicle(vehicle);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            IVehicleAdsService iVehicleAdsService = new VehicleAdsServices();
            iVehicleAdsService.ViewMyAllVehicleAdsHistory(3);

        }

        private void AddNewTransportationCompanyUser()
        {
            TransportationCompanyUser transportationCompanyUser = new TransportationCompanyUser();
            User user = new User();
            user.UserName = "Menshur";
            user.Password = "mensgur1928";
            user.Password = PasswordHash.PasswordHash.CreateHash(user.Password);
            user.Surname = "bayindir";
            user.Email = "mensgur-vural@hotmail.com";
            user.TC = 64444400452;
            user.Telephone = "0532344987";
            user.DateOfBirth = new DateTime(1028, 05, 01);
            user.Name = "mensgur";
            user.Surname = "bayindir";
            user.UserType_Id = 2;


            transportationCompanyUser.CompanyId = 1;
            transportationCompanyUser.AuthorisationTypeId = 2;
            transportationCompanyUser.UserId_FK = user.UserId;
            transportationCompanyUser.User = user;

            ITransportationCompanyUserService iTransportationCompanyUserService = new TransportationCompanyUserServices();
            iTransportationCompanyUserService.AddNewTransportationCompanyUser(transportationCompanyUser);


        }

        private void UpdateTransportationCompanyUser()
        {
            TransportationCompanyUser transportationCompanyUser = new TransportationCompanyUser();
            User user = new User();
            user.UserId = 20;

            user.UserName = "Arife";
            user.Password = "arife1985";
            //user.Password = PasswordHash.PasswordHash.CreateHash(user.Password);
            user.Surname = "Vural";
            user.Email = "Arife-vural@hotmail.com";
            user.TC = 61534400452;
            user.Telephone = "05323443472";
            user.DateOfBirth = new DateTime(1985, 05, 01);
            user.Name = "Arife";
            user.Surname = "Vural";
            user.UserType_Id = 2;

            transportationCompanyUser.Id = 8;
            transportationCompanyUser.CompanyId = 1;
            transportationCompanyUser.AuthorisationTypeId = 2;
            transportationCompanyUser.UserId_FK = user.UserId;
            transportationCompanyUser.User = user;

            ITransportationCompanyUserService iTransportationCompanyUserService = new TransportationCompanyUserServices();
            iTransportationCompanyUserService.UpdateTransportationCompanyUser(transportationCompanyUser);
        }

        private void AddNewDriver()
        {
            User user = new User();
            Driver driver = new Driver();

            
            user.UserName = "Mahmut";
            user.Password = "mahmut1981";
            user.Password = PasswordHash.PasswordHash.CreateHash(user.Password);
            user.Surname = "babayigit";
            user.Email = "mahmit-babayigit@hotmail.com";
            user.TC = 644123456;
            user.Telephone = "05056666060";
            user.DateOfBirth = new DateTime(1028, 05, 01);
            user.Name = "Mahmit";
            user.Surname = "Babayigit";
            user.UserType_Id = 3;

            driver.Address = "Agaefendi mahallesi";
            driver.BloodType = "A rh+";
            driver.City = "Yozgat";
            driver.County = "Sorgun";
            driver.DrivingLicenseNo = 36733673;
            driver.UserId = user.UserId;
            driver.User = user;

            IDriverService iDriverService = new DriverServices();

            iDriverService.AddNewDriver(driver);

        }

        private void UpdateDriver()
        {
            User user = new User();
            Driver driver = new Driver();

            user.UserId = 21;
            user.UserName = "Mahmut";
            user.Password = "mahmut1981";
            //user.Password = PasswordHash.PasswordHash.CreateHash(user.Password);
            user.Surname = "babayigit";
            user.Email = "mahmit-babayigit@hotmail.com";
            user.TC = 644123456;
            user.Telephone = "05056666060";
            user.DateOfBirth = new DateTime(1028, 05, 01);
            user.Name = "Mahmit";
            user.Surname = "Babayigit";
            user.UserType_Id = 3;

            driver.Address = "Agaefendi mahallesi";
            driver.BloodType = "A rh+";
            driver.City = "Yozgat";
            driver.County = "Sorgun";
            driver.DrivingLicenseNo = 36733673;
            driver.DriverId = 2;
            driver.UserId = user.UserId;
            driver.User = user;

            IDriverService iDriverService = new DriverServices();

            iDriverService.UpdateDriver(driver);
        }

        private void AddNewVehicleAd()
        {
            VehicleAd vehicleAd = new VehicleAd();

            vehicleAd.VehicleId = 3;
            vehicleAd.IsTaken = false;
            vehicleAd.IsValid = true;
            vehicleAd.Lat = (decimal)192.16812;
            vehicleAd.Lon = (decimal) 173.98727; 
            vehicleAd.AdDate = DateTime.Now;
            vehicleAd.DestinationCity = "Denizli";
            vehicleAd.DestinationCounty = "Merkez";

            IVehicleAdsService iVehicleAdsService = new VehicleAdsServices();
            iVehicleAdsService.AddNewVehicleAd(vehicleAd);

        }

        private void UpdateVehicleAd()
        {
            VehicleAd vehicleAd = new VehicleAd();
            vehicleAd.VehicleAdId = 1;
            vehicleAd.VehicleId = 3;
            vehicleAd.IsTaken = false;
            vehicleAd.IsValid = true;
            vehicleAd.Lat = (decimal)192.16812;
            vehicleAd.Lon = (decimal)173.98727;
            vehicleAd.AdDate = DateTime.Now;
            vehicleAd.DestinationCity = "Istanbul";
            vehicleAd.DestinationCounty = "Merkez";

            IVehicleAdsService iVehicleAdsService = new VehicleAdsServices();
            iVehicleAdsService.UpdateVehicleAd(vehicleAd);

        }
    }
}