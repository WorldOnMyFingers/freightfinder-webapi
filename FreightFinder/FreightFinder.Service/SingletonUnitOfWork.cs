using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.DAL;

namespace FreightFinder.Service
{
    public static class SingletonUnitOfWork
    {
        public static UnitOfWork UnitOfWork = UnitOfWork.Instance();
    }
}
