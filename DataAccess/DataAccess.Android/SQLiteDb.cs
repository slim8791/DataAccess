using System;
using System.IO;
using Xamarin.Forms;
using DataAccess.Droid;
using SQLite;

[assembly:Dependency(typeof(SQLiteDb))]
namespace DataAccess.Droid
{
   public  class SQLiteDb : ISQLiteDb
    {
       public SQLiteAsyncConnection GetConnection()
       {
          
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
           var path = Path.Combine(documentPath, "MYDB2.db3");
            return  new SQLiteAsyncConnection(path);
       }

    }
}