using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Reflection;

namespace ENS
{
    public class DataBase
    {
        #region Properties
        public string Name { get; private set; }
        public int Port { get; private set; }
        public string Server { get; private set; }
        private string Password { get; set; }
        private string Username { get; set; }

        private MySqlConnection _connection;
        public DataBase(string name, int port, string server, string password, string username)
        {
            Name = name;
            Port = port;
            Server = server;
            Password = password;
            Username = username;
            CreateConnection();
        }

        #endregion
        #region SQLworkMethods
        private void CreateConnection()
        {
            try
            {
                _connection = new MySqlConnection($"database={Name},server={Server},port={Port},username={Username},pwd={Password}");
                _connection.Open();
                _connection.Close();
            }
            catch
            {
                Debug.WriteLine("Connection creation error, please check logs!");
            }
        }
        private bool CheckExistence()
        {
            return false;
        }
        private MySqlDataReader Query(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql,_connection);
            return command.ExecuteReader();
        }
        #endregion
        #region Migrations
        public void Migrate()
        {
            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(ITable))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as ITable;

            Directory.CreateDirectory("migration-db-" + Name + "-" + DateTime.Today.Date.Hour + new Random().Next(0, 1));
            foreach (var table in instances)
            {
                Console.WriteLine("Create table " + table.GetType().Name);
                foreach (var item in table.GetType().GetProperties())
                {
                    Console.WriteLine("Create field... " + item.PropertyType + ", " + item.Name + "...");
                }
                Console.WriteLine("Done!");
            }
        }
        #endregion
    }

    public interface ITable
    {
        int Id { get; set; }
    }

    #region TESTING
    public class Users : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class Orders : ITable
    {
        public int Id { get; set; }
        public int User { get; set; }
        public string Title { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DataBase dataBase = new DataBase("test", 3307, "localhost", "", "root");
            dataBase.Migrate();
            Console.Read();
        }
    }
    #endregion
}