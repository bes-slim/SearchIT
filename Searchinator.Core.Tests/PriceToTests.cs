using Searchinator.Core;
using Searchinator.Models;
using Xunit;

namespace Searchinator.Service.Tests
{
    public class PriceToTests
    {
        [Fact]
        public void should_return_true_if_price_is_under_500000()
        {
            var query = new SearchQuery() {GeneralInfo = new GeneralInfo() {PriceTo = 200}};
            var search = new PriceToRule();
            Assert.True(search.IsApplicable(query));
        }

        [Fact]
        public void should_return_true_if_price_is_over_500000()
        {
            var query = new SearchQuery() { GeneralInfo = new GeneralInfo() { PriceTo = 600000 } };
            var search = new PriceToRule();
            Assert.False(search.IsApplicable(query));
        }

        [Fact]
        public void should_return_General_Info_Price_To()
        {
            var query = new SearchQuery() { GeneralInfo = new GeneralInfo() { PriceTo = 200 } };
            var search = new PriceToRule();
            Assert.Equal(PriceToRule.SEARCH_FOR_PRICE_TO + query.GeneralInfo.PriceTo + "\n", search.AddGeneralInfoSearch(query));

        }

        
    }
}
