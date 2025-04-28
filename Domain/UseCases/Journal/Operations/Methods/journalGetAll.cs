namespace ClassLibrary.Journal;
using ClassLibrary.Journal.Entity;

public partial class Journal
{
    public virtual IEnumerable<JournalEntity> getAll() => _journal.Values.ToList();
}