using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.Drivers;
using TestFramework.PageObjects;

namespace TestFramework.Tests
{

    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        DriverManager driverManager;

        protected string baseUrl = "https://epicentrk.ua/";
        protected string homePageTitle = "Епіцентр • Національна мережа торговельних центрів";


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driverManager = DriverManagerFactory.GetManager(DriverType.CHROME);
        }
        [SetUp]
        public void Setup() 
        { 
            driver = driverManager.GetDriver();
            PageManager.Init(driver);
        }

        [TearDown]
        public void OneTimeTearDown() => driverManager.QuitDriver();

    }
}  
   
