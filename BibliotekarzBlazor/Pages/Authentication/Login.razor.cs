using BibliotekarzBlazor.Services;
using BibliotekarzBlazor.Shared.DTOs;
using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Web;

namespace BibliotekarzBlazor.Pages.Authentication;

public partial class Login
{
    private FluentValidationValidator _fluentValidationValidator;
    private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
    private LoginRequestDto requestModel = new();
    public string? returnUrl;

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    [Inject]
    IAuthenticationProxyService AuthService { get; set; }

    protected override async Task OnInitializedAsync()
    {
    }

    private async Task SubmitAsync()
    {
        var result = await AuthService.Login(requestModel);
        if (result.Succeeded)
        {
            var absoluteUri = new Uri(NavigationManager!.Uri);
            var queryParam = HttpUtility.ParseQueryString(absoluteUri.Query);
            returnUrl = queryParam["returnUrl"];
            if (string.IsNullOrEmpty(returnUrl))
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                NavigationManager.NavigateTo("/" + returnUrl);
            }
        }
        else
        {
            Snackbar.Add("Błąd logowania.", Severity.Error);
        }

    }

    private bool _passwordVisibility;
    private InputType _passwordInput = InputType.Password;
    private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

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