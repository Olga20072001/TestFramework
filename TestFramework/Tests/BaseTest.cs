using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Serilog;
using TestFramework.Drivers;
using TestFramework.PageObjects;

namespace TestFramework.Tests
{
    [AllureNUnit]
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        DriverManager driverManager;

        protected string baseUrl = "https://epicentrk.ua/";
        protected string homePageTitle = "Епіцентр • Національна мережа торговельних центрів";
        protected string keyword = "Iphone";
        protected string cartTitle = "ваш кошик товарів";
        protected string emptyCartMessage = "Ваш кошик порожній.";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driverManager = DriverManagerFactory.GetManager(DriverType.CHROME);
        }
        [SetUp]
        public void Setup() 
        {

              Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, rollingInterval: RollingInterval.Day)
                .WriteTo.File("logs/errorLog.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)
                .CreateLogger();
            
            driver = driverManager.GetDriver();
            PageManager.Init(driver);
            Log.Information("SetUp()");
            Log.Information("Init browser");
        }
        
        [TearDown]
        public void OneTimeTearDown()
        {
            byte[] content = ((ITakesScreenshot) driver).GetScreenshot().AsByteArray;
            if(TestContext.CurrentContext.Result.Outcome!=ResultState.Success)
            {
                AllureLifecycle.Instance.AddAttachment("Failed Screenshot", "image/png", content);
            }
            else
            {
                AllureLifecycle.Instance.AddAttachment("Screenshot", "image/png", content);
            }
            driverManager.QuitDriver();
            Log.CloseAndFlush();
        }

    }
}  
   
