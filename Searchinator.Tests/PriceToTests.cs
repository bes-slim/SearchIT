using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Searchinator.Core;
using Xunit;

namespace Searchinator.Tests
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
            Assert.Equal("General Info :: Price To : 200", search.AddGeneralInfoSearch(query));

        }

        
    }
}
