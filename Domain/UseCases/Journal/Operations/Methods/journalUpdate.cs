namespace ClassLibrary.Journal;
using ClassLibrary.Journal.Entity;

public partial class Journal
{
    public virtual void update(int id, JournalEntity entity)
    {
        if (!_journal.ContainsKey(id)) { throw new KeyNotFoundException($"Entity with ID {id} not found!"); }
        entity.id = id;
        _journal[id] = entity;
    }
}