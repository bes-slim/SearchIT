using Searchinator.Service.Models;

namespace Searchinator.Service.Core
{
    public interface IGeneralInfoSectionSearch
    {
        string SearchForGeneralInfo(SearchQuery query);
    }
}