namespace ClassLibrary.Journal;

public partial class Journal
{
    public virtual void remove(int id)
    {
        if (!_journal.ContainsKey(id)) { throw new InvalidOperationException($"Entity with ID {id} not found."); }
        _journal.Remove(id);
    }
}
