using Searchinator.Service.Models;

namespace Searchinator.Service.Core
{
    public class PriceToRule : IGeneralInfoSearchRule
    {
        public const string SEARCH_FOR_PRICE_TO = "General Info :: Price To : ";

        public bool IsApplicable(SearchQuery query)
        {
            return query.GeneralInfo.PriceTo < 500000;
        }

        public string AddGeneralInfoSearch(SearchQuery query)
        {
            return SEARCH_FOR_PRICE_TO + query.GeneralInfo.PriceTo + "\n"; ;
        }
    }
}