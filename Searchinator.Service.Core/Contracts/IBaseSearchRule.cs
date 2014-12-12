using Searchinator.Models;

namespace Searchinator.Core.Contracts
{
    public interface IBaseSearchRule
    {
        bool IsApplicable(SearchQuery query);
        string AddToSearch(SearchQuery query);
    }
}