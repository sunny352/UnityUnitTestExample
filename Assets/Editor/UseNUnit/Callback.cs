using System;
using UnityEditor.TestTools.TestRunner.Api;

namespace Editor.UseNUnit
{
    public class Callback : ICallbacks
    {
        public void RunStarted(ITestAdaptor testsToRun)
        {
        }

        public void RunFinished(ITestResultAdaptor result)
        {
            var reportPath = string.Empty;
            var args = Environment.GetCommandLineArgs();
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] != "-junit")
                {
                    continue;
                }
                
                reportPath = args[i + 1];
                break;
            }
            if (string.IsNullOrEmpty(reportPath)) {
                reportPath = "junit.xml";
            }
            
            var xmlDoc = JUnitGenerator.Generate(result);
            
            xmlDoc.Save(reportPath);
        }

        public void TestStarted(ITestAdaptor test)
        {
        }

        public void TestFinished(ITestResultAdaptor result)
        {
        }
    }
}