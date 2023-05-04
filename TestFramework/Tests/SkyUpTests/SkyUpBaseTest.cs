using Atata;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.Drivers;
using TestFramework.PageObjects.Pages;

namespace TestFramework.Tests.SkyUpTests
{
    [TestFixture]
    public class SkyUpBaseTest
    {
        protected IWebDriver driver;
        DriverManager driverManager;
        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            driverManager = DriverManagerFactory.GetManager(DriverType.REMOTEFIREFOX);
            driver = driverManager.GetDriver();

            AtataContext.GlobalConfiguration
                .UseDriver(driver)
                .UseBaseUrl("https://skyup.aero/en/")
                .UseCulture("en-US")
                .UseAllNUnitFeatures()
                .Attributes.Global.Add(
                    new VerifyTitleSettingsAttribute { Format = "Flight booking, cheap airline tickets, cheap air flights - SkyUp Airlines" });

            AtataContext.GlobalConfiguration.AutoSetUpDriverToUse();
           
        }
        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure()
                .ScreenshotConsumers.AddFile()
                .WithDirectoryPath(() => $@"Screenshots\{AtataContext.BuildStart:yyyy-MM-dd HH_mm_ss}\{AtataContext.Current.TestName}")
                .WithFileName(screenshotInfo => $"{screenshotInfo.Number:D2} - {screenshotInfo.PageObjectFullName}{screenshotInfo.Title?.Prepend(" - ")}")
                .LogConsumers.AddNUnitTestContext()
                .WithoutSectionFinish()
                .WithMinLevel(Atata.LogLevel.Info)
                .LogConsumers.AddDebug()
                .WithMinLevel(Atata.LogLevel.Debug)  
                .Build();
        }
        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}
