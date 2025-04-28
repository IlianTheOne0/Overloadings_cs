namespace UnitTests.JournalEntity;
using ClassLibrary.Journal.Entity;

[TestClass]
public sealed class JournalEntityTests
{
    [TestMethod]
    [ExpectedException(typeof(NotSupportedException))]
    public void JournalEntity_Creating_Parameterless()
    {
        JournalEntity journalEntity = new JournalEntity();
    }

    [TestMethod]
    public void JournalEntity_Creating_Parameter_WithoutSalary()
    {
        JournalEntity journalEntity = new JournalEntity("First name", "Last name");

        Assert.AreEqual("First name", journalEntity.firstName, "First name was not added correctly.");
        Assert.AreEqual("Last name", journalEntity.lastName, "Last name was not added correctly.");
        Assert.AreEqual(0.0m, journalEntity.salary, "Salary was not added correctly.");
    }

    [TestMethod]
    public void JournalEntity_Creating_Parameter_WithSalary()
    {
        JournalEntity journalEntity = new JournalEntity("First name", "Last name", 100.5m);

        Assert.AreEqual("First name", journalEntity.firstName, "First name was not added correctly.");
        Assert.AreEqual("Last name", journalEntity.lastName, "Last name was not added correctly.");
        Assert.AreEqual(100.5m, journalEntity.salary, "Salary was not added correctly.");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void JournalEntity_Creating_WithNegativeSalary()
    {
        JournalEntity journalEntity = new JournalEntity("First name", "LastName", -100.5m);
    }

    [TestMethod]
    public void JournalEntity_Id_IsUniqueAndIncrementing()
    {
        JournalEntity journalEntity1 = new JournalEntity("First name", "LastName");
        JournalEntity journalEntity2 = new JournalEntity("Another name", "AnotherLastName");

        Assert.AreNotEqual(journalEntity1.id, journalEntity2.id, "IDs should be unique for each JournalEntity instance.");
        Assert.AreEqual(journalEntity1.id + 1, journalEntity2.id, "IDs should increment sequentially for each new JournalEntity instance.");
    }
}