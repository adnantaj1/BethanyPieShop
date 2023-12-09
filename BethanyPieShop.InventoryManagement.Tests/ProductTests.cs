using BethanyPieShop.InventoryManagement.Domain.General;
using BethanyPieShop.InventoryManagement.Domain.ProductManagement;

namespace BethanyPieShop.InventoryManagement.Tests
{
    public class ProductTests
    {
        [Fact]
        public void UseProduct_Reduces_AmountInStock()
        {
            //Arrange
            Product product = new(1, "Sugar", "Lorem ispum", new Price() 
            {ItemPrice =10, Currency= Currency.Euro}, UnitType.PerKg,100);

            product.IncreaseStock(100);

            //Act

            product.UseProduct(20);

            //Assert
            Assert.Equal(80, product.AmountInStock);
        }
        [Fact]
        public void UseProduct_ItemHigherThanStock_NoChangeStock()
        {
            //Arrange
            Product product = new(1, "Sugar", "Lorem ispum", new Price()
            { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);

            product.IncreaseStock(10);

            //Act

            product.UseProduct(20);

            //Assert
            Assert.Equal(10, product.AmountInStock);
        }

        [Fact]
        public void UseProduct_Reduces_AmountInStock_StockBelowThreshold()
        {
            //Arrange
            Product product = new(1, "Sugar", "Lorem ispum", new Price()
            { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);

           int IncreaseValue = 100;
            product.IncreaseStock(IncreaseValue);

            //Act

            product.UseProduct(IncreaseValue - 1);

            //Assert
            Assert.True(product.IsBelowStockTreshold);
        }
    }
}