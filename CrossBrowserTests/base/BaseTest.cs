using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject {
    //[Parallelizable(ParallelScope.Fixtures)]
    // [Parallelizable]
    //[ParallelScope.Self]
    [TestFixture]
[AllureNUnit]
[AllureDisplayIgnored]
class BaseTest
{
        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [TearDown]
        public void AfterTest()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                Console.WriteLine("Тест свалился");
                DriverManager.Instance.MakeScreenShot();


            }
            DriverManager.Instance.Destroy();
        }
    }
}
