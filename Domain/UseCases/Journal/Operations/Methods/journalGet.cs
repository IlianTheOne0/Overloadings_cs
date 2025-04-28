namespace ClassLibrary.Journal;
using ClassLibrary.Journal.Entity;

public partial class Journal
{
    public virtual JournalEntity get(int id)
    {
        if (!_journal.TryGetValue(id, out JournalEntity entity)) { throw new KeyNotFoundException($"Entity with ID {id} not found."); }
        return entity;
    }
}