using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1 : SessionSetup
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Create session to launch a Calculator window
            SessionSetup.Setup(context);

        }

    }
    
    public class SessionSetup
    {
        private const string AppId = @"C:\Users\monub\Desktop\WindowsFormsApp1\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\WindowsFormsApp1.exe";
        protected static WindowsDriver<WindowsElement> session;
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/wd/hub";
        

        public static void Setup(TestContext context)
        {
            // Launch Calculator application if it is not yet launched
            if (session == null)
            {
                // Create a new session to bring up an instance of the Calculator application
                // Note: Multiple calculator windows (instances) share the same process Id
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", AppId);
                appCapabilities.SetCapability("deviceName", "WindowsPC");
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(session);
                Assert.IsNotNull(session.SessionId);
                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));
                // Verify that Notepad is started with untitled new file
                // Keep track of the edit box to be used throughout the session
                
                session.FindElementByName("button1").Click();
                
                
            }

        }
        public static void TearDown()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.Quit();
                session = null;
            }
        }

    }

    


}
