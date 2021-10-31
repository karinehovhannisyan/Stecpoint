using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stecpoint_Receiving_Service.Common.Pagination
{
    public static class Pagination
    {
        #region Methods

        public static async Task<PagedListHolder<T>> ToPagedAsync<T, TKey>(this IQueryable<T> query, int pageNumber, int pageSize, Expression<Func<T, TKey>> orderByKeySelector = null) where T : class
        {
            var count = await query.AsNoTracking().CountAsync();

            if (orderByKeySelector != null)
                query = query.OrderBy(orderByKeySelector);

            var lst = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();


            var pagedListHolderList = new PagedListHolder<T>(lst, pageSize, pageNumber, count);

            return pagedListHolderList;
        }

        #endregion
    }
}