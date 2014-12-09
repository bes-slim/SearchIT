using System.Collections.Generic;
using System.Linq;

namespace Searchinator.Core
{
    public class Search : ISearch
    {
        public const string CTOR_SEARCH_RULES_ARG_NAME = "seacrchRules";

        private readonly IList<IBaseSearchRule> _searchRules;
        public Search(IList<IBaseSearchRule> searchRules )
        {
            _searchRules = searchRules;
        }

        public string SearchFor(SearchQuery query)
        {
            return _searchRules
                .Where(searchRule => searchRule.IsApplicable(query))
                .Aggregate(string.Empty, (current, searchRule) => current + searchRule.AddToSearch(query));
        }
    }
}