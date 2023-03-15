using UnityEngine;

namespace Editor.NotUseNUnit
{
    public class CalculatorTestSuite : TestSuite
    {
        private Calculator _calculator;

        protected override void SetupSuite()
        {
            Debug.Log("CalculatorTestSuite.SetupSuite()");
            _calculator = new Calculator();
        }

        protected override void TearDownSuite()
        {
            Debug.Log("CalculatorTestSuite.TearDownSuite()");
            _calculator = null;
        }
        
        protected override void SetupTest()
        {
            Debug.Log("CalculatorTestSuite.SetupTest()");
        }
        
        protected override void TearDownTest()
        {
            Debug.Log("CalculatorTestSuite.TearDownTest()");
        }

        public void TestAdd()
        {
            Debug.Log("CalculatorTestSuite.TestAdd()");
            var result = _calculator.Add(1, 2);
            Assert.AreEqual(3, result);
        }
    }
}