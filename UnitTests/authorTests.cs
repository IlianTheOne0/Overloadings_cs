namespace UnitTest.Library.Entity.Author;
using ClassLibrary.Library.Entity;
using System.Reflection;

[TestClass]
public class AuthorTests
{
    [TestInitialize]
    public void TestInitialize() { ResetStaticIdCounter(typeof(Author)); }

    private void ResetStaticIdCounter(Type type)
    {
        FieldInfo? idCounterField = type.GetField("_idCounter", BindingFlags.Static | BindingFlags.NonPublic) ?? throw new KeyNotFoundException("The static field \"_idCounter\" was not found in the specified type.");
        idCounterField?.SetValue(null, 0);
    }

    [TestMethod]
    public void Constructor_InitializesProperties()
    {
        Author author = new Author("John", "Doe");

        int id = GetPrivateId(author);
        string firstName = author.firstName;
        string lastName = author.lastName;

        Assert.AreEqual("John", firstName, "Author's first name was not initialized correctly.");
        Assert.AreEqual("Doe", lastName, "Author's last name was not initialized correctly.");
        Assert.AreEqual(0, id, "Author's ID was not initialized correctly.");
    }

    [TestMethod]
    public void Id_AutoIncrementsCorrectly()
    {
        Author author0 = new Author("Jane", "Smith");
        Author author1 = new Author("Alice", "Johnson");

        int id0 = GetPrivateId(author0);
        int id1 = GetPrivateId(author1);

        Assert.AreEqual(0, id0, "The ID of the first author was not set to 0.");
        Assert.AreEqual(1, id1, "The ID of the second author was not incremented correctly.");
    }

    [TestMethod]
    public void ToString_FormatsCorrectly()
    {
        Author author = new Author("Alice", "Johnson");
        string expected = "Alice Johnson";

        string result = author.ToString();

        Assert.AreEqual(expected, result, "The ToString method did not return the expected format.");
    }

    private int GetPrivateId(Author author)
    {
        PropertyInfo idProperty = typeof(Author).GetProperty("id", BindingFlags.NonPublic | BindingFlags.Instance) ?? throw new KeyNotFoundException("The field \"id\" was not found in the specified type.");
        return (int)(idProperty.GetValue(author) ?? throw new InvalidOperationException("The value of the 'id' property is null."));
    }
}