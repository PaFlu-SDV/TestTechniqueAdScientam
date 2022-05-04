using TestTechnique.Domain.Models;
using Xunit;

namespace TestTechnique.Domain.Test.Models
{

    public class ProductTest
    {
        [Fact]
        public void Product_Are_Equals()
        {
            // Arrange
            var productA = new Product { Name = "hWLpaHV" };
            var productB = new Product { Name = "hWLpaHV" };

            // Act
            var result = productA.Equals(productB);

            // Assert
            Assert.True(result);
            Assert.Equal(productA, productB);
        }
    }
}