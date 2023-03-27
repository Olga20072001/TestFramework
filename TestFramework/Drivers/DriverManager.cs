using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Drivers
{
    public abstract class DriverManager
    {         
        public static IWebDriver driver;
        protected abstract void StartService();
        protected abstract void StopService();
        protected abstract void CreateDriver();
        protected abstract void AddOptions();

        public void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public IWebDriver GetDriver()
        {
            if (driver == null)
            {
                StartService();
                CreateDriver();
            }
            return driver;
        }
    }
}
