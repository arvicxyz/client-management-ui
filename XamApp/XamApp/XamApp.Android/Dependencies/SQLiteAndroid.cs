using SQLite;
using System;
using System.IO;
using XamApp.Droid.Dependencies;
using XamApp.Models.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace XamApp.Droid.Dependencies
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "AppSQLite.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}
