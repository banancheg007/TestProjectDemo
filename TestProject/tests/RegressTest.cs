using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.pages;
using TestProject.utils;

namespace TestProject.tests
{
    [Parallelizable]
    class RegressTest:BaseTest
    {
        private StartPage StartPage;
        private ResultPage ResultPage;

        [SetUp]
        public void BeforeTest()
        {
            StartPage = new StartPage();
            ResultPage = new ResultPage();
        }


        [Test]
        public void SearchTest()
        {
            StartPage.OpenUrl(Constants.GoogleUrl);
            StartPage.SearchByKeyWord(Constants.SearchString);
            Assert.That(ResultPage.GetWebElement(ResultPage.FirstResultText).Text, Does.Contain(Constants.SearchString).IgnoreCase);
        }


        [Test, TestCaseSource(typeof(Constants), "TestDatas")]
        public void SearchTestWithDataProvider(string text)
        {
            StartPage.OpenUrl(Constants.GoogleUrl);
            StartPage.SearchByKeyWord(text);
            Assert.That(ResultPage.GetWebElement(ResultPage.FirstResultText).Text, Does.Contain(text).IgnoreCase);
        }
    }
}
