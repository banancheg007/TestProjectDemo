using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.pages;
using TestProject.utils;

namespace TestProject.tests
{
    [TestFixture("chrome")]
    [Parallelizable]
    class RegressTest:BaseTest
    {
        string key;
        private StartPage StartPage;
        private ResultPage ResultPage;

        public RegressTest(string key)
        {
            this.key = key;
        }

        [SetUp]
        public void BeforeTest()
        {
            StartPage = new StartPage(key);
            //ResultPage = new ResultPage(key);
        }


        [Test]
        public void SearchTest()
        {
            StartPage.OpenUrl(Constants.GoogleUrl);
            StartPage.SearchByKeyWord(Constants.SearchString);
            Assert.That(ResultPage.GetWebElement(ResultPage.FirstResultText).Text, Does.Contain(Constants.SearchString).IgnoreCase);
        }

        [Ignore("skip")]
        [Test, TestCaseSource(typeof(Constants), "TestDatas")]
        public void SearchTestWithDataProvider(string text)
        {
            StartPage.OpenUrl(Constants.GoogleUrl);
            StartPage.SearchByKeyWord(text);
            Assert.That(ResultPage.GetWebElement(ResultPage.FirstResultText).Text, Does.Contain(text).IgnoreCase);
        }
    }
}
