namespace UnitTest.Library.Overloads;
using ClassLibrary.Library;
using ClassLibrary.Library.Entity;
using System.Reflection;

[TestClass]
public class LibraryOverloadsTests
{
    private Library _library = null!;
    private Author _author;
    private Book _book;

    [TestInitialize]
    public void TestInitialize()
    {
        _library = new Library();
        _author = new Author("John", "Doe");
        _book = new Book("Test Book", _author, 2024);

        ResetStaticIdCounter(typeof(Book));
        ResetStaticIdCounter(typeof(Author));
    }

    private void ResetStaticIdCounter(Type type)
    {
        FieldInfo? idCounterField = type.GetField("_idCounter", BindingFlags.Static | BindingFlags.NonPublic) ?? throw new KeyNotFoundException("The static field \"_idCounter\" was not found in the specified type.");
        idCounterField?.SetValue(null, 0); ;
    }

    [TestMethod]
    public void OperatorPlus_AddsBook_ShouldIncreaseCount()
    {
        _library += _book;

        Assert.AreEqual(1, _library.count());
        Assert.IsNotNull(_library.getBookById(_book.id));
    }

    [TestMethod]
    public void OperatorMinus_RemovesBook_ShouldDecreaseCount()
    {
        _library += _book;
        _library -= _book;

        Assert.AreEqual(0, _library.count());
        Assert.IsNull(_library.getBookById(_book.id));
    }

    [TestMethod]
    public void IndexerGet_ValidIndex_ReturnsBook()
    {
        _library += _book;

        Book? retrievedBook = _library[0] ?? throw new KeyNotFoundException($"The book with id 0 was not found.");

        Assert.AreEqual(_book.id, retrievedBook?.id);
        Assert.AreEqual(_book.title, retrievedBook?.title);
    }

    [TestMethod]
    public void IndexerSet_ValidIndex_SetsBook()
    {
        _library += _book;
        Book newBook = new Book("New Book", _author, 2025);

        _library[0] = newBook;

        Assert.AreEqual(newBook.id, _library[0]?.id);
        Assert.AreEqual("New Book", _library[0]?.title);
    }

    [TestMethod]
    public void IndexerSet_NullValue_ThrowsArgumentNullException()
    {
        _library += _book;

        Assert.ThrowsException<ArgumentNullException>(() => _library[0] = null);
    }
}