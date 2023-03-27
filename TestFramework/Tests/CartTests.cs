using NUnit.Framework;
using static TestFramework.PageObjects.PageManager;

namespace TestFramework.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        string keyword = "Iphone";
        string cartTitle = "ваш кошик товарів";
        string emptyCartMessage = "Ваш кошик порожній.";

        [Test]
        public void AddProductToCart()
        {
            homePage.GoTo(baseUrl)
                .SearchByKeyword(keyword)
                .getItemByIndex(0)
                .pressBuyButton();

            Assert.Multiple(() =>
            {
                Assert.That(cartPage.getCartTitle().ToLower(), Is.EqualTo(cartTitle));
                Assert.That(cartPage.getItemsCountInCart(), Is.EqualTo(1), "Number of items of the product is not 1");
            });
        }

        [Test]
        public void AddProductsOnThePageToCart()
        {
            homePage.GoTo(baseUrl)
                .SearchByKeyword(keyword)
                .addItemsToCart(5);
            Assert.That(cartPage.getItemsCountInCart(), Is.EqualTo(5));
        }

        [Test]
        public void DeleteProductFromCart()
        {
            homePage.GoTo(baseUrl)
                .SearchByKeyword(keyword)
                .getItemByIndex(0)
                .pressBuyButton()
                .deleteAllProductsFromCart();
                Assert.That(cartPage.emptyCartMessageIsVisible(), Does.StartWith(emptyCartMessage));           
        }
    }
}
