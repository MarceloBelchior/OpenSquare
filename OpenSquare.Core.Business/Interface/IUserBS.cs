using System;
using System.Collections.Generic;

using System.Linq.Expressions;


namespace OpenSquare.Core.Business.Interface
{
    public interface IUserBS
    {
        Model.Entity.User SaveOrUpdate(Model.Entity.User entity);
        ICollection<Model.Entity.User> GetUser(Expression<Func<Model.Entity.User, bool>> expression);
        Model.Entity.User GetById(Model.Entity.User entity);
    }
}
