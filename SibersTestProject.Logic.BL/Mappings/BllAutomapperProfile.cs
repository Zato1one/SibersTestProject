using AutoMapper;
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
            //convert BLL DAL

            //Photo
            CreateMap<PhotoModel, Photo>(MemberList.Source);
            CreateMap<Photo, PhotoModel>(MemberList.Source);

            //Gallery
            CreateMap<Gallery, GalleryModelWithoutImage>(MemberList.Source);
            CreateMap<GalleryModelWithoutImage, Gallery>(MemberList.Source);
            CreateMap<Gallery, GalleryModel>(MemberList.Source);
            CreateMap<Gallery, GalleryModelWithUserName>(MemberList.Source)
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            //Commentary
            CreateMap<Commentary, CommentaryModel>(MemberList.Source)
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<CommentaryModel, Commentary>(MemberList.Source);




            CreateMap<GalleryModel, Gallery>(MemberList.Source);

        }
    }
}
