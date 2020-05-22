using SQLite;
using System;
using System.IO;
using XamApp.iOS.Dependencies;
using XamApp.Models.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteiOS))]
namespace XamApp.iOS.Dependencies
{
    public class SQLiteiOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "AppSQLite.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}
