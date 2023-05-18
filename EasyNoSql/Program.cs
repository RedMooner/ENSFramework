using System.Reflection;

namespace ENS
{
    public class DataBase
    {
        public string Name { get; set; }
        public DataBase()
        {
            Name = "somedb";
        }
        public void MakeMigrations()
        {

        }
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
    public class Orders  : ITable
    {
        public int Id { get; set; }
        public int User { get; set; }
        public string Title { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            dataBase.Migrate();
            Console.Read();
        }
    }
    #endregion
}