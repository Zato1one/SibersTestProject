using AutoMapper;
using SibersTestProject.Logic.BL.Mappings;
using SibersTestProject.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SibersTestProject
{
    public static class AppBootstrapper
    {
        public static void Init()
        {

            Mapper.Initialize(config => {
                config.AddProfile<BllAutomapperProfile>();
                config.AddProfile<WebAutomapperProfile>();

            });

           // Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}