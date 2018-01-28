using System.IO;
using Windows.Storage;
using DataAccess.UWP;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb))]
namespace DataAccess.UWP
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentPath, "MYDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
