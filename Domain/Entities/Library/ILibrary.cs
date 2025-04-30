namespace ClassLibrary.Library.Interface;
using ClassLibrary.Library.Entity;

public interface IJournal
{
    void add(Book book);
    bool remove(int bookId);

    Book? GetBook(Book book);
    Book? getBookById(int bookId);
    Book? getBookByName(string title);
    Book? getBookByYear(int year);

    List<Book?> getAllBooks();
    List<Book?> getBooksByAuthor(string authorLastName);
}