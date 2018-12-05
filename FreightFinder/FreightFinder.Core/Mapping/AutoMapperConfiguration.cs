using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace FreightFinder.Core.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Setup()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<FreightFinderMapper>();
            });
        }
    }
}
