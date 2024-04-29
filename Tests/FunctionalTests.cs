using Blazor_Project;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;


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
        
        //reactive- & template-driven forms
        [Fact, Trait("Category", "FunctionalTest")]
        public void NavigateToReactiveForms()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "reactive-forms");
        }

        [Fact, Trait("Category", "UITest")]
        public void ReactiveFormsPageDisplaysCorrectly()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "reactive-forms");

            var pageTitle = _driver.Title;
            var firstNameLabel = _driver.FindElement(By.CssSelector("#firstName")).Text;

            Assert.Equal("Blazor_Project", pageTitle);
            Assert.Equal("First Name:", firstNameLabel);
        }
        
        [Fact, Trait("Category", "UITest")]
        public void SubmitReactiveFormWithValidData()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "reactive-forms");

            var inputFirstName = _driver.FindElement(By.CssSelector("input.valid"));
            inputFirstName.SendKeys("Youssef");

            var inputPassword = _driver.FindElement(By.CssSelector("input[type='password']"));
            inputPassword.SendKeys("Password");

            var submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            try
            {
                var alert = _driver.SwitchTo().Alert();
                var alertText = alert.Text;
                Console.WriteLine("Alert text: " + alertText);

                alert.Accept();
            }
            catch (NoAlertPresentException)
            {
            }

            Assert.DoesNotContain("This field is required", _driver.PageSource);
        }

        [Fact, Trait("Category", "FunctionalTest")]
        public void NavigateToTemplateForms()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "template-forms");
        }

        [Fact, Trait("Category", "UITest")]
        public void TemplateFormsPageDisplaysCorrectly()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "template-forms");

            var pageTitle = _driver.Title;
            var firstNameLabel = _driver.FindElement(By.CssSelector("#firstName")).Text;

            Assert.Equal("Blazor_Project", pageTitle);
            Assert.Equal("First Name:", firstNameLabel);
        }

        [Fact, Trait("Category", "UITest")]
        public void SubmitTemplateFormWithValidData()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "template-forms");
          

            var firstNameInput = _driver.FindElement(By.CssSelector("input[type='text']"));
            firstNameInput.SendKeys("Youssef");

            var submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            Assert.DoesNotContain("This field is required", _driver.PageSource);
        }
        [Fact, Trait("Category", "FunctionalTest")]
        public void NavigateToMoviesSearchPage()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "movies");
            var pageTitle = _driver.Title;
            Assert.Equal("Blazor_Project", pageTitle); 
        }
        [Fact, Trait("Category", "FunctionalTest")]
        public void SearchMoviesWithValidSearchTerm_PopulatesSearchResults()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "movies");

            var inputElement = _driver.FindElement(By.CssSelector(".MoviesSearch__input"));
            inputElement.SendKeys("Avengers");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElements(By.CssSelector(".MoviesSearch__list-group-item")).Count > 0);

            var searchResults = _driver.FindElements(By.CssSelector(".MoviesSearch__list-group-item"));
            Assert.NotEmpty(searchResults);
        }
        [Fact, Trait("Category", "FunctionalTest")]
        public void SearchMoviesWithInvalidSearchTerm_DoesNotPopulateSearchResults()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "movies");

            var inputElement = _driver.FindElement(By.CssSelector(".MoviesSearch__input"));
            inputElement.SendKeys("A");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElements(By.CssSelector(".MoviesSearch__list-group-item")).Count == 0);

            var searchResults = _driver.FindElements(By.CssSelector(".MoviesSearch__list-group-item"));
            Assert.Empty(searchResults);
        }
        [Fact, Trait("Category", "UITest")]
        public void VerifySearchInputFieldIsPresent()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "movies");
            var inputElement = _driver.FindElement(By.CssSelector(".MoviesSearch__input"));
            Assert.NotNull(inputElement);
        }
        [Fact, Trait("Category", "UITest")]
        public void VerifySearchResultsDisplayCorrectly()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "movies");

            var inputElement = _driver.FindElement(By.CssSelector(".MoviesSearch__input"));
            inputElement.SendKeys("Avengers");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElements(By.CssSelector(".MoviesSearch__list-group-item")).Count > 0);

            var searchResults = _driver.FindElements(By.CssSelector(".MoviesSearch__list-group-item"));
            Assert.NotEmpty(searchResults);

        }
        
        //math

        [Fact, Trait("Category", "FunctionalTest")]
        public void NavigateToMathPage()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "math");
            var pageTitle = _driver.Title;
            Assert.Equal("Blazor_Project", pageTitle);
        }
        [Fact, Trait("Category", "UITest")]
        public void MathPageDisplaysCorrectly()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "math");

            var mathTitle = _driver.FindElement(By.TagName("h1")).Text;

            Assert.Equal("Math-o-Matic", mathTitle);
        }
        [Fact, Trait("Category", "UITest")]
        public void StartMathGameAndCheckAnswerCorrectly()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "math");

            var startButton = _driver.FindElement(By.CssSelector(".start-button"));
            startButton.Click();

            var inputField = _driver.FindElement(By.CssSelector("input[type=\"number\"]"));

            var attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    inputField.SendKeys("9999");
                    inputField.SendKeys(Keys.Return);
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    inputField = _driver.FindElement(By.CssSelector("input[type=\"number\"]"));
                }
                attempts++;
            }

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var messageContainer = wait.Until(driver =>
            {
                var element = _driver.FindElement(By.ClassName("message-container"));
                return element.Displayed && !string.IsNullOrEmpty(element.Text) ? element : null;
            });

            Assert.NotEmpty(messageContainer.Text);
        }
        [Fact, Trait("Category", "UITest")]
        public void CheckInputFieldVisibilityWhenGameStarted()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "math");

            var startButton = _driver.FindElement(By.CssSelector(".start-button"));
            startButton.Click();

            var inputField = _driver.FindElement(By.CssSelector("input[type=\"number\"]"));
            Assert.True(inputField.Displayed);
        }

        //animations
        [Fact, Trait("Category", "FunctionalTest")]
        public void NavigateToAnimationsPage()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "animations");
            var pageTitle = _driver.Title;
            Assert.Equal("Blazor_Project", pageTitle);
        }
        [Fact, Trait("Category", "UITest")]
        public void VerifyAttentionSeekerButtonIsPresent()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "attention-seekers");
            var button = _driver.FindElement(By.CssSelector(".animation-button"));
            Assert.NotNull(button);
        }
        [Fact, Trait("Category", "UITest")]
        public void VerifyAnimationToggle()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "attention-seekers");
            var targetDiv = _driver.FindElement(By.CssSelector(".target"));
            var initialClass = targetDiv.GetAttribute("class");

            var animationButton = _driver.FindElement(By.CssSelector(".animation-button"));
            animationButton.Click();

            var updatedClass = targetDiv.GetAttribute("class");
            Assert.NotEqual(initialClass, updatedClass); 
        }

        [Fact, Trait("Category", "UITest")]
        public void VerifyAnimationRemoval()
        {
            _driver.Navigate().GoToUrl(_websiteURL + "attention-seekers");
            var targetDiv = _driver.FindElement(By.CssSelector(".target"));

            var animationButton = _driver.FindElement(By.CssSelector(".animation-button"));
            animationButton.Click();

            var initialClass = targetDiv.GetAttribute("class");
            animationButton.Click(); 

            var updatedClass = targetDiv.GetAttribute("class");
            Assert.NotEqual(initialClass, updatedClass);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
       
}
   
}
  