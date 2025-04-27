namespace ClassLibrary.Journal;
using ClassLibrary.Journal.Entity;

public partial class Journal
{
    public static Journal operator +(Journal journal, int count)
    {
        for (int i = 0; i < count; i++) { JournalEntity entity = new JournalEntity("Default", "User", 0); journal.add(entity); }
        return journal;
    }

    public static Journal operator -(Journal journal, int count)
    {
        if (count <= 0) { return journal; }
        List<int> ids = journal._journal.Keys.OrderByDescending(k => k).Take(count).ToList();
        foreach (int id in ids) { journal.remove(id); }
        return journal;
    }

    public static bool operator ==(Journal left, Journal right)
    {
        if (ReferenceEquals(left, right)) { return true; }
        if (left is null || right is null) { return false; }
        return left._journal.Count == right._journal.Count;
    }

    public static bool operator !=(Journal left, Journal right) => !(left == right);

    public static bool operator <(Journal left, Journal right)
    {
        if (left is null) { return right is not null; }
        return left._journal.Count < right._journal.Count;
    }

    public static bool operator >(Journal left, Journal right)
    {
        if (left is null) { return false; }
        return left._journal.Count > right._journal.Count;
    }

    public override bool Equals(object? obj) => obj is Journal other && this == other;
}