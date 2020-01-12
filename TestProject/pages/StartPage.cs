using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestProject.utils;

namespace TestProject.pages
{
    class StartPage:BasePage
    {
        public By SearchField = By.Name("q");

        public void OpenUrl(string url)
        {
            Navigate(url);
        }


        public StartPage(string key) : base(key) { }

        public void SearchByKeyWord(string text)
        {
            Input(SearchField, text);
            Submit(SearchField);
        }

    }
}
