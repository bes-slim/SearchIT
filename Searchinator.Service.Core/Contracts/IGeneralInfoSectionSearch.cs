using Searchinator.Models;

namespace Searchinator.Core.Contracts
{
    public interface IGeneralInfoSectionSearch
    {
        string SearchForGeneralInfo(SearchQuery query);
    }
}