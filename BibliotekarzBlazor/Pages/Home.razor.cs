using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Web;
using BibliotekarzBlazor.Model;
using BibliotekarzBlazor.Shared.DTOs;
using Microsoft.AspNetCore.Components.Forms;

namespace BibliotekarzBlazor.Pages;

public partial class Home
{
    public string? FilterText { get; set; }

    public List<BookDto> BookList { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetData();
    }

    private async Task GetData()
    {
        BookList = [
        new()
        {
            Id = 1,
            Title = "Harry Potter",
            Author = "J.K. Rowling",
            PageCount = 300,
            IsBorrowed = false,
            Borrower = null
        },
        new()
        {
            Id = 2,
            Title = "Wiedźmin",
            Author = "Andrzej Sapkowski",
            PageCount = 400,
            IsBorrowed = true,
            Borrower = new()
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski"
            }
        }];
    }

    private void OnEditClick(int bookId)
    {
        Navigation.NavigateTo($"edit-book/{bookId}");
    }

    private async Task OnDeleteClick(int bookId)
    {
        
    }
}