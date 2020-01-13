using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestProject.utils
{
    class Constants
    {
        public const string GoogleUrl = "https://www.google.com";
        public const string SearchString = "TeXT";
        public const string AboutGoogleCompanyUrl = "https://about.google/";


        public static IEnumerable TestDatas
        {
            get
            {
                yield return new TestCaseData("cat");
                yield return new TestCaseData("dog");
                yield return new TestCaseData("monkey");
                yield return new TestCaseData("cow");
                yield return new TestCaseData("pig");
                yield return new TestCaseData("mouse");
            }
        }
    }
}
