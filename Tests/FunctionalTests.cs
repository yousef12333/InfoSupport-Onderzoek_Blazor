
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor_Project.Pages;
using Blazor_Project.Services;
using Bunit;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace Tests
{
    public class FunctionalTests  : IDisposable
    {
        
        private readonly string _websiteURL;
        private readonly EdgeDriver _driver;

        public FunctionalTests(string webAppUrl = "http://localhost:5073/")
        {
            _websiteURL = webAppUrl;
            _driver = new EdgeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        [Fact, Trait("Category", "FunctionalTest")]
        public void NavigateToPasswordChecker()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "passwordchecker");
        }
        [Fact, Trait("Category", "UITest")]
        public void PasswordCheckerPageDisplaysCorrectly()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "passwordchecker");

            var pageTitle = _driver.Title;
            var passTitle = _driver.FindElement(By.CssSelector(".pass-title")).Text;

            Assert.Equal("Blazor_Project", pageTitle); 
            Assert.Equal("Password strength", passTitle);
        }

        [Fact, Trait("Category", "UITest")]
        public void InvalidPasswordDisplaysCorrectly()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "passwordchecker");

            var inputPassword = _driver.FindElement(By.CssSelector(".pass-input"));
            inputPassword.SendKeys("");

            var invalidSpanClass = _driver.FindElement(By.CssSelector(".pass-marker span:nth-child(1)")).GetAttribute("class");

            Assert.Contains("invalid", invalidSpanClass);
        }

        [Fact, Trait("Category", "UITest")]
        public void ValidPasswordDisplaysCorrectly()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "passwordchecker");

            var inputPassword = _driver.FindElement(By.CssSelector(".pass-input"));
            inputPassword.SendKeys("StrongPassword123./");

            var validSpanClass = _driver.FindElement(By.CssSelector(".pass-marker span:nth-child(1)")).GetAttribute("class");

            Assert.Contains("strong", validSpanClass);
        }

        [Fact, Trait("Category", "UITest")]
        public void PasswordStrengthUpdatesOnInput()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "passwordchecker");

            var inputPassword = _driver.FindElement(By.CssSelector(".pass-input"));
            inputPassword.SendKeys("MediumPassword12");

            var mediumSpanClass = _driver.FindElement(By.CssSelector(".pass-marker span:nth-child(2)")).GetAttribute("class");

            Assert.Contains("medium", mediumSpanClass);
        }

        [Fact, Trait("Category", "UITest")]
        public void PasswordStrengthUpdatesCorrectly()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "passwordchecker");
            var inputPassword = _driver.FindElement(By.CssSelector(".pass-input"));
            inputPassword.SendKeys("Password123./");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var classAfterTyping = wait.Until(driver =>
                driver.FindElement(By.CssSelector(".pass-marker span:nth-child(1)")).GetAttribute("class"));
            var expectedClass = "spanColors strong"; 

            Assert.Equal(expectedClass, classAfterTyping);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
        
    }
}
