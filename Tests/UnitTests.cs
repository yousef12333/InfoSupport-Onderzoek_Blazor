using Bunit;
using Blazor_Project.Services;
using System.Reflection;
using Blazor_Project.Pages;
using Blazor_Project.Classes;
using Microsoft.AspNetCore.Components;
using System.Reactive.Linq;
using Moq;

namespace Tests
{
    public class UnitTests : TestContext
    {
        private readonly PasswordStrengthService service;

        public UnitTests()
        {
            service = new PasswordStrengthService();
        }
       
        [Fact]
        public void DestructionTestOfPasswordChecker()
        {
            var result = service.IsValidationPassed(null, PasswordStrength.Strong);
            Assert.NotNull(service);
            Assert.False(result);
        }

        [Theory]
        [InlineData("!@#$%^&*()_+{}[]:;<>,.?~-")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")]
        [InlineData("0123456789")]
        [InlineData("!@#abcDEF123")]
        public void FuzzTestOfPasswordChecker(string input)
        {
            var result = service.IsValidationPassed(input, PasswordStrength.Strong);
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("a1!ABCDEFGH9@#a")]
        [InlineData("a1!ABCDEFGH9@#aBCDEFGH9")]
        [InlineData("a1!ABCDEFGH9@#aBCDEFGH9*")]
        [InlineData("a1!ABCDEFGH9@#aBCDEFGH9*(")]
        [InlineData("a1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGH")]
        [InlineData("a1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGHa1!ABCDEFGH9@#aBCDEFGH9*()ZER£%¨*¨25255SDFSDGH")]
        public void BoundaryValueTest(string input)
        {
            var result = service.IsValidationPassed(input, PasswordStrength.Strong);
            Assert.True(result);
        }

        [Theory]
        [InlineData("abc", true, false, false)]
        [InlineData("abc123", true, true, false)]
        [InlineData("abc123!", true, true, true)]
        [InlineData("", false, false, false)]
        [InlineData("!@#$%^&*()_+", true, false, false)]
        [InlineData("password123", false, true, false)]
        [InlineData("P@ssw0rd", false, true, true)]
        [InlineData("1234567890", false, false, true)]
        [InlineData("aB!23", true, true, true)]
        [InlineData("special_characters_!@#$%", false, false, true)]
        [InlineData("mixOfCharacters123!@#", true, true, true)]
        public void DataDrivenTestOfPasswordChecker(string input, bool expectedEasy, bool expectedMedium, bool expectedStrong)
        {
            var isEasy = service.IsValidationPassed(input, PasswordStrength.Easy);
            var isMedium = service.IsValidationPassed(input, PasswordStrength.Medium);
            var isStrong = service.IsValidationPassed(input, PasswordStrength.Strong);

            Assert.Equal(expectedEasy, isEasy);
            Assert.Equal(expectedMedium, isMedium);
            Assert.Equal(expectedStrong, isStrong);
        }
        [Theory]
        [InlineData("abcdefghijk", true)]
        [InlineData("!@#$%^&*()_+", true)]
        [InlineData("b1233456789", false)]
        [InlineData("abcdefgh123", false)]
        public void IsEasyValidationPassed_ReturnsCorrectResult(string input, bool expectedResult)
        {
            var result = service.IsValidationPassed(input, PasswordStrength.Easy);
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData("abcdefghijkl", false)]
        [InlineData("abcdefghij123", true)]
        [InlineData("!@#$%^&*()_+", false)]
        [InlineData("123456789", false)]
        public void IsMediumValidationPassed_ReturnsCorrectResult(string input, bool expectedResult)
        {
            var result = service.IsValidationPassed(input, PasswordStrength.Medium);
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData("abcdefghijkl", false)]
        [InlineData("abc123456789", false)]
        [InlineData("!@#$%^&*()_+", false)]
        [InlineData("abcdefgh123!A", true)]
        public void IsStrongValidationPassed_ReturnsCorrectResult(string input, bool expectedResult)
        {
            
            var result = service.IsValidationPassed(input, PasswordStrength.Strong);
            Assert.Equal(expectedResult, result);
        }

        //reactive forms
        [Fact]
        public void FuzzTest_FirstName_Valid_Of_Reactive_Forms()
        {
            var formData = new FormData { FirstName = "!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123" };
            var cut = RenderComponent<ReactiveFormsExample>(
                ("FormModel", formData)
            );
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("button[type='submit']").Click();

            Assert.DoesNotContain("<span class=\"has-error\">This field is required</span>", cut.Markup);
        }

        [Fact]
        public void DestructionTest_FormData_Null_Of_Reactive_Forms()
        {
            FormData formData = null;

            Assert.ThrowsAny<Exception>(() => RenderComponent<ReactiveFormsExample>(
                ("FormModel", formData)
            ));
        }
        [Theory]
        [InlineData("")]
        [InlineData("l")]
        [InlineData("!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123")]
        public void BoundaryValueTest_FirstName_Of_Reactive_Forms(string firstName)
        {
            var formData = new FormData();
            formData.FirstName = firstName;

            var cut = RenderComponent<ReactiveFormsExample>(
                ("FormModel", formData)
            );

            JSInterop.SetupVoid("alert", _ => true);

            cut.Find("button[type='submit']").Click();

            if (string.IsNullOrEmpty(firstName))
            {
                cut.Find(".has-error").MarkupMatches("<span class=\"has-error\">This field is required</span>");
            }
            else
            {
                Assert.DoesNotContain("<span class=\"has-error\">This field is required</span>", cut.Markup);
            }
        }

        [Theory]
        [InlineData("", true)]
        [InlineData("Youssef", false)]
        [InlineData("!@#$%^&*()_+{}[]:;<>,.?~-", false)]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", false)]
        [InlineData("0123456789", false)]
        [InlineData("!@#abcDEF123", false)]
        [InlineData("Test123opp123", false)]
        [InlineData("Loop34nOOp43", false)]
        [InlineData("ZER£%¨*¨ZER£%¨*¨ZER£%¨*¨", false)]
        public void DataDrivenTest_FirstName_Of_Reactive_Forms(string firstName, bool expectError)
        {
            var formData = new FormData { FirstName = firstName };
            var cut = RenderComponent<ReactiveFormsExample>(
                ("FormModel", formData)
            );
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("button[type='submit']").Click();

            if (expectError)
            {
                cut.Find(".has-error").MarkupMatches("<span class=\"has-error\">This field is required</span>");
            }
            else
            {
                Assert.DoesNotContain("<span class=\"has-error\">This field is required</span>", cut.Markup);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldUseCity_Checkbox_TogglesCitySelection_Of_Reactive_Forms(bool shouldUseCity)
        {
            var formData = new FormData { ShouldUseCity = shouldUseCity };
            var cut = RenderComponent<ReactiveFormsExample>(
                ("FormModel", formData)
            );
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("input[type='checkbox']").Change(shouldUseCity);

            if (shouldUseCity)
            {
                Assert.Contains("<select", cut.Markup);
            }
            else
            {
                Assert.DoesNotContain("<select", cut.Markup);
            }
        }
        [Fact]
        public void FirstName_Null_ShouldDisplayError_Of_Reactive_Forms()
        {
            var cut = RenderComponent<ReactiveFormsExample>();
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("button[type='submit']").Click();

            cut.Find(".has-error").MarkupMatches("<span class=\"has-error\">This field is required</span>");
        }

        [Fact]
        public void FirstName_NotNull_ShouldNotDisplayError_Of_Reactive_Forms()
        {
            var formData = new FormData { FirstName = "John" };
            var cut = RenderComponent<ReactiveFormsExample>(
                ("FormModel", formData)
            );
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("button[type='submit']").Click();

            Assert.DoesNotContain("<span class=\"has-error\">This field is required</span>", cut.Markup);
        }
        //template driven forms
        [Fact]
        public void FuzzTest_FirstName_Valid_Of_Template_Forms()
        {
            var formData = new FormData { FirstName = "!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123" };
            var cut = RenderComponent<TemplateFormsExample>(
                ("FormData", formData)
            );
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("button[type='submit']").Click();

            Assert.DoesNotContain("<span class=\"has-error\">This field is required</span>", cut.Markup);
        }

        [Fact]
        public void DestructionTest_FormData_Null_Of_Template_Forms()
        {
            FormData formData = null;

            Assert.ThrowsAny<Exception>(() => RenderComponent<TemplateFormsExample>(
                ("FormData", formData)
            ));
        }
        [Theory]
        [InlineData("l")]
        [InlineData("!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123")]
        public void BoundaryValueTest_FirstName_Of_Of_Template_Forms(string firstName)
        {
            var formData = new FormData();
            formData.FirstName = firstName;

            var cut = RenderComponent<TemplateFormsExample>(
                ("FormData", formData)
            );

            JSInterop.SetupVoid("alert", _ => true);

            cut.Find("button[type='submit']").Click();

            if (string.IsNullOrEmpty(firstName))
            {
                cut.Find(".has-error").MarkupMatches("<span class=\"has-error\">This field is required</span>");
            }
            else
            {
                Assert.DoesNotContain("<span class=\"has-error\">This field is required</span>", cut.Markup);
            }
        }

        [Theory]
        [InlineData("Youssef", false)]
        [InlineData("!@#$%^&*()_+{}[]:;<>,.?~-", false)]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", false)]
        [InlineData("0123456789", false)]
        [InlineData("!@#abcDEF123", false)]
        [InlineData("Test123opp123", false)]
        [InlineData("Loop34nOOp43", false)]
        [InlineData("ZER£%¨*¨ZER£%¨*¨ZER£%¨*¨", false)]
        public void DataDrivenTest_FirstName_Of_Template_Forms(string firstName, bool expectError)
        {
            var formData = new FormData { FirstName = firstName };
            var cut = RenderComponent<TemplateFormsExample>(
                ("FormData", formData)
            );
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("button[type='submit']").Click();

            if (expectError)
            {
                cut.Find(".has-error").MarkupMatches("<span class=\"has-error\">This field is required</span>");
            }
            else
            {
                Assert.DoesNotContain("<span class=\"has-error\">This field is required</span>", cut.Markup);
            }
        }
     

        [Fact]
        public void FirstName_NotNull_ShouldNotDisplayError_Of_Template_Forms()
        {
            var formData = new FormData { FirstName = "John" };
            var cut = RenderComponent<TemplateFormsExample>(
                ("FormData", formData)
            );
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("form").Submit();

            Assert.Throws<ElementNotFoundException>(() => cut.Find(".has-error"));
        }

        [Fact]
        public void ShouldUseCity_Checkbox_TogglesCitySelection_Of_Template_Forms()
        {
            var formData = new FormData();
            var cut = RenderComponent<TemplateFormsExample>(
                ("FormData", formData)
            );
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("input[type='checkbox']").Change(true);

            Assert.Contains("<select", cut.Markup);
        }

        [Fact]
        public void City_Selection_ShouldNotBeVisible_WhenShouldUseCityIsFalse_Of_Template_Forms()
        {
            var formData = new FormData();
            var cut = RenderComponent<TemplateFormsExample>(
                ("FormData", formData)
            );
            JSInterop.SetupVoid("alert", _ => true);
            cut.Find("input[type='checkbox']").Change(false);

            Assert.DoesNotContain("<select", cut.Markup);
        }
        //movies functionality with rx.NET and external API
        [Theory]
        [InlineData("!@#$%^&*()_+{}[]:;<>,.?~-")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")]
        [InlineData("0123456789")]
        [InlineData("!@#abcDEF123")]
        public void FuzzTest_Movies(string searchTerm)
        {
            var page = RenderComponent<Movies>();
            page.Find("input.MoviesSearch__input").Change(searchTerm);
            Assert.Equal(searchTerm, page.Find("input.MoviesSearch__input").GetAttribute("value"));
        }

        [Fact]
        public void DestructionTest_Movies_SearchTermIsNull_ClearsSearchResults()
        {
            var page = RenderComponent<Movies>();
            page.Find("input.MoviesSearch__input").Change(""); 
            Assert.Empty(page.FindAll(".MoviesSearch__list-group-item"));
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123!@#$%^&*()_+{}[]:;<>,.?~-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#abcDEF123")]
        public void BoundaryValueTest_Movies_EmptySearchTerm_ClearsSearchResults(string searchTerm)
        {
            var page = RenderComponent<Movies>();
            page.Find("input.MoviesSearch__input").Change(searchTerm);
            Assert.Empty(page.FindAll(".MoviesSearch__list-group-item"));
        }

        [Theory]
        [InlineData("Youssef")]
        [InlineData("!@#$%^&*()_+{}[]:;<>,.?~-")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")]
        [InlineData("0123456789")]
        [InlineData("!@#abcDEF123")]
        [InlineData("Test123opp123")]
        [InlineData("Loop34nOOp43")]
        [InlineData("ZER£%¨*¨ZER£%¨*¨ZER£%¨*¨")]
        public void DataDrivenTest_Movies_ValidSearchTerm_DoesNotContainError(string searchTerm)
        {
            var page = RenderComponent<Movies>();
            page.Find("input.MoviesSearch__input").Change(searchTerm);
            Assert.DoesNotContain("<span class=\"has-error\">This field is required</span>", page.Markup);
        }
        [Fact]
        public async Task SearchEmpty_UpdatesSearchResults()
        {
            var api = new API(); 
            var moviesComponent = RenderComponent<Movies>();
            var searchTerm = "Fight club";
            moviesComponent.Find("input.MoviesSearch__input").Change(searchTerm);
            await Task.Delay(1000); 
            Assert.Equal(0, moviesComponent.FindAll(".MoviesSearch__list-group-item").Count());
        }

        [Fact]
        public async Task ClearSearchResults_ResetsSearchResults()
        {
            var moviesComponent = RenderComponent<Movies>();
            moviesComponent.Find("input.MoviesSearch__input").Change("Avengers");
            await Task.Delay(1000); 
            moviesComponent.InvokeAsync(() => moviesComponent.Instance.ClearSearchResults());
            Assert.Empty(moviesComponent.FindAll(".MoviesSearch__list-group-item"));
        }

        [Theory]
        [InlineData("Avengers")]
        [InlineData("Iron Man")]
        public async Task HandleTyping_TriggerSearch(string searchTerm)
        {
            var moviesComponent = RenderComponent<Movies>();
            moviesComponent.Find("input.MoviesSearch__input").Change(searchTerm);
            Assert.Equal(searchTerm, moviesComponent.Instance.SearchTerm);
        }

      

        [Fact]
        public async Task GetMovieIds_ReturnsValidMovieIds()
        {
            var moviesComponent = RenderComponent<Movies>();
            var titles = new List<string> { "Avengers", "Iron Man" };
            var movieIds = await moviesComponent.InvokeAsync(() => moviesComponent.Instance.GetMovieIds(titles));
            Assert.Equal(titles.Count, movieIds.Count);
        }
       
        [Fact]
        public async Task SearchMovies_EmptySearchTerm_DoesNotCallAPI()
        {
            var moviesComponent = RenderComponent<Movies>();
            var initialSearchResultsCount = moviesComponent.FindAll(".MoviesSearch__list-group-item").Count;
            moviesComponent.Instance.SearchTerm = ""; 
            await Task.Delay(1000); 
            Assert.Equal(initialSearchResultsCount, moviesComponent.FindAll(".MoviesSearch__list-group-item").Count);
        }

        [Fact]
        public async Task SearchMovies_LongSearchTerm_DoesNotCallAPI()
        {
            var moviesComponent = RenderComponent<Movies>();
            var initialSearchResultsCount = moviesComponent.FindAll(".MoviesSearch__list-group-item").Count;
            moviesComponent.Instance.SearchTerm = "Interstellar"; 
            await Task.Delay(1000);
            Assert.Equal(initialSearchResultsCount, moviesComponent.FindAll(".MoviesSearch__list-group-item").Count);
        }

        [Fact]
        public async Task HandleTyping_SearchTermLengthLessThanThree_ClearsSearchResults()
        {
            var moviesComponent = RenderComponent<Movies>();
            moviesComponent.Instance.SearchTerm = "Star Wars"; 
            moviesComponent.Instance.HandleTyping(new ChangeEventArgs { Value = "st" }); 
            Assert.Empty(moviesComponent.FindAll(".MoviesSearch__list-group-item"));
        }
        [Fact]
        public async Task GetMovieDetails_ReturnsMovieDetails()
        {
            var api = new API();
            var movieId = "123";
            var movieDetails = await api.GetMovieDetails(movieId);
            Assert.NotEmpty(movieDetails.Title);
        }

        [Fact]
        public async Task GetMovieIdByTitle_ReturnsValidMovieId()
        {
            var api = new API();
            var title = "Inception";
            var movieId = await api.GetMovieIdByTitle(title);
            Assert.NotEqual(-1, movieId);
        }

        [Fact]
        public async Task GetMovieIdByTitle_ReturnsMinusOneOnNotFound()
        {
            var api = new API();
            var title = "Invalid Movie Title";
            var movieId = await api.GetMovieIdByTitle(title);
            Assert.Equal(-1, movieId);
        }

        [Fact]
        public async Task Search_ReturnsValidSearchResults()
        {
            var api = new API();
            var searchTerm = "Interstellar";
            var searchResult = await api.Search(searchTerm);
            Assert.NotEmpty(searchResult.Item1);
            Assert.NotEmpty(searchResult.Item2);
            Assert.Equal(searchResult.Item1.Count, searchResult.Item2.Count);
        }

        [Fact]
        public async Task Search_ReturnsEmptyResultsForInvalidSearchTerm()
        {
            var api = new API();
            var searchTerm = "Invalid Search Term";
            var searchResult = await api.Search(searchTerm);
            Assert.Empty(searchResult.Item1);
            Assert.Empty(searchResult.Item2);
        }
        [Fact]
        public async Task MoviesDetail_ShowsLoadingWhenNoMovieIdProvided()
        {
            var cut = RenderComponent<MoviesDetail>();
            cut.MarkupMatches("<link rel=\"stylesheet\" href=\"css/MoviesDetail.css\">\r\n    <h1>Loading...</h1>");
        }
    }
}