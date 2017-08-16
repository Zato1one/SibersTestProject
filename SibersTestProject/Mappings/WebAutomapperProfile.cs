﻿using AutoMapper;
using SibersTestProject.Model.Account;
using SibersTestProject.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SibersTestProject.Data.DAL.Identity.Entities;

namespace SibersTestProject.Mappings
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<RegisterView, ProjectUser>(MemberList.Source);
        }
    }
}