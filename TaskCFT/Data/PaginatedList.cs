using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace TaskCFT.Data
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public bool HasNextPage => PageIndex < TotalPages;

        public bool HasPreviousPage => PageIndex > 1;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> soure, int pageIndex, int pageSize)
        {
            var count = await soure.CountAsync();
            var items = await soure.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
