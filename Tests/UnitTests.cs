using Bunit;
using Blazor_Project;
using Blazor_Project.Services;
using System.Reflection;
using Blazor_Project.Pages;

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

    }
}