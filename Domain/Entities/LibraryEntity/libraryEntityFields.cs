namespace ClassLibrary.Library.Entity;

public partial struct Author
{
    private static int _idCounter = 0;
    private int id { get; }

    public string firstName { get; set; }
    public string lastName { get; set; }
}

public partial struct Book
{
    private static int _idCounter = 0;
    public int id { get; }
    
    public string title { get; set; }
    public Author author { get; set; }
    public int year { get; set; }
}