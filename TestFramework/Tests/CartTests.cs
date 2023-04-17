using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static TestFramework.PageObjects.PageManager;

namespace TestFramework.Tests
{
    [AllureNUnit]
    [TestFixture]
    [AllureSuite("CartPageTests")]
    [AllureEpic("Shop tests")]
    public class CartTests : BaseTest
    {
        [Test]
        [AllureTag("Smoke")]
        public void AddProductToCart()
        {
            homePage.GoTo(baseUrl)
                .SearchByKeyword(keyword)
                .GetItemByIndex(0)
                .PressBuyButton();

            Assert.Multiple(() =>
            {
                Assert.That(cartPage.GetCartTitle().ToLower(), Is.EqualTo(cartTitle));
                Assert.That(cartPage.GetItemsCountInCart(), Is.EqualTo(1), "Number of items of the product is not 1");
            });
        }

        [Test]
        [AllureTag("Smoke")]
        public void AddProductsOnThePageToCart()
        {
            homePage.GoTo(baseUrl)
                .SearchByKeyword(keyword)
                .AddItemsToCart(5);
            Assert.That(cartPage.GetItemsCountInCart(), Is.EqualTo(5));
        }

        [Test]
        [AllureTag("Smoke")]
        public void DeleteProductFromCart()
        {
            homePage.GoTo(baseUrl)
                .SearchByKeyword(keyword)
                .GetItemByIndex(0)
                .PressBuyButton()
                .DeleteAllProductsFromCart();
                Assert.That(cartPage.EmptyCartMessageIsVisible(), Does.StartWith(emptyCartMessage));           
        }
    }
}
