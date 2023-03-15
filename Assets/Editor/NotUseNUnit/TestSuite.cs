using System;
using System.Collections.Generic;

namespace Editor.NotUseNUnit
{
    public class TestSuite
    {
        protected virtual List<Action> Tests { get; }

        protected virtual void SetupSuite()
        {
        }

        protected virtual void TearDownSuite()
        {
        }
    
        protected virtual void SetupTest()
        {
        }

        protected virtual void TearDownTest()
        {
        }

        public void Run()
        {
            if (null == Tests)
            {
                throw new Exception("Tests is null");
            }
        
            SetupSuite();
            foreach (var test in Tests)
            {
                SetupTest();
                test();
                TearDownTest();
            }
            TearDownSuite();
        }
    }
}