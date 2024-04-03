using Blazor_Project.Classes;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Blazor_Project.Services
{
    public class PasswordStrengthService
    {
       
        private readonly Regex PasswordDifficultyIdentificationEasy = new Regex(@"^([a-zA-Z]+|[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]+|[0-9]+)$");
        private readonly Regex PasswordDifficultyIdentificationMedium = new Regex(@"^(?:(?=.*[a-zA-Z])(?=.*\d)|(?=.*[a-zA-Z])(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\-])|(?=.*\d)(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]))[a-zA-Z\d!@#$%^&*()_+{}\[\]:;<>,.?~\\-]+$");
        private readonly Regex PasswordDifficultyIdentificationStrong = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]).+$");
        public bool IsValidationPassed(string password, PasswordStrength strength)
        {
            return strength switch
            {
                PasswordStrength.Easy => PasswordDifficultyIdentificationEasy.IsMatch(password),
                PasswordStrength.Medium => PasswordDifficultyIdentificationMedium.IsMatch(password),
                PasswordStrength.Strong => PasswordDifficultyIdentificationStrong.IsMatch(password),
                _ => false
            };
        }
    }
}