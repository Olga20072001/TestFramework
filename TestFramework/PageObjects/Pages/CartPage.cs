using OpenQA.Selenium;
using TestFramework.Utilities;
using TestFramework.Utilities.Enums;
using static TestFramework.Utilities.WaitingHelper;

namespace TestFramework.PageObjects.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private IWebElement cartTitle => LocateElement(LocatorType.Xpath, "//p[@class='headline headline--level2-bold basket__headline']");
        private IList<IWebElement> cartItems => LocateElements(LocatorType.Xpath, "//div[@class='basket-products__group-item']");
        private IList<IWebElement> deleteProductFromCartBtn => LocateElements(LocatorType.Xpath, "//button[@class='basket-product__del--link']");
        private IWebElement emptyCartMassage => LocateElement(LocatorType.Xpath, "//p[@class='basket-empty__message']");
        private IWebElement goToProductListBtn => LocateElement(LocatorType.Xpath, "//p[@class='basket-empty__message']//a");
        private IWebElement closeCartBth => LocateElement(LocatorType.Xpath, "//div[contains(@class,'cart-popup')]//button[@title='Close']");

        public string getCartTitle()
        {
            WaitForPageLoadingComplete(driver);
            ElementsIsPresent(driver, "//p[@class='headline headline--level2-bold basket__headline']");
            return GetText(cartTitle);
        }
        public uint getItemsCountInCart()
        {
            WaitForPageLoadingComplete(driver);
            ElementIsPresent(driver, "//div[@class='basket-products__group-item']");
            return (uint)cartItems.Count;
        }
        public CartPage deleteAllProductsFromCart()
        {
            for(int i=0;i<cartItems.Count;i++)
            {
                deleteProductFromCartBtn[i].Click();
            }
            return new CartPage(driver);
        }
        public string emptyCartMessageIsVisible()
        {
            return GetText(emptyCartMassage);
        }
        public SearchResultsPage closeCart()
        {
            ClickAndWaitForPageToLoad(driver, closeCartBth);
            return new SearchResultsPage(driver);
        }

    }
}
