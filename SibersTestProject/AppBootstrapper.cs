using AutoMapper;
using ImageResizer.Plugins.DiskCache;
using ImageResizer.Plugins.PrettyGifs;
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
            //AutoMapper profile 
            Mapper.Initialize(config => {
                config.AddProfile<BllAutomapperProfile>();
                config.AddProfile<WebAutomapperProfile>();

            });

            // Mapper.Configuration.AssertConfigurationIsValid();


            //ImageResizer plugins
            new DiskCache().Install(ImageResizer.Configuration.Config.Current);
            new PrettyGifs().Install(ImageResizer.Configuration.Config.Current);
        }
    }
}