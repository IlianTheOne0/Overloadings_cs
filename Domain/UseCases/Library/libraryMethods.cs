namespace ClassLibrary.Library;
using ClassLibrary.Library.Entity;

public partial class Library
{
    public void add(Book book) => _library.Add(book);

    public bool remove(int bookId)
    {
        Book? book = _library.Find(b => b?.id == bookId);

        if (book != null) { _library.Remove(book.Value); return true; }
        return false;
    }

    public bool remove(Book book) => _library.Remove(book);

    public Book? GetBook(Book book) => _library.Find(b => b?.id == book.id);
    public Book? getBookById(int bookId) => _library.Find(b => b?.id == bookId);
    public Book? getBookByName(string title) => _library.Find(b => b?.title == title);
    public Book? getBookByYear(int year) => _library.Find(b => b?.year == year);

    public List<Book?> getAllBooks() => new List<Book?>(_library);
    public List<Book?> getBooksByAuthor(string authorLastName) => _library.Where(book => book?.author.ToString().Split(' ').Last() == authorLastName).ToList();

    public int count() => _library.Count;
}