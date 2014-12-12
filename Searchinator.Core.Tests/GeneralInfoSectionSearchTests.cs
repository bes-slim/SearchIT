using Moq;
using Searchinator.Core.Contracts;
using Searchinator.Models;
using Xunit;

namespace Searchinator.Core.Tests
{
    public class GeneralInfoSectionSearchTests
    {
        [Fact]
        public void should_return_the_right_string_with_free_text()
        {
            // Arrange
            var query = new SearchQuery()
            {
                Text = "bla bla",
                GeneralInfo = new GeneralInfo()
                {
                    PriceTo = 200,
                    PriceFrom = 50000
                }
            };

            var mockPriceToRule = new Mock<IGeneralInfoSearchRule>();
            var mockPriceFromRule = new Mock<IGeneralInfoSearchRule>();

            mockPriceToRule.Setup(x => x.IsApplicable(query)).Returns(true);
            mockPriceFromRule.Setup(x => x.IsApplicable(query)).Returns(true);

            mockPriceToRule
                .Setup(x => x.AddGeneralInfoSearch(query))
                .Returns(PriceToRule.SEARCH_FOR_PRICE_TO+query.GeneralInfo.PriceTo);
            mockPriceFromRule
                .Setup(x => x.AddGeneralInfoSearch(query))
                .Returns(PriceFromRule.SEARCH_FOR_PRICE_FROM+ query.GeneralInfo.PriceFrom);
            
            // Act
            var sut = new GeneralInfoSectionSearch(new[] {mockPriceToRule.Object, mockPriceFromRule.Object});

            // Assert
            Assert.Equal(PriceToRule.SEARCH_FOR_PRICE_TO+query.GeneralInfo.PriceTo+PriceFromRule.SEARCH_FOR_PRICE_FROM + query.GeneralInfo.PriceFrom ,
                sut.SearchForGeneralInfo(query));
            
        }

        
    }
}
