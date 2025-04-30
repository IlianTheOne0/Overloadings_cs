namespace UnitTest.Library.Methods;
using ClassLibrary.Library;
using ClassLibrary.Library.Entity;
using System.Reflection;

[TestClass]
public class LibraryTests
{
    private Library _library = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _library = new Library();
        ResetStaticIdCounter(typeof(Book));
        ResetStaticIdCounter(typeof(Author));
    }

    private void ResetStaticIdCounter(Type type)
    {
        FieldInfo? idCounterField = type.GetField("_idCounter", BindingFlags.Static | BindingFlags.NonPublic) ?? throw new KeyNotFoundException("The static field \"_idCounter\" was not found in the specified type.");
        idCounterField?.SetValue(null, 0);
    }

    [TestMethod]
    public void Add_Book_ShouldIncreaseCount()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", author, 2024);

        _library.add(book);

        Assert.AreEqual(1, _library.count(), "The library count did not increase after adding a book.");
        Book? retrievedBook = _library.getBookById(book.id) ?? throw new KeyNotFoundException($"The book with id {book.id} was not found.");
        Assert.IsNotNull(retrievedBook, "The retrieved book is null.");
        Assert.AreEqual(book.title, retrievedBook.Value.title, "The retrieved book's title does not match the added book's title.");
    }

    [TestMethod]
    public void Remove_ById_ExistingBook_ShouldReturnTrueAndDecreaseCount()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", author, 2024);
        _library.add(book);

        bool result = _library.remove(book.id);

        Assert.IsTrue(result, "Removing an existing book by ID did not return true.");
        Assert.AreEqual(0, _library.count(), "The library count did not decrease after removing a book.");
    }

    [TestMethod]
    public void Remove_ById_NonExistentId_ShouldReturnFalse()
    {
        bool result = _library.remove(999);

        Assert.IsFalse(result, "Removing a non-existent book ID did not return false.");
    }

    [TestMethod]
    public void Remove_ByBook_ExistingBook_ShouldReturnTrueAndDecreaseCount()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", author, 2024);
        _library.add(book);

        bool result = _library.remove(book);

        Assert.IsTrue(result, "Removing an existing book by reference did not return true.");
        Assert.AreEqual(0, _library.count(), "The library count did not decrease after removing a book by reference.");
    }

    [TestMethod]
    public void Remove_ByBook_NonExistentBook_ShouldReturnFalse()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", author, 2024);

        bool result = _library.remove(book);

        Assert.IsFalse(result, "Removing a non-existent book by reference did not return false.");
    }

    [TestMethod]
    public void GetBook_ExistingBook_ShouldReturnBook()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", author, 2024);
        _library.add(book);

        Book result = _library.GetBook(book) ?? throw new KeyNotFoundException($"The book with id {book.id} was not found.");

        Assert.IsNotNull(result, "The retrieved book is null.");
        Assert.AreEqual(book.id, result.id, "The retrieved book's ID does not match the added book's ID.");
        Assert.AreEqual(book.title, result.title, "The retrieved book's title does not match the added book's title.");
    }

    [TestMethod]
    public void GetBook_NonExistentBook_ShouldReturnNull()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", author, 2024);

        Book? result = _library.GetBook(book);

        Assert.IsNull(result, "Retrieving a non-existent book did not return null.");
    }

    [TestMethod]
    public void GetAllBooks_ShouldReturnAllBooks()
    {
        Author author = new Author("John", "Doe");
        Book book0 = new Book("Book 0", author, 2020);
        Book book1 = new Book("Book 1", author, 2021);
        _library.add(book0);
        _library.add(book1);

        List<Book?> allBooks = _library.getAllBooks();

        Assert.AreEqual(2, allBooks.Count(), "The number of books retrieved does not match the number of books added.");
        CollectionAssert.Contains(allBooks, book0, "The retrieved books do not contain the first added book.");
        CollectionAssert.Contains(allBooks, book1, "The retrieved books do not contain the second added book.");
    }

    [TestMethod]
    public void GetBooksByAuthor_ShouldReturnMatchingBooks()
    {
        Author author0 = new Author("John", "Doe");
        Author author1 = new Author("Jane", "Doe");
        Author author2 = new Author("Bob", "Smith");

        Book book0 = new Book("Book 0", author0, 2020);
        Book book1 = new Book("Book 1", author1, 2021);
        Book book2 = new Book("Book 2", author2, 2022);

        _library.add(book0);
        _library.add(book1);
        _library.add(book2);

        List<Book?> result = _library.getBooksByAuthor("Doe");

        Assert.AreEqual(2, result.Count, "The number of books retrieved by author does not match the expected count.");
        CollectionAssert.Contains(result, book0, "The retrieved books do not contain the first matching book.");
        CollectionAssert.Contains(result, book1, "The retrieved books do not contain the second matching book.");
        CollectionAssert.DoesNotContain(result, book2, "The retrieved books contain a book that should not match.");
    }

    [TestMethod]
    public void GetBooksByAuthor_CaseInsensitive_ShouldReturnMatchingBooks()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Book 0", author, 2020);
        _library.add(book);

        List<Book?> result = _library.getBooksByAuthor("Doe");

        Assert.AreEqual(1, result.Count, "The number of books retrieved by author (case-insensitive) does not match the expected count.");
        CollectionAssert.Contains(result, book, "The retrieved books do not contain the matching book.");
    }

    [TestMethod]
    public void GetBookById_ExistingId_ShouldReturnBook()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", author, 2024);
        _library.add(book);

        Book? result = _library.getBookById(book.id);

        Assert.IsNotNull(result, "The retrieved book by ID is null.");
        Assert.AreEqual(book.id, result.Value.id, "The retrieved book's ID does not match the added book's ID.");
        Assert.AreEqual(book.title, result.Value.title, "The retrieved book's title does not match the added book's title.");
    }

    [TestMethod]
    public void GetBookById_NonExistentId_ShouldReturnNull()
    {
        Book? result = _library.getBookById(999);

        Assert.IsNull(result, "Retrieving a book by a non-existent ID did not return null.");
    }

    [TestMethod]
    public void GetBookByName_ExistingTitle_ShouldReturnBook()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Unique Title", author, 2024);
        _library.add(book);

        Book? result = _library.getBookByName("Unique Title");

        Assert.IsNotNull(result, "The retrieved book by title is null.");
        Assert.AreEqual(book.id, result.Value.id, "The retrieved book's ID does not match the added book's ID.");
    }

    [TestMethod]
    public void GetBookByName_NonExistentTitle_ShouldReturnNull()
    {
        Book? result = _library.getBookByName("Non Existent");

        Assert.IsNull(result, "Retrieving a book by a non-existent title did not return null.");
    }

    [TestMethod]
    public void GetBookByYear_ExistingYear_ShouldReturnBook()
    {
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", author, 2024);
        _library.add(book);

        Book? result = _library.getBookByYear(2024);

        Assert.IsNotNull(result, "The retrieved book by year is null.");
        Assert.AreEqual(book.id, result.Value.id, "The retrieved book's ID does not match the added book's ID.");
    }

    [TestMethod]
    public void GetBookByYear_NonExistentYear_ShouldReturnNull()
    {
        Book? result = _library.getBookByYear(1999);

        Assert.IsNull(result, "Retrieving a book by a non-existent year did not return null.");
    }

    [TestMethod]
    public void Count_ShouldReturnCorrectNumberOfBooks()
    {
        Author author = new Author("John", "Doe");
        Book book0 = new Book("Book 0", author, 2020);
        Book book1 = new Book("Book 1", author, 2021);
        Book book2 = new Book("Book 2", author, 2022);

        _library.add(book0);
        _library.add(book1);
        _library.add(book2);
        _library.remove(book0.id);

        Assert.AreEqual(2, _library.count(), "The library count does not match the expected number of books.");
    }
}