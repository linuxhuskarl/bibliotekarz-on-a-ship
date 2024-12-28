using BibliotekarzBlazor.Services;
using BibliotekarzBlazor.Shared.DTOs;
using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Web;
using BibliotekarzBlazor.Shared;

namespace BibliotekarzBlazor.Pages.Authentication;

public partial class Register
{
    private RegisterRequestDto requestModel = new();
    private FluentValidationValidator _fluentValidationValidator;
    private bool _passwordVisibility;
    private InputType _passwordInput = InputType.Password;
    private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

    private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

    [Inject]
    public ISnackbar Snackbar { get; set; }


    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    public IEnumerable<string> SelectedRoles { get; set; } = [Constants.Role_User];

    [Inject]
    IAuthenticationProxyService AuthService { get; set; }

    private async Task SubmitAsync()
    {
        requestModel.Role = SelectedRoles.FirstOrDefault();
        var result = await AuthService.Register(requestModel);
        if (result.Succeeded)
        {
            NavigationManager!.NavigateTo("/login");
        }
        else
        {
            Snackbar.Add("Błąd rejestracji.", Severity.Error);
        }
    }

    void TogglePasswordVisibility()
    {
        if (_passwordVisibility)
        {
            _passwordVisibility = false;
            _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
            _passwordInput = InputType.Password;
        }
        else
        {
            _passwordVisibility = true;
            _passwordInputIcon = Icons.Material.Filled.Visibility;
            _passwordInput = InputType.Text;
        }
    }
}
