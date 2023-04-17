using OpenQA.Selenium;
using TestFramework.Utilities.Enums;
using static TestFramework.Utilities.WaitingHelper;

namespace TestFramework.PageObjects.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        private IWebElement buyButton => LocateElement(LocatorType.Xpath, "//div[@class='p-buy']//button[contains(@class,'p-buy__btn')]");
        public CartPage PressBuyButton()
        {
            WaitForPageLoadingComplete(driver);
            buyButton.Click();
            return new CartPage(driver);
        }


    }
}
