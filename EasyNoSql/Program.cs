using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.PortableExecutable;

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

        private static MySqlConnection _connection;
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
                _connection = new MySqlConnection($"server={Server};user={Username};database={Name};password={Password};Port={Port}");
                _connection.Open();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Connection creation error, please check logs! " + ex.Message);
            }
        }
        private bool CheckExistence()
        {
            return false;
        }
        public static MySqlDataReader Query(string sql)
        {
            _connection.Open();
            MySqlCommand command = new MySqlCommand(sql, _connection);
            return command.ExecuteReader();
        }
        private string TestConnection()
        {
            return _connection.State.ToString();
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
        public static T MapToClass<T>(MySqlDataReader reader) where T : class
        {
            T returnedObject = Activator.CreateInstance<T>();
            List<PropertyInfo> modelProperties = returnedObject.GetType().GetProperties().OrderBy(p => p.MetadataToken).ToList();
            for (int i = 0; i < modelProperties.Count; i++)
                modelProperties[i].SetValue(returnedObject, Convert.ChangeType(reader.GetValue(i), modelProperties[i].PropertyType), null);
            return returnedObject;
        }
    }

    public interface ITable
    {
        int Id { get; set; }
    }
    public abstract class Table<T> : ITable where T : class, new()
    {
        public int Id { get; set; }
        public static List<T> GetData()
        {
            var reader = DataBase.Query("select * from " + typeof(T).Name);

            List<T> list = new List<T>();
           
            T obj = new T();
            while (reader.Read())
            {
                obj = DataBase.MapToClass<T>(reader);
                list.Add(obj);
            }
            return list;
        }
        public static void InsertData(T obj)
        {

        }
        public static void DeleteData(T obj)
        {

        }
        public static void UpdateData(T obj)
        {

        }
    }
    #region TESTING
    public class Users : Table<Users>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class Orders : Table<Orders>
    {
        public int User { get; set; }
        public string Title { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DataBase dataBase = new DataBase("test", 3307, "localhost", "", "root");
            Debug.WriteLine(Users.GetData()[0].Id);
            Console.Read();
        }
    }
    #endregion
}