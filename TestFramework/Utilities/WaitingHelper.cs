using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

using SeleniumExtras.WaitHelpers;

namespace TestFramework.Utilities
{
    public class WaitingHelper
    {
        public static void WaitForPageLoadingComplete(IWebDriver driver)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
            public void WaitForTextToBePresent(IWebDriver driver,IWebElement element, string text, int duration = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(duration));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }
        public static void ClickAndWaitForPageToLoad(IWebDriver driver, IWebElement element, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + element + "' was not found in current context page.");
                throw;
            }
        }
        public static bool ElementsIsPresent(IWebDriver driver, string elements, uint timeout = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(driver => driver.FindElements(By.XPath(elements)));
                return true;
            }
            catch { }
            return false;
        }
        public static bool ElementIsPresent(IWebDriver driver, string elements, uint timeout = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(driver => driver.FindElement(By.XPath(elements)));
                return true;
            }

            catch { }
            return false;
        }
    }
}
