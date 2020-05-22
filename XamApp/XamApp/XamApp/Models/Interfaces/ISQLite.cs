using SQLite;

namespace XamApp.Models.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
