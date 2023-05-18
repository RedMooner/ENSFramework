#EasyNoSql framework
Create diffrent entities   

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

Create migrations


      public class Program
        {
            public static void Main(string[] args)
            {
                DataBase dataBase = new DataBase();
                dataBase.Migrate();
                Console.Read();
            }
        }

