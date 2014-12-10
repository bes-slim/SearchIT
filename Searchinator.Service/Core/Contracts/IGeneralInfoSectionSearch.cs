using Searchinator.Service.Models;

namespace Searchinator.Service.Core.Contracts
{
    public interface IGeneralInfoSectionSearch
    {
        string SearchForGeneralInfo(SearchQuery query);
    }
}