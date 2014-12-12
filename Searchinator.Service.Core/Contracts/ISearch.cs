using Searchinator.Models;

namespace Searchinator.Core.Contracts
{
    public interface ISearch
    {
        string SearchFor(SearchQuery query);
    }
}