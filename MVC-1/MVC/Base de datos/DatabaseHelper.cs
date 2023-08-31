using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    using System.Data.SQLite;

    public class DatabaseHelper
    {
        private static string path = "E:\\bootcamp\\BACKEND\\jpg-fe-gc-MVC\\MVC\\MVC\\Base de datos\\EmbeddedBD.db";
        string connectionString = $"Data Source={path}";
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }

}
