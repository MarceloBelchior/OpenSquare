using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace OpenSquare.Core.EF.SessionManager
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : class, new()
    {
        protected readonly Session context;

        //public BaseRepository()
        //{
        //    context = new Session();
        //}
        public BaseRepository()
        {
            context = new Session();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> where = null,
            IOrderByClause<TEntity>[] orderBy = null, int skip = 0, int top = 0, string[] include = null)
        {
            try
            {
                IQueryable<TEntity> data = context.Set<TEntity>();

                if (where != null)
                {
                    data = data.Where(where);
                }

                if (orderBy != null)
                {
                    bool isFirstSort = true;

                    orderBy.ToList().ForEach(one =>
                    {
                        data = one.ApplySort(data, isFirstSort);
                        isFirstSort = false;
                    });
                }

                if (skip > 0)
                {
                    data = data.Skip(skip);
                }
                if (top > 0)
                {
                    data = data.Take(top);
                }

                //if (include != null)
                //{
                //    include.ToList().ForEach(one => data = data.Include(one));
                //}

                foreach (TEntity item in data)
                {
                    yield return item;
                }
            }
            finally
            {
            }
        }

        //public virtual TEntity SelectById(long ID)
        //{
        //    try
        //    {
        //        return Context.Set<TEntity>().FirstOrDefault(C=> C<TEntity>..FirstOrDefault(c=>c<TEntity>.Property(Property.Name(di.Find(ID);
        //    }
        //    finally
        //    {
        //    }
        //}

        public virtual TEntity Insert(TEntity item, bool saveImmediately = true)
        {
            try
            {
                Microsoft.EntityFrameworkCore.DbSet<TEntity> set = context.Set<TEntity>();

                set.Add(item);

                if (saveImmediately)
                {
                    context.SaveChanges();
                }

                return item;
            }
            finally
            {
            }
        }

        public virtual TEntity Update(TEntity item, bool saveImmediately = true)
        {
            try
            {
                Microsoft.EntityFrameworkCore.DbSet<TEntity> set = context.Set<TEntity>();

                EntityEntry<TEntity> entry = context.Entry(item);

                if (entry != null)
                {
                    entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    set.Attach(item);

                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                if (saveImmediately)
                {
                    context.SaveChanges();
                }

                return item;
            }
            finally
            {
            }
        }

        public virtual void Remove(TEntity item)
        {
            Microsoft.EntityFrameworkCore.DbSet<TEntity> set = context.Set<TEntity>();
            set.Remove(item);

        }

        public virtual void Delete(TEntity item, bool saveImmediately = true)
        {
            try
            {
                Microsoft.EntityFrameworkCore.DbSet<TEntity> set = context.Set<TEntity>();
                EntityEntry<TEntity> entry = context.Entry(item);

                if (entry != null)
                {
                    entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                }
                else
                {
                    set.Attach(item);
                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                }

                if (saveImmediately)
                {
                    context.SaveChanges();
                }
            }
            finally
            {
            }
        }

        public virtual TEntity AttachWithAddState(TEntity item)
        {

            Microsoft.EntityFrameworkCore.DbSet<TEntity> set = context.Set<TEntity>();
            set.Attach(item);
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            return item;


        }

        public virtual TEntity Attach(TEntity item)
        {

            Microsoft.EntityFrameworkCore.DbSet<TEntity> set = context.Set<TEntity>();
            set.Attach(item);
            return item;


        }

        public virtual void Save()
        {
            context.SaveChanges();
            //Context.a
            //((IObjectContextAdapter)Context).ObjectContext.AcceptAllChanges();
        }

        ~BaseRepository()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
        }
    }
}