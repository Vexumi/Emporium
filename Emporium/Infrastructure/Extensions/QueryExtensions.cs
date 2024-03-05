using Emporium.Infrastructure.Enums;
using Emporium.Models;
using System.Linq;

namespace Emporium.Infrastructure.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<Product> HandleSort(this IQueryable<Product> source, SortBy sortBy)
        {
            switch (sortBy)
            {
                case (SortBy.PriceAscending): return source.OrderBy(x => x.Price);
                case (SortBy.PriceDescending): return source.OrderByDescending(x => x.Price);
                case (SortBy.NameAscending): return source.OrderBy(x => x.Name);
                case (SortBy.NameDescending): return source.OrderByDescending(x => x.Name);
                default: return source;
            }
        }

        public static IQueryable<Product> HandleFilters(this IQueryable<Product> source, FilterBy filterBy, string filterDesc)
        {
            switch (filterBy)
            {
                case (FilterBy.NameContains): return source.Where(p => p.Name.Contains(filterDesc));
                case (FilterBy.NameDoesNotContain): return source.Where(p => !p.Name.Contains(filterDesc));
                case (FilterBy.CategoryContains): return source.Where(p => p.Category != null && p.Category.Contains(filterDesc));
                case (FilterBy.CategoryDoesNotContain): return source.Where(p => p.Category != null && !p.Category.Contains(filterDesc));
                default: return source;
            }
        }

        public static IQueryable<Product> ApplyFilters(this IQueryable<Product> source, SortBy sortBy, FilterBy filterBy, string filterDesc)
        {
            return source.HandleFilters(filterBy, filterDesc).HandleSort(sortBy);
        }
    }
}
