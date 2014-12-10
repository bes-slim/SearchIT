using System.Collections.Generic;
using System.Linq;
using Searchinator.Service.Core.Contracts;
using Searchinator.Service.Models;

namespace Searchinator.Service.Core
{
    public class Search : ISearch
    {
        public const string CTOR_SEARCH_RULES_ARG_NAME = "searchRules";

        private readonly IList<IBaseSearchRule> _searchRules;
        public Search(IList<IBaseSearchRule> searchRules )
        {
            _searchRules = searchRules;
        }

        public string SearchFor(SearchQuery query)
        {
            string output = string.Empty;
            foreach (var baseSearchRule in _searchRules)
            {
                if (baseSearchRule.IsApplicable(query))
                    output+= baseSearchRule.AddToSearch(query);
            }

            return output;

            //return _searchRules
            //    .Where(searchRule => searchRule.IsApplicable(query))
            //    .Aggregate(string.Empty, (current, searchRule) => current + searchRule.AddToSearch(query));
        }
    }
}