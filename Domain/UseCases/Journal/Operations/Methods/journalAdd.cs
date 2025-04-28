namespace ClassLibrary.Journal;
using ClassLibrary.Journal.Entity;

public partial class Journal
{
    public virtual void add(JournalEntity entity)
    {
        if (_journal.ContainsKey(entity.id))  { throw new InvalidOperationException($"Entity with ID {entity.id} already exists."); }
        if (!_journal.ContainsKey(entity.id))  { _journal[entity.id] = entity; }
    }
}