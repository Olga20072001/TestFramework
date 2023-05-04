
namespace TestFramework.Drivers
{
    public class DriverManagerFactory
    {
        public static DriverManager GetManager(DriverType type)
        {
            DriverManager driverManager = type switch
            {
                DriverType.CHROME => new ChromeDriverManager(),
                DriverType.FIREFOX => new FirefoxDriverManager(),
                DriverType.EDGE => new EdgeDriverManager(),
                DriverType.REMOTECHROME => new RemoteChromeDriverManager(),
                DriverType.REMOTEFIREFOX => new RemoteFirefoxDriverManager(),
                _ => new ChromeDriverManager(),
            };
            return driverManager;
        }
    }
}
