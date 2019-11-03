using System;
using System.Collections;
using NUnit.Framework;

namespace Open_Lab_05._05
{
    [TestFixture]
    public class Tests
    {

        private StringTools tools;

        private const int RandStrMinSize = 5;
        private const int RandStrMaxSize = 20;
        private const int RandSeed = 505505505;
        private const int RandTestCasesCount = 97;

        [OneTimeSetUp]
        public void Init() => tools = new StringTools();

        [TestCase("Hello", "HeLlO")]
        [TestCase("How are you?", "HoW aRe YoU?")]
        [TestCase("OMG this website is awesome!", "OmG tHiS wEbSiTe Is AwEsOmE!")]
        [TestCaseSource(nameof(GetRandom))]
        public void AlternatingCaps(string str, string expected) =>
            Assert.That(tools.AlternatingCaps(str), Is.EqualTo(expected));

        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arr = new char[rand.Next(RandStrMinSize, RandStrMaxSize + 1)];
                var altArr = new char[arr.Length];
                var shouldChange = false;

                for (var j = 0; j < arr.Length; j++)
                {
                    arr[j] = (char) rand.Next('a' - 1, 'z' + 1);

                    if (arr[j] == 'a' - 1)
                    {
                        arr[j] = ' ';
                        altArr[j] = ' ';
                        continue;
                    }

                    altArr[j] = shouldChange ? char.ToLower(arr[j]) : char.ToUpper(arr[j]);
                    shouldChange = !shouldChange;
                }

                yield return new TestCaseData(new string(arr), new string(altArr));
            }
        }

    }
}
