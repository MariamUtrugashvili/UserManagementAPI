using FluentValidation;
using System.Text.RegularExpressions;

namespace UserManagementAPI.Infrastructure.Extensions.Validation
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> rule)
        {
            return rule.Must(x => Regex.IsMatch(x, @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$")).
                WithMessage("Email is invalid").NotEmpty().
                WithMessage("Email should not be empty.");
        }
    }
}
