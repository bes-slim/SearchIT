using Searchinator.Service.Models;

namespace Searchinator.Service.Core
{
    public interface IBaseSearchRule
    {
        bool IsApplicable(SearchQuery query);
        string AddToSearch(SearchQuery query);
    }
}