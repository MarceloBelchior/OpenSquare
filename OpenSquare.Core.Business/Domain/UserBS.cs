using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OpenSquare.Core.Business.Domain
{
    public class UserBS : Interface.IUserBS
    {
        public Model.Entity.User SaveOrUpdate(Model.Entity.User entity)
        {
            using (var repository = new OpenSquare.Core.EF.SessionManager.BaseRepository<Model.Entity.User>())
            {
                if (entity.id == 0)
                    repository.Insert(entity);
                else
                    repository.Update(entity);
            }
            return entity;
        }
        public ICollection<Model.Entity.User> GetUser(Expression<Func<Model.Entity.User, bool>> expression)
        {
            using (var repository = new EF.SessionManager.BaseRepository<Model.Entity.User>())
            {
                return repository.Select(expression).ToList();
            }
        }
        public Model.Entity.User GetById(Model.Entity.User entity)
        {
            using (var repository = new EF.SessionManager.BaseRepository<Model.Entity.User>())
            {
                Expression<Func<Model.Entity.User, bool>> expression = m => m.id == entity.id;
                return repository.Select(expression).SingleOrDefault();
            }
        }
    }
}
