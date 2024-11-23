using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Web;
using BibliotekarzBlazor.Model;
using BibliotekarzBlazor.Services;
using BibliotekarzBlazor.Shared.DTOs;
using Microsoft.AspNetCore.Components.Forms;

namespace BibliotekarzBlazor.Pages;

public partial class Home
{
    public string? FilterText { get; set; }

    public List<BookDto> BookList { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }

    [Inject]
    public IBookProxyService BookService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetData();
    }

    private async Task GetData()
    {
        BookList = (await BookService.GetAll())?.ToList() ?? [];
    }

    private void OnEditClick(int bookId)
    {
        Navigation.NavigateTo($"edit-book/{bookId}");
    }

    private async Task OnDeleteClick(int bookId)
    {
        
    }
}