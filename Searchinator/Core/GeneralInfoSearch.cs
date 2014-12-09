using System;

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
            // TODO : not sure.  IsApplicableSection?
            return query.GeneralInfo != null;
        }

        public string AddToSearch(SearchQuery query)
        {
            return _generalInfoSectionSearch.SearchForGeneralInfo(query);
        }
    }
}