using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BibliotekarzBlazor.Attributes;

public class PasswordValidationAttribute : ValidationAttribute
{
    private readonly int minLength;
    private readonly int maxLength;
    private readonly bool requireDigit;
    private readonly bool requireLowercase;
    private readonly bool requireUpperCase;
    private readonly bool requireNonAlphanumeric;
    private readonly string? regex;

    public PasswordValidationAttribute(int minLength, int maxLength, bool requireDigit, bool requireLowercase, 
        bool requireUpperCase, bool requireNonAlphanumeric, string? regex = null)
    {
        this.minLength = minLength;
        this.maxLength = maxLength;
        this.requireDigit = requireDigit;
        this.requireLowercase = requireLowercase;
        this.requireUpperCase = requireUpperCase;
        this.requireNonAlphanumeric = requireNonAlphanumeric;
        this.regex = regex;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string? password = value as string;

        if (string.IsNullOrWhiteSpace(password))
        {
            return new ValidationResult("Hasło nie może być puste.");
        }

        if (password.Length < minLength || password.Length > maxLength)
        {
            return new ValidationResult($"Hasło musi mieć co najmniej {minLength} znaków i maksymalnie {maxLength}.");
        }

        if (requireDigit && !password.Any(char.IsDigit))
        {
            return new ValidationResult("Hasło musi zawierać co najmniej jedną cyfrę.");
        }

        if (requireLowercase && !password.Any(char.IsLower))
        {
            return new ValidationResult("Hasło musi zawierać co najmniej jedną małą literę.");
        }

        if (requireUpperCase && !password.Any(char.IsUpper))
        {
            return new ValidationResult("Hasło musi zawierać co najmniej jedną dużą literę.");
        }

        if (requireNonAlphanumeric && password.All(char.IsLetterOrDigit))
        {
            return new ValidationResult("Hasło musi zawierać co najmniej jeden znak niebędący literą ani cyfrą.");
        }

        if (regex != null && !Regex.IsMatch(password, regex))
        {
            return new ValidationResult("Hasło nie spełnia wymagań.");
        }

        return ValidationResult.Success;
    }
}