using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test2222.Report
{
    public static class Reporter
    {
        public static ExtentReports extentReports;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest TestCase;

        public static void SetupExtentReport(string reportName, string documentTitle, dynamic Path)
        {
            extentReports = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter(Path);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = documentTitle;
            htmlReporter.Config.ReportName = reportName;
            extentReports.AttachReporter(htmlReporter);
        }

        public static void CreateTest(string testCaseName)
        {
            TestCase = extentReports.CreateTest(testCaseName);
        }

        public static void LogReport(Status status, string message)
        {
            TestCase.Log(status, message);
        }

        public static void FlushReport()
        {
            extentReports.Flush();
        }

        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                TestCase.Pass("Test is passed");
            }
            else
            {
                TestCase.Fail("Test case Fail");
            }
        }
    }
}
