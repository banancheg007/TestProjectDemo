using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    class BasePage
{
        public static IWebDriver Driver{ get { return DriverManager.CurrentDriver; } }

        protected void Navigate(String url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement GetWebElement(By locator)
        {
          return  Driver.FindElement(locator);
        }

       
        public void WaitForDisplayed(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

       

        public void Input(By locator , string text)
        {
            WaitForDisplayed(locator);
            GetWebElement(locator).SendKeys(text);
        }

        public void Submit(By locator)
        {
            GetWebElement(locator).Submit();
        }

        
    }
}

