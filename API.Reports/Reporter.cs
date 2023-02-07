using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace API.Reports
{
    public static class Reporter
    {
        public static ExtentReports extentReports;
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest testCase;

        public static void SetupExtentReport(string reportName, string documentTitle, dynamic path)
        {
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = documentTitle;
            htmlReporter.Config.ReportName = reportName;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extentReports = extent;
        }

        public static void CreateTest(string testName)
        {
            testCase = extentReports.CreateTest(testName);
        }

        public static void LogToReport(Status status, string message)
        {
            testCase.Log(status, message);
        }

        public static void FlushReport()
        {
            extentReports.Flush();
        }

        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                testCase.Pass("Test is passed");
            }
            else
            {
                testCase.Fail("Test if failed");
            }

        }
    }
}
