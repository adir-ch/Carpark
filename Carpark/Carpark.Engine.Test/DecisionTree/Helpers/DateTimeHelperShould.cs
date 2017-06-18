using Carpark.Engine.DecisionTree.Helpers;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.Test.DecisionTree.Helpers
{
    [TestFixture]
    public class DateTimeHelperShould
    {
        [Test, TestCaseSource(typeof(IsNightTestCases), "TestCases")]
        public bool CheckIfQualifyForNightRate(DateTime enter, DateTime exit)
        {
            return DateTimeHelper.IsNight(enter, exit); 
        }

        [Test, TestCaseSource(typeof(IsEarlyBirdTestCases), "TestCases")]
        public bool CheckIfQualifyForEarlyBirdRate(DateTime enter, DateTime exit)
        {
            return DateTimeHelper.IsEarlyBird(enter, exit);
        }

        [Test, TestCaseSource(typeof(IsWeekendTestCases), "TestCases")]
        public bool CheckIfQualifyForWeekendRate(DateTime enter, DateTime exit)
        {
            return DateTimeHelper.IsWeekend(enter, exit);
        }
    }

    public class IsNightTestCases
    {
        public static IEnumerable TestCases
        {
            get 
            {
                yield return new TestCaseData(new DateTime(2017, 01, 01, 18, 0, 0), new DateTime(2017, 01, 02, 6, 00, 00)).Returns(false);
                yield return new TestCaseData(new DateTime(2017, 01, 01, 18, 0, 0), new DateTime(2017, 01, 02, 5, 59, 59)).Returns(true);
                yield return new TestCaseData(new DateTime(2017, 01, 01, 17, 59, 59), new DateTime(2017, 01, 02, 5, 00, 00)).Returns(false); 
            }
        }
    }

    public class IsEarlyBirdTestCases
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2017, 01, 01, 7, 0, 0), new DateTime(2017, 01, 02, 16, 00, 00)).Returns(false);
                yield return new TestCaseData(new DateTime(2017, 01, 01, 6, 0, 0), new DateTime(2017, 01, 01, 23, 30, 01)).Returns(false);
                yield return new TestCaseData(new DateTime(2017, 01, 01, 5, 59, 59), new DateTime(2017, 01, 01, 15, 00, 01)).Returns(false);
                yield return new TestCaseData(new DateTime(2017, 01, 01, 06, 01, 00), new DateTime(2017, 01, 01, 16, 00, 00)).Returns(true);
            }
        }
    }

    public class IsWeekendTestCases
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2017, 01, 07, 0, 0, 1), new DateTime(2017, 01, 17, 16, 00, 00)).Returns(false);
                yield return new TestCaseData(new DateTime(2017, 01, 07, 6, 0, 0), new DateTime(2017, 01, 09, 00, 00, 00)).Returns(false);
                yield return new TestCaseData(new DateTime(2017, 01, 06, 23, 59, 59), new DateTime(2017, 01, 08, 15, 00, 01)).Returns(false);
                yield return new TestCaseData(new DateTime(2017, 01, 07, 06, 01, 00), new DateTime(2017, 01, 08, 23, 59, 59)).Returns(true);
                yield return new TestCaseData(new DateTime(2017, 01, 07, 00, 00, 00), new DateTime(2017, 01, 08, 23, 59, 59)).Returns(true);
            }
        }
    }
}