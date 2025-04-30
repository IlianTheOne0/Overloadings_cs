namespace ClassLibrary.Library;
using ClassLibrary.Library.Entity;

public partial class Library
{
    public static Library operator +(Library list, Book book) { list.add(book); return list; }
    public static Library operator -(Library list, Book book) { list.remove(book); return list; }

    public Book? this[int id]
    {
        get => _library[id];
        set
        {
            if (value is not null) { _library[id] = value; }
            else { throw new ArgumentNullException(nameof(value), "Book cannot be null."); }
        }
    }
}