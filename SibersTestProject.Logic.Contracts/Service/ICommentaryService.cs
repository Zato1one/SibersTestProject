using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.Contracts.Service
{
    public interface ICommentaryService : IService
    {
        void CreateComment(CommentaryModel commentary);
        ICollection<CommentaryModel> GetAllByPhotoId(Guid photoId);
        void DeleteCommentary(Guid commentId);
    }
}
