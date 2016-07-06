using System;
using System.Collections.Generic;

using System.Linq.Expressions;


namespace OpenSquare.Core.Business.Interface
{
    public interface IProfile
    {
        Model.Entity.Profile SaveOrUpdate(Model.Entity.Profile entity);
        ICollection<Model.Entity.Profile> GetProfile(Expression<Func<Model.Entity.Profile, bool>> expression);
        Model.Entity.Profile GetById(Model.Entity.Profile entity);
    }
}
