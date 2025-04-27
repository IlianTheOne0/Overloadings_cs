namespace ClassLibrary.Journal;

using ClassLibrary.Journal.Entity;
using ClassLibrary.Journal.Interface;

public partial class Journal : IJournal { private readonly Dictionary<int, JournalEntity> _journal = new(); }