using Searchinator.Models;

namespace Searchinator.Core.Contracts
{
    public interface IGeneralInfoSearchRule
    {
        bool IsApplicable(SearchQuery query);
        string AddGeneralInfoSearch(SearchQuery query);
        // TODO : add IsApplicableSection
    }
}