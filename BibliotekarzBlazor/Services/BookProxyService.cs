using System.Net.Http.Json;
using BibliotekarzBlazor.Shared.DTOs;

namespace BibliotekarzBlazor.Services;

public class BookProxyService : IBookProxyService
{
    private readonly HttpClient httpClient;

    public BookProxyService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<BookDto>> GetAll()
    {
        IEnumerable<BookDto> books = await httpClient.GetFromJsonAsync<IEnumerable<BookDto>>("api/books");
        return books;
    }

    public async Task<BookDto?> GetById(int id)
    {
        BookDto? book = await httpClient.GetFromJsonAsync<BookDto>($"api/books/{id}");
        return book;
    }

    public async Task Update(BookDto book)
    {
        await httpClient.PutAsJsonAsync("api/books", book);
    }
}

public interface IBookProxyService
{
    Task<IEnumerable<BookDto>> GetAll();
    Task<BookDto?> GetById(int id);
    Task Update(BookDto book);
}