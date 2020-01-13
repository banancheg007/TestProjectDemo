using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TestProject
{
    class MultitonDriverManager
    {
        private readonly static ConcurrentDictionary<string, IWebDriver> driverPool =
          new ConcurrentDictionary<string, IWebDriver>();

        public static IWebDriver driver;

        public MultitonDriverManager()
        {

        }
        //private static readonly object Lock = new object();

         public static IWebDriver GetDriver(string key)
        {
            //lock (Lock)
            {
                if (driver == null)
                    switch (key)
                    {
                    
                    case "chrome":
                            driver = driverPool.GetOrAdd("chrome", new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                            break;

                    case "explorer":
                            // return driverPool.GetOrAdd("explorer", new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                            driver = driverPool.GetOrAdd("explorer", new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                            break;
                        case "firefox":
                            //  return driverPool.GetOrAdd("firefox" , new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                            driver = driverPool.GetOrAdd("firefox", new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                            break;
                        default: driver =  driverPool.GetOrAdd("firefox", new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                            break;
                    }

                /*if (driver == null)
                {
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                }*/
                return driver;
                
                
              
            }

        }
    }
}
