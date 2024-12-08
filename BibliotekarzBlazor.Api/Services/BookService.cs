using Bibliotekarz.Data.Model;
using Bibliotekarz.Data.Repositories;
using BibliotekarzBlazor.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BibliotekarzBlazor.Api.Services;

public interface IBookService
{
    IEnumerable<BookDto> GetAll();
    BookDto? GetById(int id);
    void Add(BookDto book);
    void Update(BookDto book);
    void Delete(int id);
}

public class BookService : IBookService
{
    private readonly IKeyRepository<Book, long> bookRepository;
    List<BookDto> books; //TODO: Wywalić tą fake tablicę.

    public BookService(IKeyRepository<Book, long> bookRepository)
    {
        this.bookRepository = bookRepository;
        books = GetFakeData();
    }

    public void Add(BookDto book)
    {
        books.Add(book);
    }

    public void Delete(int id)
    {
        BookDto book = GetById(id);
        books.Remove(book);
    }

    public IEnumerable<BookDto> GetAll()
    {
        var result = bookRepository.GetAll().Include(x => x.Borrower)
            .Select(x => new BookDto
        {
            Id = (int)x.Id,
            Author = x.Author!,
            Title = x.Title,
            IsBorrowed = x.IsBorrowed,
            PageCount = x.PageCount,
            Borrower = x.Borrower != null ? new CustomerDto
            {
                Id = (int)x.Borrower.Id,
                FirstName = x.Borrower.FirstName!,
                LastName = x.Borrower.LastName!
            } : null!
        }).ToList();

        return result;
    }

    public BookDto? GetById(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    public void Update(BookDto book)
    {
        BookDto existingBook = GetById(book.Id);
        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.PageCount = book.PageCount;
        existingBook.IsBorrowed = book.IsBorrowed;
        existingBook.Borrower = book.Borrower;
    }

    private List<BookDto>? GetFakeData()
    {
        return
        [
            new BookDto
            {
                Id = 1,
                Title = "C# Programming",
                Author = "John Doe",
                PageCount = 456,
                IsBorrowed = false,
                Borrower = new()
            },

            new BookDto
            {
                Id = 2,
                Title = "Java Programming",
                Author = "Jane Doe",
                PageCount = 654,
                IsBorrowed = true,
                Borrower = new()
                {
                    Id = 1,
                    FirstName = "Alice",
                    LastName = "Smith"
                }
            }
        ];
    }
}
