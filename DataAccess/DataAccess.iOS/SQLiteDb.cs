using System;
using System.IO;
using Xamarin.Forms;
using DataAccess.iOS;
using SQLite;

[assembly: Dependency(typeof(SQLiteDb))]
namespace DataAccess.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MYDB.db3");
            return new SQLiteAsyncConnection(path);
        }

    }
}