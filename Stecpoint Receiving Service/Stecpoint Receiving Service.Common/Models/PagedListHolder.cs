using System.Collections.Generic;

namespace Stecpoint_Receiving_Service.Common.Pagination
{
    public class PagedListHolder<T>
    {
        public List<T> Items { get; }
        public int TotalRecords { get; }
        public int TotalPages { get; }
        public int PageNumber { get; }
        public int PageSize { get; }

        public PagedListHolder(List<T> items, int pageSize, int pageNumber, int totalRecords)
        {
            Items = items;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalRecords = totalRecords;
            TotalPages = PageSize > 0 ? ((TotalRecords % PageSize) == 0 ? TotalRecords / PageSize : (TotalRecords / PageSize) + 1) : TotalRecords;
        }
    }
}
