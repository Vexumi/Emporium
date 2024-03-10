using Emporium.Infrastructure.Enums;
using Emporium.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System.CodeDom;
using System.Linq;
using System.Runtime.CompilerServices;

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
                case (FilterBy.FullnameContains): return source.Where(p => p.Seller != null && p.Seller.User.FullName.Contains(filterDesc));
                case (FilterBy.FullnameDoesNotContain): return source.Where(p => p.Seller != null && !p.Seller.User.FullName.Contains(filterDesc));

                default: return source;
            }
        }

        public static IQueryable<Product> ApplyFilters(this IQueryable<Product> source, SortBy sortBy, FilterBy filterBy, string filterDesc)
        {
            return source.HandleFilters(filterBy, filterDesc).HandleSort(sortBy);
        }

        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> source, SortBy sortBy, FilterBy filterBy, string filterDesc)
        {
            return source;
        }

        public static IQueryable<EntityType> ApplyOffset<EntityType>(this IQueryable<EntityType> source, int offset = 0, int takeCount = 20)
        {
            return source.Skip(offset).Take(takeCount);
        }
    }
}
