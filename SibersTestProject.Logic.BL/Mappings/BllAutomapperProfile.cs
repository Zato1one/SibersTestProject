using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.BL.Mappings
{
    public class BllAutomapperProfile : Profile
    {
        public BllAutomapperProfile()
        {
            //CreateMap<Foo, FooDto>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
            //CreateMap<Session, SessionModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();

        }
    }
}
