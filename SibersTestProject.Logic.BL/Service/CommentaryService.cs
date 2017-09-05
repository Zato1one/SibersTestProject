using AutoMapper;
using AutoMapper.QueryableExtensions;
using SibersTestProject.Common.Model;
using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Logic.BL.Service.Base;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.BL.Service
{
    public class CommentaryService : HostService<ICommentaryService>, ICommentaryService
    {
        public CommentaryService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
            : base(servicesHost, unitOfWork) {
        }
        public void CreateComment(CommentaryModel commentary)
        {
            if (!String.IsNullOrEmpty(commentary.Comment))
            {
                var dbCommentary = Mapper.Map<Commentary>(commentary);
                UnitOfWork.GetRepository<Commentary>().Insert(dbCommentary);
                UnitOfWork.SaveChanges();
            }
        }
        public ICollection<CommentaryModel> GetAllByPhotoId(Guid id)
        {
            var commentaryList = UnitOfWork.GetRepository<Photo>().SearchFor(a => a.EntityId == id)
                .SelectMany(b => b.Commentaries).Where(a=>!a.IsArchive).OrderByDescending(a=>a.DateCreated)
                .ProjectTo<CommentaryModel>().ToList();
            return commentaryList;
        }
        public void DeleteCommentary(Guid id)
        {
            UnitOfWork.GetRepository<Commentary>().Delete(id);
            UnitOfWork.SaveChanges();
        }
    }
}
