using EBusiness.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EBusiness.Helpers
{
    public class PaginatedList<T>:List<T>
    {
        public PaginatedList(List<T> values,int count,int pagesize,int page)
        {
            this.AddRange(values);
            TotalPage=(int)Math.Ceiling(count/(double)pagesize);
            Page=page;
        }

        public int TotalPage { get; set; }
        public int Page { get; set; }

        public bool HasPrevious { get => Page>1; }
        public bool HasNext { get => Page<TotalPage; }

        public static PaginatedList<T> Create(IQueryable<T> query,int page,int pagesize)
        {
            return new PaginatedList<T>(query.Skip((page-1)*pagesize).Take(pagesize).ToList(),query.Count(),pagesize,page);
        }

    }
}
