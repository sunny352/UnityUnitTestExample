using UnityEditor;
using UnityEngine;

namespace Editor.NotUseNUnit
{
    public static class TestRunner
    {
        [MenuItem("Tools/Run Tests")]
        public static void Run()
        {
            var result = Calculator.Add(1, 2);
            Assert.AreEqual(3, result);
            
            Debug.Log("TestRunner.Run() finished.");
        }
    }
}