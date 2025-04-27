namespace ClassLibrary.Journal.Interface;
using ClassLibrary.Journal.Entity;

public interface IJournal
{
    void add(JournalEntity employee);
    void remove(int id);
    void update(int id, JournalEntity employee);
    JournalEntity get(int id);
    IEnumerable<JournalEntity> getAll();
}