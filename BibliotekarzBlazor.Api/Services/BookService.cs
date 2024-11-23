using BibliotekarzBlazor.Shared.DTOs;

namespace BibliotekarzBlazor.Api.Services;

public class BookService : IBookService
{
    List<BookDto> books;

    public BookService()
    {
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
        return books;
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

public interface IBookService
{
    IEnumerable<BookDto> GetAll();
    BookDto? GetById(int id);
    void Add(BookDto book);
    void Update(BookDto book);
    void Delete(int id);
}