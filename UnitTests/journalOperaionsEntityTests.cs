namespace UnitTests.Journal.Methods;
using ClassLibrary.Journal.Entity;
using ClassLibrary.Journal;

[TestClass]
public sealed class JournalOperationsEntityTests
{
    private Journal _journal = null!;

    [TestInitialize]
    public void Initialize() => _journal = new Journal();

    [TestMethod]
    public void Journal_Add_NewEntity_Success()
    {
        JournalEntity entity = new JournalEntity("FirstNEW_ENTITY_SUCCES_TESTName", "LastNEW_ENTITY_SUCCES_TESTName", 145120.5m);
        int initialCount = _journal.getAll().Count();

        _journal.add(entity);

        Assert.AreEqual(entity, _journal.get(entity.id), "Entity was not added correctly.");
        Assert.AreEqual(initialCount + 1, _journal.getAll().Count(), "Entity count did not increase.");
    }

    [TestMethod]
    public void Journal_Add_MultipleEntities_Success()
    {
        JournalEntity entity1 = new JournalEntity("ZeroFirstMULTIPLE_ENTITIES_SUCCES_TESTName", "ZeroLastMULTIPLE_ENTITIES_SUCCES_TESTName", 100.5m);
        JournalEntity entity2 = new JournalEntity("FirstFirstMULTIPLE_ENTITIES_SUCCES_TESTName", "FirstLastMULTIPLE_ENTITIES_SUCCES_TESTName", 200.5m);

        _journal.add(entity1);
        _journal.add(entity2);

        Assert.AreEqual(entity1, _journal.get(entity1.id), "First entity was not added correctly.");
        Assert.AreEqual(entity2, _journal.get(entity2.id), "Second entity was not added correctly.");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Journal_Add_InvalidEntity_ThrowsArgumentException()
    {
        JournalEntity invalidEntity = new JournalEntity("", "", -100.0m);
        _journal.add(invalidEntity);
    }

    [TestMethod]
    public void Journal_Remove_Success()
    {
        JournalEntity entity = new JournalEntity("FirstREMOVE_SUCCES_TESTname", "LastREMOVE_SUCCES_TESTname", 100.5m);
        _journal.add(entity);
        int lastId = _journal.getAll().Count();

        _journal.remove(entity.id);

        Assert.AreEqual(lastId - 1, _journal.getAll().Count(), "Entity was not removed correctly.");
    }

    [TestMethod]
    public void Journal_Remove_AllEntities_Success()
    {
        JournalEntity entity1 = new JournalEntity("ZeroFirstREMOVE_ALLENTITIES_SUCCESSName", "ZeroLastREMOVE_ALLENTITIES_SUCCESSname", 100.5m);
        JournalEntity entity2 = new JournalEntity("FirstFirstREMOVE_ALLENTITIES_SUCCESSName", "FirstLastREMOVE_ALLENTITIES_SUCCESSname", 200.5m);

        _journal.add(entity1);
        _journal.add(entity2);

        foreach (JournalEntity entity in _journal.getAll()) { _journal.remove(entity.id); }

        Assert.AreEqual(0, _journal.getAll().Count(), "Not all entities were removed.");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Journal_Remove_InvalidOperationException()
    {
        int lastId = _journal.getAll().Count();
        _journal.remove(lastId + 1);
    }

    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void Journal_Get_InvalidOperationException()
    {
        int lastId = _journal.getAll().Count();

        _journal.get(lastId + 1);
    }

    [TestMethod]
    public void Journal_Update_Success()
    {
        JournalEntity entity = new JournalEntity("FirstUPDATE_SUCCESname", "LastUPDATE_SUCCESname", 100.5m);
        JournalEntity entityEdited = new JournalEntity("FirstUPDATE_SUCCESnameEdited", "LastUPDATE_SUCCESnameEdited", 200.5m);

        entityEdited.id = entity.id;

        _journal.add(entity);
        int lastId = _journal.getAll().Count();

        _journal.update(entity.id, entityEdited);

        Assert.AreEqual(entityEdited, _journal.get(lastId - 1), "Entity was not updated correctly.");
    }

    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void Journal_Update_InvalidOperationException()
    {
        JournalEntity entity = new JournalEntity("FirstUPDATE_INVALID...name", "LastUPDATE_INVALID...name", 100.5m);
        JournalEntity entityEdited = new JournalEntity("FirstUPDATE_INVALID...nameEdited", "LastUPDATE_INVALID...nameEdited", 200.5m);
        _journal.add(entity);
        int lastId = _journal.getAll().Count();

        _journal.update(lastId + 1, entityEdited);
    }
}