using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;


namespace WebApiFreightFinder.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;

        }

        [HttpPost]
        [AllowAnonymous]
        public bool Post(Company company, string userId)
        {
           return _companyService.Add(company, userId);
        }

        [HttpGet]
        public Company Get(int companyId)
        {
           return _companyService.Get(companyId);
        }
    }
}
