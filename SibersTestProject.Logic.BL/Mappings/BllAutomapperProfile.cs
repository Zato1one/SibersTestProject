using AutoMapper;
using SibersTestProject.Common.Extensions;
using SibersTestProject.Common.Model;
using SibersTestProject.Data.DAL.Entities;
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
            //CreateMap<Gallery, GalleryModel>().IgnoreAllUnmapped().ReverseMap().IgnoreAllUnmapped();
            //CreateMap<Photo, PhotoModel>().IgnoreAllUnmapped();//.ReverseMap().IgnoreAllUnmapped();
            CreateMap<PhotoModel, Photo>(MemberList.Source);//.ReverseMap().IgnoreAllUnmapped();
            CreateMap<Photo, PhotoModel>(MemberList.Source);
        }
    }
}
