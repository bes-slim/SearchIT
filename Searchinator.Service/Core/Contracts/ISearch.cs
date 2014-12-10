using Searchinator.Service.Models;

namespace Searchinator.Service.Core.Contracts
{
    public interface ISearch
    {
        string SearchFor(SearchQuery query);
    }
}