using BibliotekarzBlazor.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace BibliotekarzBlazor.Pages;

public partial class EditBook : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    [Inject] 
    public NavigationManager Navigation { get; set; }

    [Inject] 
    public ISnackbar Snackbar { get; set; }

    public BookDto Book { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Book = new()
        {
            Id = this.Id,
            Title = "Harry Potter",
            Author = "J.K. Rowling",
            PageCount = 300,
            IsBorrowed = false,
            Borrower = new CustomerDto
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Kowalski"
            }
        };
    }

    private Task OnSaveClick(MouseEventArgs arg)
    {
        Navigation.NavigateTo("/");
        Snackbar.Add("Zmiany zostały zapisane.", Severity.Success);
        return Task.CompletedTask;
    }

    private void OnCancelClick(MouseEventArgs obj)
    {
        Navigation.NavigateTo("/");
    }
}