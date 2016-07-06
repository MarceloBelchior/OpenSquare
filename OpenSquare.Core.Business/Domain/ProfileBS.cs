using OpenSquare.Core.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OpenSquare.Core.Business.Domain
{
    public class ProfileBS : IProfile
    {
        public Model.Entity.Profile SaveOrUpdate(Model.Entity.Profile entity)
        {
            using (var repository = new OpenSquare.Core.EF.SessionManager.BaseRepository<Model.Entity.Profile>())
            {
                if (entity.id == 0)
                    repository.Insert(entity);
                else
                    repository.Update(entity);
            }
            return entity;
        }
        public ICollection<Model.Entity.Profile> GetProfile(Expression<Func<Model.Entity.Profile, bool>> expression)
        {
            using (var repository = new EF.SessionManager.BaseRepository<Model.Entity.Profile>())
            {
                return repository.Select(expression).ToList();
            }
        }
        public Model.Entity.Profile GetById(Model.Entity.Profile entity)
        {
            using (var repository = new EF.SessionManager.BaseRepository<Model.Entity.Profile>())
            {
                Expression<Func<Model.Entity.Profile, bool>> expression = m => m.id == entity.id;
                return repository.Select(expression).SingleOrDefault();
            }
        }
    }
}
