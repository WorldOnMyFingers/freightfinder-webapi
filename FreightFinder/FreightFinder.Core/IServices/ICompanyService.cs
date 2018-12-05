using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;

namespace FreightFinder.Core.IServices
{
    public interface ICompanyService
    {
        bool Add(Company company, dynamic userId);
        Company Get(int id);
    }
}
