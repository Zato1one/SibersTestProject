﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using SibersTestProject.Common.Extensions;
using SibersTestProject.Common.Model;
using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Data.DAL.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SibersTestProject.Logic.BL.Mappings
{
    public class BllAutomapperProfile : Profile
    {
        public BllAutomapperProfile()
        {
            CreateMap<PhotoModel, Photo>(MemberList.Source);
            CreateMap<Photo, PhotoModel>(MemberList.Source);
            CreateMap<UserModel, ProjectUser>(MemberList.Source);
            CreateMap<IdentityResult, IdentityResultModel>(MemberList.Source);
        }
    }
}
