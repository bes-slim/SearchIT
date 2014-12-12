using Searchinator.Models;
using Searchinator.Core.Contracts;

namespace Searchinator.Core
{
    /// <summary>
    /// Adapter
    /// </summary>
    public class GeneralInfoSearch : IBaseSearchRule
    {

        private readonly IGeneralInfoSectionSearch _generalInfoSectionSearch;

        public GeneralInfoSearch(IGeneralInfoSectionSearch generalInfoSectionSearch)
        {
            _generalInfoSectionSearch = generalInfoSectionSearch;
        }

        public bool IsApplicable(SearchQuery query)
        {
            // TODO : not sure.  maybe IsApplicableSection?
            return query.GeneralInfo != null;
        }

        public string AddToSearch(SearchQuery query)
        {
            return _generalInfoSectionSearch.SearchForGeneralInfo(query);
        }
    }
}