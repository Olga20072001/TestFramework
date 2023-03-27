using OpenQA.Selenium;
using TestFramework.Utilities.Enums;
using TestFramework.Utilities;
using TestFramework.PageObjects.Pages;
using static TestFramework.Utilities.WaitingHelper;

namespace TestFramework.PageObjects.Pages
{
    public class SearchResultsPage : BasePage
    {
        CartPage cartPage;
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            cartPage = new CartPage(driver);
        }
 
        private IList<IWebElement> itemsList => LocateElements(LocatorType.Xpath, "//div[contains(@class,'columns product-Wrap card-wrapper')]//a[@class='card__photo']");
        private IList<IWebElement> buyBtnList => LocateElements(LocatorType.Xpath, "//button[contains(@class,'add-product card__button btn btn--yellow ')]");
        private IWebElement cartCounter => LocateElement(LocatorType.Xpath, "//div//span[@class='header__cart-counter']//.");
        public SearchResultsPage VerifySearcResultsContainsKeyword(string keyword)
        {
            var currentText = "";
            for (int i = 0; i < itemsList.Count; i++)
            {
                currentText = GetText(itemsList[i]);
                if (!currentText.Contains(keyword))
                    throw new Exception();
            }
            return this;
        }

        public ProductPage getItemByIndex(int index)
        {
            WaitForPageLoadingComplete(driver);
            itemsList.ElementAt(index).Click();
            return new ProductPage(driver);
        }
        public SearchResultsPage addItemsToCart(int count)
        {
            if (count <= itemsList.Count)
            {
                for (int i = 0; i <= count; i++)
                {
                    WaitForPageLoadingComplete(driver);
                    buyBtnList.ElementAt(i).Click();
                    cartPage.getCartTitle();
                    cartPage.closeCart();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            return new SearchResultsPage(driver);
        }        
           
        
    }
}
