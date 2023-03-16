using NUnit.Framework;
using UnityEngine;

namespace Editor.UseNUnit
{
    [TestFixture(1, 2, 3)]
    [TestFixture(4, 5, 9)]
    public class CalculatorTest
    {
        private readonly int _a;
        private readonly int _b;
        private readonly int _expected;
        public CalculatorTest(int a, int b, int expected)
        {
            _a = a;
            _b = b;
            _expected = expected;
        }
        private Calculator _calculator;

        [OneTimeSetUp]
        protected void SetupSuite()
        {
            Debug.Log("CalculatorTestSuite.SetupSuite()");
            _calculator = new Calculator();
        }

        [OneTimeTearDown]
        protected void TearDownSuite()
        {
            Debug.Log("CalculatorTestSuite.TearDownSuite()");
            _calculator = null;
        }
        
        [SetUp]
        protected void SetupTest()
        {
            Debug.Log("CalculatorTestSuite.SetupTest()");
        }
        
        [TearDown]
        protected void TearDownTest()
        {
            Debug.Log("CalculatorTestSuite.TearDownTest()");
        }

        [Test]
        public void TestAdd()
        {
            Debug.Log("CalculatorTestSuite.TestAdd()");
            var result = _calculator.Add(_a, _b);
            Assert.AreEqual(_expected, result);
        }
    }
}