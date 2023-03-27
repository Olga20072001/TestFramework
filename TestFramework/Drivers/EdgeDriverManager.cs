using OpenQA.Selenium.Edge;

namespace TestFramework.Drivers
{
    public class EdgeDriverManager : DriverManager
    {
        EdgeOptions _edgeOptions;
        EdgeDriverService _edgeDriverService;
        protected override void AddOptions()
        {
            throw new NotImplementedException();
        }

        protected override void CreateDriver()
        {
            driver = new EdgeDriver();
        }

        protected override void StartService()
        {
            _edgeDriverService = EdgeDriverService.CreateDefaultService();
        }

        protected override void StopService()
        {
            _edgeDriverService.Dispose();
        }
    }
}
