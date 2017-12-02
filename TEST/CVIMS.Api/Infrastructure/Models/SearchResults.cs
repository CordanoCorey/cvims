using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Models
{
    public interface ISearchResults<T>
    {
        IEnumerable<T> Results { get; set; }
        int Total { get; set; }
    }

    public class SearchResults<T> : ISearchResults<T>
    {
        public static ISearchResults<object> BuildGeneric(SearchResults<T> model)
        {
            IEnumerable<object> results = model.Results.Select(x => (object)x);
            return new SearchResults<object>()
            {
                Results = results,
                Total = model.Total
            };
        }
        public QueryModel<T> Query { get; set; }
        public IEnumerable<T> Results { get; set; }
        public int Total { get; set; }
    }
}
