using NUnit.Framework;
using UnityEngine;

namespace Editor.UseNUnit
{
    [TestFixture]
    public class CalculatorTest
    {
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
            var result = _calculator.Add(1, 2);
            Assert.AreEqual(3, result);
        }
    }
}