using System.ComponentModel.DataAnnotations;
using BibliotekarzBlazor.Attributes;

namespace BibliotekarzBlazor.Model;

public class Person : IValidatableObject
{
    [Required]
    public string Name { get; set; }

    [Range(18, 65, ErrorMessage = "Wprowadź wiek w zakresie od 18 do 65 lat.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Podaj adres email.")]
    [EmailAddress(ErrorMessage = "Niepoprawny adres email.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Podaj email w poprawnym formacie.")]
    public string Mail { get; set; }

    [Compare(nameof(Mail), ErrorMessage = "Adresy email różnią się.")]
    public string ConfirmMail { get; set; }

    [Required(ErrorMessage = "Podaj hasło.")]
    [PasswordValidation(minLength: 8, maxLength: 30, true, true, true, true)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Pole adres nie może być puste.")]
    [StringLength(25, MinimumLength = 15, ErrorMessage = "Długość adresu musi być pomiędzy 10 a 25 znaków.")]
    public string Address { get; set; }

    public int? Day { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Day.HasValue && Month.HasValue && Year.HasValue)
        {
            bool isValid = true;

            try
            {
                DateTime date = new DateTime(Year.Value, Month.Value, Day.Value);
            }
            catch 
            {
                isValid = false;
            }

            if (!isValid)
                yield return new ValidationResult("Podana data jest nieprawidłowa", [nameof(Day), nameof(Month), nameof(Year)]);

        }
        else
        {
            yield return new ValidationResult("Brakuje danych", [nameof(Day), nameof(Month), nameof(Year)]);
        }
    }
}