using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.pages
{
    class ResultPage:BasePage
    {
        public By SearchField = By.Name("q");
        public By ResultCounter = By.Id("resultStats");
        public By FirstResultText = By.ClassName("st");

    }
}
