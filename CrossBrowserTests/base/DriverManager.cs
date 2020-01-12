using Allure.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace TestProject
{

    public sealed class DriverManager
    {
        private static readonly ThreadLocal<DriverManager> threadLocal =
                new ThreadLocal<DriverManager>(() => new DriverManager());
        private static readonly object ThreadLock = new object();
        private IWebDriver _driver;

        public static DriverManager Instance { get { return threadLocal.Value; } }




        public EventFiringWebDriver GetDriver()
        {
            if (_driver == null)
            {
                lock (ThreadLock)
                {
                    if (_driver == null)
                        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                        //_driver = new ChromeDriver();
                }
            }
            EventFiringWebDriver eventsDriver = new EventFiringWebDriver(_driver);
            return eventsDriver;
        }


        public void Destroy()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Quit();
                _driver = null;
            }
        }

        public static IWebDriver CurrentDriver

        {
            get { return Instance.GetDriver(); }
        }

        public void MakeScreenShot()
        {
            AllureLifecycle.Instance.AddAttachment($"Screenshot [{DateTime.Now:HH:mm:ss}]",
                 "image/png",
                 _driver.TakeScreenshot().AsByteArray);
        }


        ~DriverManager()

        {
            Destroy();
        }
    }

}