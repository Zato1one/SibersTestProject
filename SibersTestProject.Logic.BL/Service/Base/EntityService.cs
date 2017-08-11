using SibersTestProject.Common.Model.Base;
using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.DAL.Entities.Base;
using SibersTestProject.Logic.Contracts.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.BL.Service.Base
{
    public class EntityService<TDto, TEntity> : ICrudService<TDto>
            where TDto : BaseModel
            where TEntity : BaseEntity
    {

        protected readonly IUnitOfWork UnitOfWork;

        public EntityService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public TDto GetById(Guid id)
        {
            var store = this.UnitOfWork.GetRepository<TEntity>().GetById(id);
            return AutoMapper.Mapper.Map<TDto>(store);
        }

        public List<TDto> GetAll()
        {
            var store = this.UnitOfWork.GetRepository<TEntity>().GetAll();
            return AutoMapper.Mapper.Map<List<TDto>>(store);
        }

        public void Save(TDto model)
        {
            var store = this.UnitOfWork.GetRepository<TEntity>().GetById(model.EntityId);

            if (store == null)
            {
                store = AutoMapper.Mapper.Map<TEntity>(model);
                this.UnitOfWork.GetRepository<TEntity>().Insert(store);
            }
            else
            {
                AutoMapper.Mapper.Map(model, store);
                this.UnitOfWork.GetRepository<TEntity>().Update(store);
            }

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(TDto model)
        {
            this.UnitOfWork.GetRepository<TEntity>().Delete(model.EntityId);
            this.UnitOfWork.SaveChanges();
        }

        public void Delete(Guid modelId)
        {
            this.UnitOfWork.GetRepository<TEntity>().Delete(modelId);
            this.UnitOfWork.SaveChanges();
        }
    }
}
