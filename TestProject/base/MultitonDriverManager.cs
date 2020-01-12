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

        public MultitonDriverManager()
        {

        }
        //private static readonly object Lock = new object();

         public static IWebDriver GetDriver(string key)
        {
            //lock (Lock)
            {       
                    switch (key)
                    {

                    case "chrome":
                           return driverPool.GetOrAdd("chrome",  new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

                    case "explorer":
                        return driverPool.GetOrAdd("explorer", new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

                    case "firefox":
                        return driverPool.GetOrAdd("firefox" , new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

                    default: return driverPool.GetOrAdd("firefox", new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                }
                
                
              
            }

        }
    }
}
