using AutoMapper;
using SibersTestProject.Model.Account;
using SibersTestProject.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SibersTestProject.Mappings
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<RegisterView, UserModel>(MemberList.Source);
            CreateMap<UserModel, RegisterView>(MemberList.Source);
        }
    }
}