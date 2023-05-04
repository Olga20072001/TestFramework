using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Reflection.Metadata.Ecma335;

namespace TestFramework.Drivers
{
    public class RemoteChromeDriverManager : DriverManager
    {
        ChromeOptions chromeOptions;
        private string sauceUserName;
        private string sauceAccessKey;
        private Dictionary<string, object> sauceOptions;
        public TestContext TestContext { get; set; }
        protected override void AddOptions()
        {
            sauceUserName = "oauth-melnik662-c61a7";
            sauceAccessKey = "399834cc-dffe-4feb-b713-240bf24b1fe2";
            sauceOptions = new Dictionary<string, object>
            {
                ["username"] = sauceUserName,
                ["accessKey"] = sauceAccessKey
            };        
        }

        protected override void CreateDriver()
        {
            AddOptions();
            chromeOptions = new ChromeOptions
            {
                BrowserVersion = "latest",
                PlatformName = "Windows 10"
            };
            sauceOptions.Add("name", value: TestContext.CurrentContext.Test.Name);
            chromeOptions.AddAdditionalOption("sauce:options", sauceOptions);

            driver = new RemoteWebDriver(new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub"),
                chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
        }

        protected override void StartService()
        {
           throw new NotImplementedException(); 
        }

        protected override void StopService()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            var script = "sauce:job-result=" + (isPassed ? "passed" : "failed");
            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
    }
}
