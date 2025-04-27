namespace ClassLibrary.Journal.Entity;

public struct JournalEntity
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public decimal? salary { get; set; } = null;
    public int id { get; set; }
    private static int _idCounter = 0;

    public JournalEntity(string _firstName, string _lastName, decimal _salary)
    {
        firstName = _firstName;
        lastName = _lastName;
        salary = _salary;
        id = _idCounter++;
    }
}