using Searchinator.Service.Models;

namespace Searchinator.Service.Core
{
    public interface ISearch
    {
        string SearchFor(SearchQuery query);
    }
}