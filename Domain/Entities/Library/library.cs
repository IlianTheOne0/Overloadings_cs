namespace ClassLibrary.Library;
using ClassLibrary.Library.Interface;
using ClassLibrary.Library.Entity;

public partial class Library : IJournal
{
    private readonly List<Book?> _library;

    public Library() { _library = new List<Book?>(); }
}