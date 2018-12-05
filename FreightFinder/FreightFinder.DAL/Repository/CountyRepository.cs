﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.Domain;
using FreightFinder.Core.IDAL;

namespace FreightFinder.DAL.Repository
{
    public class CountyRepository : Repository<County>, ICountyRepository
    {
        public CountyRepository(DbContext context) : base(context)
        {
        }
    }
}
