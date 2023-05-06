using Allure.Commons;
using Newtonsoft.Json;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Serilog;
using System.Configuration;
using System.Net;
using TestFramework.Drivers;
using TestFramework.PageObjects;
using TestRail;
using TestRail.Types;


namespace TestFramework.Tests
{
    [AllureNUnit]
    public class BaseTest
    {
        protected IWebDriver driver;
        DriverManager driverManager;

        public static TestRailClient Client;
        private static readonly string Url = ConfigurationManager.AppSettings["url"];
        private static readonly string User = ConfigurationManager.AppSettings["username"];
        private static readonly string Password = ConfigurationManager.AppSettings["password"];

        protected string baseUrl = "https://epicentrk.ua/";
        protected string homePageTitle = "Епіцентр • Національна мережа торговельних центрів";
        protected string keyword = "Iphone";
        protected string cartTitle = "ваш кошик товарів";
        protected string emptyCartMessage = "Ваш кошик порожній.";


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            driverManager = DriverManagerFactory.GetManager(DriverType.CHROME);
            driver = driverManager.GetDriver();
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
            
            PageManager.Init(driver);
            Log.Information("SetUp()");
            Log.Information("Init browser");
        }
        
        [TearDown]
        public void OneTimeTearDown()
        {
            byte[] content = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
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
   
