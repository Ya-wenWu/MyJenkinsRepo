using System;
using System.IO;
using NLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestJenkinsProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        string Iso8601Foramt = "yyyy-MM-dd";

        [TestMethod]
        public void LogDebugTest()
        {
            Logger.Warn("測試偵錯");
            Assert.IsTrue(File.Exists($"" +
                            $"C:\\temp\\log\\{DateTime.Now.ToString(Iso8601Foramt)}\\debug.log"));
        }

        [TestMethod]
        public void LogFatalTest()
        {
            Logger.Warn("測試嚴重錯誤");
            Assert.IsTrue(true);
        }
    }
}
