using System;
using System.Linq;
using System.Linq.Expressions;

namespace OpenSquare.Core.EF.SessionManager
{
    public class OrderByClause<T, TProperty> : IOrderByClause<T> where T : class, new()
    {
        private OrderByClause()
        {
        }

        public OrderByClause(
            Expression<Func<T, TProperty>> orderBy,
            SortDirection sortDirection = SortDirection.Ascending)
        {
            OrderBy = orderBy;
            SortDirection = sortDirection;
        }

        private Expression<Func<T, TProperty>> OrderBy { get; set; }

        private SortDirection SortDirection { get; set; }

        public IOrderedQueryable<T> ApplySort(IQueryable<T> query, bool firstSort)
        {
            if (SortDirection == SortDirection.Ascending)
            {
                return firstSort ? query.OrderBy(OrderBy) : ((IOrderedQueryable<T>)query).ThenBy(OrderBy);
            }
            else
            {
                return firstSort
                    ? query.OrderByDescending(OrderBy)
                    : ((IOrderedQueryable<T>)query).ThenByDescending(OrderBy);
            }
        }
    }
}