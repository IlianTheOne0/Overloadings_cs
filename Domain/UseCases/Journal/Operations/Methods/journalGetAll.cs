namespace ClassLibrary.Journal;
using ClassLibrary.Journal.Entity;

public partial class Journal
{
    public virtual IEnumerable<JournalEntity> getAll()
    {
        if (_journal.Count == 0) { throw new KeyNotFoundException("Entities not found!"); }
        return _journal.Values.ToList();
    }
}