namespace ClassLibrary.Library.Entity;

public partial struct Author
{
    public override string ToString() => $"{firstName} {lastName}";
}

public partial struct Book
{
    public override string ToString() => $"{title} by {author} ({year})";
}