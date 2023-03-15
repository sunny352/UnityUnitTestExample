using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor.NotUseNUnit
{
    public static class TestRunner
    {
        private static List<TestSuite> TestSuites { get; } = new List<TestSuite>
        {
            new CalculatorTestSuite(),
        };
        
        [MenuItem("Tools/Run Tests")]
        public static void Run()
        {
            Debug.Log("TestRunner.Run() started.");
            foreach (var testSuite in TestSuites)
            {
                testSuite.Run();
            }
            Debug.Log("TestRunner.Run() finished.");
        }
    }
}