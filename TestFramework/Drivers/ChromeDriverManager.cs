using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestFramework.Drivers
{
    public class ChromeDriverManager : DriverManager
    {
        ChromeDriverService _chromeDriverService;
        ChromeOptions _chromeOptions;

        protected override void CreateDriver()
        {
            AddOptions();
            driver = new ChromeDriver(_chromeDriverService,_chromeOptions);
        }

        protected override void StartService()
        {
            if (_chromeDriverService == null)
            {
                _chromeDriverService = ChromeDriverService.CreateDefaultService();
            }
        }

        protected override void StopService()
        {
            _chromeDriverService.Dispose();
        }

        protected override void AddOptions()
        {
            _chromeOptions = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            var arguments = new List<string>
            {
                "start-maximized",
                "ignore-certificate-errors",
            };

            _chromeOptions.AddArguments(arguments);
        }
    }
}
