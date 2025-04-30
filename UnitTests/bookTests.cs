namespace UnitTest.Library.Entity.Book;
using ClassLibrary.Library.Entity;
using System.Reflection;

[TestClass]
public class BookTests
{
    [TestInitialize]
    public void TestInitialize()
    {
        ResetStaticIdCounter(typeof(Book));
        ResetStaticIdCounter(typeof(Author));
    }

    private void ResetStaticIdCounter(Type type)
    {
        FieldInfo? idCounterField = type.GetField("_idCounter", BindingFlags.Static | BindingFlags.NonPublic) ?? throw new KeyNotFoundException("The static field \"_idCounter\" was not found in the specified type.");
        idCounterField?.SetValue(null, 0);
    }

    [TestMethod]
    public void Constructor_InitializesProperties()
    {
        Author author = new Author("John", "Doe");
        const string title = "C# Basics";
        const int year = 2023;

        Book book = new Book(title, author, year);

        Assert.AreEqual(title, book.title, "Book title was not initialized correctly.");
        Assert.AreEqual(author, book.author, "Book author was not initialized correctly.");
        Assert.AreEqual(year, book.year, "Book year was not initialized correctly.");
        Assert.AreEqual(0, book.id, "Book ID was not initialized correctly.");
    }

    [TestMethod]
    public void Id_AutoIncrementsCorrectly()
    {
        Author author = new Author("Jane", "Smith");
        Book book0 = new Book("Book 1", author, 2020);
        Book book1 = new Book("Book 2", author, 2021);

        Assert.AreEqual(0, book0.id, "First book ID did not auto-increment correctly.");
        Assert.AreEqual(1, book1.id, "Second book ID did not auto-increment correctly.");
    }

    [TestMethod]
    public void ToString_FormatsCorrectly()
    {
        Author author = new Author("Alice", "Johnson");
        Book book = new Book("Advanced C#", author, 2024);
        string expected = "Advanced C# by Alice Johnson (2024)";

        string result = book.ToString();

        Assert.AreEqual(expected, result, "Book.ToString() did not format the string correctly.");
    }
}