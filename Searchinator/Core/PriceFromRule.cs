namespace Searchinator.Core
{
    public class PriceFromRule : IGeneralInfoSearchRule
    {
        public const string SEARCH_FOR_PRICE_FROM = "General Info :: Price from : ";

        public bool IsApplicable(SearchQuery query)
        {
            return query.GeneralInfo.PriceFrom > 0;
        }

        public string AddGeneralInfoSearch(SearchQuery query)
        {
            return SEARCH_FOR_PRICE_FROM + query.GeneralInfo.PriceFrom + "\n";
        }
    }
}