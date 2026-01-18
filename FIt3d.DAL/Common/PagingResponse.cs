using Microsoft.EntityFrameworkCore;

namespace FIt3d.DAL.Common
{
    public class PagingResponse<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;

        public PagingResponse()
        {
        }

        public PagingResponse(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }
    }

    public static class PagingExtensions
    {
        public static async Task<PagingResponse<T>> ToPagingResponse<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize,
            int defaultPageNumber = 1)
        {
            pageNumber = pageNumber < 1 ? defaultPageNumber : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;

            var count = await source.CountAsync();
            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagingResponse<T>(items, count, pageNumber, pageSize);
        }
    }
}
