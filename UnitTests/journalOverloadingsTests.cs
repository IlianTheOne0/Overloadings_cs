namespace UnitTests.Journal.Overloadings;
using ClassLibrary.Journal;

[TestClass]
public sealed class JournalOverloadingsTests
{
    private Journal _journal = null!;
    private Journal _anotherJournal = null!;

    [TestInitialize]
    public void Initialize() { _journal = new Journal(); _anotherJournal = new Journal(); }

    [TestMethod]
    public void Operator_Add_AddsEntitiesToJournal()
    {
        _journal += 3;

        Assert.AreEqual(3, _journal.getAll().Count(), "The number of entities in the journal after addition is incorrect.");
    }

    [TestMethod]
    public void Operator_Subtract_RemovesEntitiesFromJournal()
    {
        _journal += 5;

        _journal -= 2;

        Assert.AreEqual(3, _journal.getAll().Count(), "The number of entities in the journal after subtraction is incorrect.");
    }

    [TestMethod]
    public void Operator_Equality_ReturnsTrueForEqualJournals()
    {
        _journal += 3;
        _anotherJournal += 3;

        bool areEqual = _journal == _anotherJournal;

        Assert.IsTrue(areEqual, "The equality operator did not return true for journals with the same entities.");
    }

    [TestMethod]
    public void Operator_Inequality_ReturnsTrueForDifferentJournals()
    {
        _journal += 3;
        _anotherJournal += 2;

        bool areNotEqual = _journal != _anotherJournal;

        Assert.IsTrue(areNotEqual, "The inequality operator did not return true for journals with different entities.");
    }

    [TestMethod]
    public void Operator_LessThan_ReturnsTrueWhenLeftIsSmaller()
    {
        _journal += 2;
        _anotherJournal += 3;

        bool isLessThan = _journal < _anotherJournal;

        Assert.IsTrue(isLessThan, "The less-than operator did not return true when the left journal had fewer entities.");
    }

    [TestMethod]
    public void Operator_GreaterThan_ReturnsTrueWhenLeftIsLarger()
    {
        _journal += 4;
        _anotherJournal += 3;

        bool isGreaterThan = _journal > _anotherJournal;

        Assert.IsTrue(isGreaterThan, "The greater-than operator did not return true when the left journal had more entities.");
    }
}