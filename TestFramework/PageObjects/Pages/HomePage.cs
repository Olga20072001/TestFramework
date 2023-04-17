using OpenQA.Selenium;
using TestFramework.Utilities.Enums;
using static TestFramework.Utilities.WaitingHelper;

namespace TestFramework.PageObjects.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        private IWebElement searchField => LocateElement(LocatorType.Xpath, "//form[@data-is='Search']//input");
        private IWebElement searchButton => LocateElement(LocatorType.Xpath, "//form[@data-is='Search']//button");
        private IWebElement loginButton => LocateElement(LocatorType.Xpath, "//button[contains(@title,\"Увійти\")]");
        public HomePage GoTo(string url)
        {
            WaitForPageLoadingComplete(driver);
            GoToUrl(url);
            return new HomePage(driver);
        }
        public SearchResultsPage SearchByKeyword(string text)
        {
            searchField.SendKeys(text);
            searchButton.Click();
            return new SearchResultsPage(driver);
        }
        public LoginPage ClickLoginBtn()
        {
            loginButton.Click();
            return new LoginPage(driver);
        }


    }
}
