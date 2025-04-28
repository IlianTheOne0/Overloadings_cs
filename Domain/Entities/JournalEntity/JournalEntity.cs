namespace ClassLibrary.Journal.Entity;

public struct JournalEntity
{
    public string firstName { get; private set; }
    public string lastName { get; private set; }
    public decimal salary { get; private set; }
    public int id { get; set; }
    private static int _idCounter = 0;

    public JournalEntity() { throw new NotSupportedException("Parameterless constructor is not supported for JournalEntity."); }
    public JournalEntity(string _firstName, string _lastName, decimal? _salary = null)
    {
        firstName = _firstName;
        lastName = _lastName;
        salary = (_salary ?? 0.0m) < 0 ? throw new ArgumentException("Salary cannot be negative.") : _salary ?? 0.0m;
        id = _idCounter++;
    }
}