using NUnit.Framework;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

namespace Editor.UseNUnit
{
    [SetUpFixture]
    public class Global
    {
        [OneTimeSetUp]
        public void Setup()
        {
            var api = ScriptableObject.CreateInstance<TestRunnerApi>();
            api.RegisterCallbacks(new Callback());
        }
        
        [OneTimeTearDown]
        public void TearDown()
        {
            
        }
    }
}