using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Editor.NotUseNUnit
{
    public static class TestRunner
    {
        [MenuItem("Tools/Run Tests")]
        public static void Run()
        {
            Debug.Log("TestRunner.Run() started.");
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var attributes = type.GetCustomAttributes(typeof(TestSuiteAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }
            
                var testSuite = (TestSuite) Activator.CreateInstance(type);
                testSuite.Run();
            }
            Debug.Log("TestRunner.Run() finished.");
        }
    }
}