using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Drivers
{
    public class RemoteFirefoxDriverManager : DriverManager
    {
        FirefoxOptions firefoxOptions;
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
            firefoxOptions = new FirefoxOptions
            {
                BrowserVersion = "latest",
                PlatformName = "Windows 10"
            };
            sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);
            firefoxOptions.AddAdditionalOption("sauce:options", sauceOptions);

            driver = new RemoteWebDriver(new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub"),
                firefoxOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
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
