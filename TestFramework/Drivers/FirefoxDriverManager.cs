using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestFramework.Drivers
{
    public class FirefoxDriverManager : DriverManager
    {
        FirefoxOptions _firefoxOptions;
        FirefoxDriverService _firefoxDriverService;
        protected override void AddOptions()
        {
            _firefoxOptions = new FirefoxOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            var arguments = new List<string>
            {
                "--start-maximized",
            };
            _firefoxOptions.AddArguments(arguments);
        }

        protected override void CreateDriver()
        {
            AddOptions();
            driver = new FirefoxDriver(_firefoxDriverService,_firefoxOptions);
        }

        protected override void StartService()
        {
            _firefoxDriverService = FirefoxDriverService.CreateDefaultService("resources","geckodriver.exe"); 
        }

        protected override void StopService()
        {
            _firefoxDriverService.Dispose();
        }
    }
}
