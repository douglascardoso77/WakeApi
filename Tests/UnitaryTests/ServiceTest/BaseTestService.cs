using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CrossCutting.Mappings;

namespace Tests
{
    public class BaseTestService
    {
        public IMapper Mapper {get;set;}

        public BaseTestService()
        {
            Mapper = new AutoMapperFix().GetMapper();
        }
    }

    public class AutoMapperFix : IDisposable
    {
        public IMapper GetMapper()
        {
            var config =  new MapperConfiguration(c => 
            {
                    c.AddProfile(new DtoToModelProfile());
                    c.AddProfile(new EntityToDtoProfile());
                    c.AddProfile(new ModelToEntityProfile());
            });

            return config.CreateMapper();
        }
        public void Dispose()
        {
            
        }
    }
}