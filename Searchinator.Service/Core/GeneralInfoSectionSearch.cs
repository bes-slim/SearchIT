﻿using System.Collections.Generic;
using System.Linq;
using Searchinator.Service.Core.Contracts;
using Searchinator.Service.Models;

namespace Searchinator.Service.Core
{
    public class GeneralInfoSectionSearch : IGeneralInfoSectionSearch
    {
        public const string CTOR_GENERAL_INFO_SEARCH_RULES_ARG_NAME = "generalInfoSearchRules";

        private readonly IList<IGeneralInfoSearchRule> _generalInfoSearchRules;

        public GeneralInfoSectionSearch(IList<IGeneralInfoSearchRule> generalInfoSearchRules )
        {
            _generalInfoSearchRules = generalInfoSearchRules;
        }

        public string SearchForGeneralInfo(SearchQuery query)
        {
            var output = string.Empty;
            
            foreach (var generalInfoSearchRule in _generalInfoSearchRules)
            {
                if (generalInfoSearchRule.IsApplicable(query))
                    output += generalInfoSearchRule.AddGeneralInfoSearch(query);
            }

            return output;
            //return _generalInfoSearchRules.Where(x => x.IsApplicable(query))
            //    .Aggregate(string.Empty, (current, x) => current + x.AddGeneralInfoSearch(query));
        }
    }
}