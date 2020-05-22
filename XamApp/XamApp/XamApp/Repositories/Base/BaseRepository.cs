using SQLite;
using XamApp.Models.Interfaces;
using Xamarin.Forms;

namespace XamApp.Repositories
{
    public class BaseRepository<T> where T : IBaseLocalModel
    {
        protected readonly SQLiteConnection _connection;

        public BaseRepository()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<T>();
        }

        public int SaveItem(T item)
        {
            return _connection.Insert(item);
        }

        public int UpdateItem(T item)
        {
            return _connection.Update(item);
        }

        public int DeleteItem(T item)
        {
            return _connection.Delete(item);
        }

        public int DeleteItem(int id)
        {
            return _connection.Delete(id);
        }
    }
}
