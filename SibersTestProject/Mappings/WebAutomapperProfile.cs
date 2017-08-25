using AutoMapper;
using SibersTestProject.Model.Account;
using SibersTestProject.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SibersTestProject.Data.DAL.Identity.Entities;
using SibersTestProject.Model;
using SibersTestProject.Model.Photo;
using SibersTestProject.Model.Gallery;

namespace SibersTestProject.Mappings
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            //convert Web BLL

            //Account
            CreateMap<RegisterView, ProjectUser>(MemberList.Source);

            //Photo
            CreateMap<PhotoModel, PhotoView>(MemberList.Source);
            CreateMap<PhotoView, PhotoModel>(MemberList.Source);

            //Gallery
            CreateMap<GalleryModelWithoutImage, GalleryIndex>(MemberList.Source);
            CreateMap<GalleryCreate, GalleryModelWithoutImage>(MemberList.Source);
            CreateMap<GalleryModel, GalleryView>(MemberList.Source);
            CreateMap<PhotoModel, PhotoCheck>(MemberList.Source);
            CreateMap<PhotoCheck, PhotoView>(MemberList.Source);
            CreateMap<GalleryModel, GalleryCreatePhoto>(MemberList.Source);
            CreateMap<GalleryCreatePhoto, GalleryModel>(MemberList.Source);
            CreateMap<GalleryCreate,GalleryModel>(MemberList.Source);
            CreateMap<GalleryModel, GalleryCreate>(MemberList.Source);
        }
    }
}