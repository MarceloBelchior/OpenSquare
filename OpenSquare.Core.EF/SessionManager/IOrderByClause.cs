using System.Linq;

namespace OpenSquare.Core.EF.SessionManager
{
    public interface IOrderByClause<T> where T : class, new()
    {
        IOrderedQueryable<T> ApplySort(IQueryable<T> query, bool firstSort);
    }
}