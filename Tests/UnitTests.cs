using Bunit;
using Blazor_Project;
using Blazor_Project.Services;

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
    }
}