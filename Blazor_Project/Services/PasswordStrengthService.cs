using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Blazor_Project.Services
{
    public class PasswordStrengthService
    {
        private readonly Regex PasswordDifficultyIdentificationEasy = new Regex(@"^([a-zA-Z]+|[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]+|[0-9]+)$");
        private readonly Regex PasswordDifficultyIdentificationMedium = new Regex(@"^(?:(?=.*[a-zA-Z])(?=.*\d)|(?=.*[a-zA-Z])(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\-])|(?=.*\d)(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]))[a-zA-Z\d!@#$%^&*()_+{}\[\]:;<>,.?~\\-]+$");
        private readonly Regex PasswordDifficultyIdentificationStrong = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]).+$");

        private readonly ILogger<PasswordStrengthService> logger;

        public PasswordStrengthService(ILogger<PasswordStrengthService> logger)
        {
            this.logger = logger;
        }

        public bool IsEasyValidationPassed(string password)
        {
            return PasswordDifficultyIdentificationEasy.IsMatch(password);
        }

        public bool IsMediumValidationPassed(string password)
        {
            return PasswordDifficultyIdentificationMedium.IsMatch(password);
        }

        public bool IsStrongValidationPassed(string password)
        {
            return PasswordDifficultyIdentificationStrong.IsMatch(password);
        }
    }
}