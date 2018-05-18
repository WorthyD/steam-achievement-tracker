using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace sat_netcore.App_Start
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                //sat_dal.Startup.RegisterMaps();
                //cfg.AddProfile(new WebMappingProfile());  // mapping between Web view model and BLL service model
                //cfg.AddProfile(new BLLMappingProfile());  // mapping between API model and service model
                cfg.AddProfile(new sat_dal.DalMappingProfile());
            });
        }
    }
}
