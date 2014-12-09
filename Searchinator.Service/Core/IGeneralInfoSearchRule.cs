using Searchinator.Service.Models;

namespace Searchinator.Service.Core
{
    public interface IGeneralInfoSearchRule
    {
        bool IsApplicable(SearchQuery query);
        string AddGeneralInfoSearch(SearchQuery query);
        // TODO : add IsApplicableSection
    }
}