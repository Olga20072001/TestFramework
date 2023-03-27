using OpenQA.Selenium;
using TestFramework.Drivers;
using TestFramework.Utilities.Enums;


namespace TestFramework.PageObjects.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void GoToUrl(string url) => driver.Navigate().GoToUrl(url);
        public string GetTitle() => driver.Title;
        public string GetText(IWebElement element) => element.Text;
        public IWebElement LocateElement(LocatorType type, string locator)
        {
            return type switch
            {
                LocatorType.Xpath => driver.FindElement(By.XPath(locator)),
                LocatorType.Id => driver.FindElement(By.Id(locator)),
                LocatorType.Name => driver.FindElement(By.Name(locator)),
                _ => throw new ArgumentOutOfRangeException(type.ToString(), $"Invalid Type, {type}")
            };
        }
        public IList<IWebElement> LocateElements(LocatorType type, string locator)
        {
            return type switch
            {
                LocatorType.Xpath => driver.FindElements(By.XPath(locator)),
                LocatorType.Id => driver.FindElements(By.Id(locator)),
                LocatorType.Name => driver.FindElements(By.Name(locator)),
                _ => throw new ArgumentOutOfRangeException(type.ToString(), $"Invalid Type, {type}")
            };
        }


    }
}
