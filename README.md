# EasyNoSql framework
We are pleased to introduce our new library for creating NoSQL databases. This library is intended for developers who are looking for a simple and effective way to create a NoSQL database.

The library provides powerful functions for creating, updating and managing NoSQL databases. It integrates seamlessly with any project and allows you to quickly create databases that can store large amounts of data without using schemas and queries.

We are confident that our library will make the process of creating NoSQL databases easier and faster for developers. It also provides the ability to create distributed databases, which makes it an ideal solution for large and complex projects.

Download our library right now and start creating your NoSQL databases today!
Create diffrent entities   
# Usage
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

## Example 
![image](https://github.com/RedMooner/ENSFramework/assets/47520961/e8a39756-56f7-4a1c-8f4c-640747f8efad)

