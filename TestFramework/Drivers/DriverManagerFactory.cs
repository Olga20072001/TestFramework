using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _ => new ChromeDriverManager(),
            };
            return driverManager;
        }
    }
}
