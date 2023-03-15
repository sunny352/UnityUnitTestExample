namespace Editor.NotUseNUnit
{
    public class TestSuite
    {
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
            SetupSuite();
            var methods = GetType().GetMethods();
            foreach (var methodInfo in methods)
            {
                var attributes = methodInfo.GetCustomAttributes(typeof(TestAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }
                
                SetupTest();
                methodInfo.Invoke(this, null);
                TearDownTest();
            }
            
            TearDownSuite();
        }
    }
}