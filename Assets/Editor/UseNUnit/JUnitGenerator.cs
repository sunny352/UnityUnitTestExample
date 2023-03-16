using System.Linq;
using System.Xml;
using UnityEditor.TestTools.TestRunner.Api;

namespace Editor.UseNUnit
{
    public static class JUnitGenerator
    {
        public static XmlDocument Generate(ITestResultAdaptor result)
        {
            var xmlDoc = new XmlDocument();
            var xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDecl);

            XmlNode rootNode = xmlDoc.CreateElement("testsuites");
            var rootAttrId = xmlDoc.CreateAttribute("id");
            rootAttrId.Value = result.Test.Id;
            rootNode.Attributes.Append(rootAttrId);
            var rootAttrName = xmlDoc.CreateAttribute("name");
            rootAttrName.Value = result.Test.Name;
            rootNode.Attributes.Append(rootAttrName);
            var rootAttrTests = xmlDoc.CreateAttribute("tests");
            rootAttrTests.Value = result.PassCount.ToString();
            rootNode.Attributes.Append(rootAttrTests);
            var rootAttrFailures = xmlDoc.CreateAttribute("failures");
            rootAttrFailures.Value = result.FailCount.ToString();
            rootNode.Attributes.Append(rootAttrFailures);
            var rootAttrTime = xmlDoc.CreateAttribute("time");
            rootAttrTime.Value = result.Duration.ToString();
            rootNode.Attributes.Append(rootAttrTime);
            xmlDoc.AppendChild(rootNode);
                
            foreach (var child in result.Children)
            {
                ProcessChild(xmlDoc, rootNode, rootNode, child);
            }
            return xmlDoc;
        }
        
        private static bool ProcessChild(XmlDocument xmlDoc, XmlNode rootNode, XmlNode current, ITestResultAdaptor result)
        {
            if (result.Children.Any())
            {
                var testSuiteNode = xmlDoc.CreateElement("testsuite");
                
                var isLeaf = false;
                foreach (var child in result.Children)
                {
                    isLeaf = ProcessChild(xmlDoc, rootNode, testSuiteNode, child) || isLeaf;
                }

                if (isLeaf)
                {
                    var testSuiteAttrId = xmlDoc.CreateAttribute("id");
                    testSuiteAttrId.Value = result.Test.Id;
                    testSuiteNode.Attributes.Append(testSuiteAttrId);
                    var testSuiteAttrName = xmlDoc.CreateAttribute("name");
                    testSuiteAttrName.Value = result.FullName;
                    testSuiteNode.Attributes.Append(testSuiteAttrName);
                    var testSuiteAttrTests = xmlDoc.CreateAttribute("tests");
                    testSuiteAttrTests.Value = result.PassCount.ToString();
                    testSuiteNode.Attributes.Append(testSuiteAttrTests);
                    var testSuiteAttrFailures = xmlDoc.CreateAttribute("failures");
                    testSuiteAttrFailures.Value = result.FailCount.ToString();
                    testSuiteNode.Attributes.Append(testSuiteAttrFailures);
                    var testSuiteAttrTime = xmlDoc.CreateAttribute("time");
                    testSuiteAttrTime.Value = result.Duration.ToString();
                    testSuiteNode.Attributes.Append(testSuiteAttrTime);
                    rootNode.AppendChild(testSuiteNode);
                }
                return false;
            }
            else
            {
                var testCaseNode = xmlDoc.CreateElement("testcase");
                var testCaseAttrId = xmlDoc.CreateAttribute("id");
                testCaseAttrId.Value = result.Test.Id;
                testCaseNode.Attributes.Append(testCaseAttrId);
                var testCaseAttrName = xmlDoc.CreateAttribute("name");
                testCaseAttrName.Value = result.FullName;
                testCaseNode.Attributes.Append(testCaseAttrName);
                var testCaseAttrTime = xmlDoc.CreateAttribute("time");
                testCaseAttrTime.Value = result.Duration.ToString();
                testCaseNode.Attributes.Append(testCaseAttrTime);
                if (result.TestStatus == TestStatus.Failed)
                {
                    var failureNode = xmlDoc.CreateElement("failure");
                    var failureAttrType = xmlDoc.CreateAttribute("type");
                    failureAttrType.Value = result.TestStatus.ToString();
                    failureNode.Attributes.Append(failureAttrType);
                    var failureAttrMessage = xmlDoc.CreateAttribute("message");
                    failureAttrMessage.Value = result.Message;
                    failureNode.Attributes.Append(failureAttrMessage);
                    failureNode.InnerText = result.StackTrace;
                    testCaseNode.AppendChild(failureNode);
                }
                current.AppendChild(testCaseNode);
                return true;
            }
        }
    }
}