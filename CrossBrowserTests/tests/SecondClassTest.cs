using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.tests
{
    [Ignore("skip")]
    [TestFixture]
    
    class SecondClassTest
    {
        [Parallelizable(ParallelScope.Self)]
        [Test]
        public void openComa()
        {
            DriverManager.CurrentDriver.Navigate().GoToUrl("https://comaqa.gitbook.io/selenium-webdriver-lectures/");
            DriverManager.CurrentDriver.Manage().Window.Size = new System.Drawing.Size(1327, 726);
            DriverManager.CurrentDriver.FindElement(By.CssSelector(".reset-3c756112--pageItemWithChildren-56f27afc:nth-child(1) .text-4505230f--UIH300-2063425d--textContentFamily-49a318e1--navButtonLabel-14a4968f")).Click();
            DriverManager.CurrentDriver.Close();
        }
    }
}
