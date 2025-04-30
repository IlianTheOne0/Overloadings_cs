namespace ClassLibrary.Library.Entity;

public partial struct Author
{
    public Author(string _firstName, string _lastName)
    {
        id = _idCounter++;
        firstName = _firstName;
        lastName = _lastName;
    }
}

public partial struct Book
{
    public Book(string _title, Author _author, int _year)
    {
        id = _idCounter++;
        title = _title;
        author = _author;
        year = _year;
    }
}