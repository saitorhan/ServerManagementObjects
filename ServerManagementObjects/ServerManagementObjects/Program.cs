using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace ServerManagementObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("SMO kütüphanesini oluşturma işlemi");

            SqlConnection sqlConnection = new SqlConnection("Data Source=localhost;Integrated Security=True");
            ServerConnection serverConnection = new ServerConnection(sqlConnection);
            Server server = new Server(serverConnection);

            //Database database = new Database(server, "Smo");
            //database.Create();
            //Console.WriteLine("Smo Veritabanı oluşturuldu.");

            //Database workDatabase = server.Databases["Smo"];

            //Table table = new Table(workDatabase, "People");

            //Table table = workDatabase.Tables["People"];

            //Column idColumn = new Column(table, "Id", DataType.Int);
            //idColumn.Identity = true;
            //table.Columns.Add(idColumn);

            //Column nameColumn = new Column(table, "Name", DataType.NVarChar(50));
            //nameColumn.Nullable = false;
            //table.Columns.Add(nameColumn);

            //table.Create();

            //Column surnameColumn = new Column(table, "Surname", DataType.NVarChar(50));
            //surnameColumn.Nullable = false;
            //table.Columns.Add(surnameColumn);

            //table.Alter();

            //Index primaryIndex = new Index(table, "PK_People");
            //primaryIndex.IndexKeyType = IndexKeyType.DriPrimaryKey;

            //IndexedColumn indexedColumn = new IndexedColumn(primaryIndex, "Id");
            //primaryIndex.IndexedColumns.Add(indexedColumn);
            //primaryIndex.Create();

            //Console.WriteLine("People tablosu güncellendi");

            //foreach (Database serverDatabase in server.Databases)
            //{
            Database serverDatabase = server.Databases["AdventureWorks2017"];
            Console.WriteLine(serverDatabase.Name);
                foreach (Table serverDatabaseTable in serverDatabase.Tables)
                {
                    Console.WriteLine($"--->{serverDatabaseTable.Name}");
                    foreach (Index index in serverDatabaseTable.Indexes)
                    {
                        Console.WriteLine($"------>{index.Name}");
                    }
                }
            //}

            Console.ReadLine();
        }
    }
}
