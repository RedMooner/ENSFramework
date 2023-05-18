# EasyNoSql framework
![Group 1 (1)](https://github.com/RedMooner/ENSFramework/assets/47520961/7f7e3a96-7b11-444e-b5d1-4e8140d36591)
 [![Typing SVG](https://readme-typing-svg.demolab.com?font=Fira+Code&size=23&pause=1000&width=435&lines=Create+your+databases+easier)](https://git.io/typing-svg)

We are pleased to introduce our new library for creating NoSQL databases. This library is intended for developers who are looking for a simple and effective way to create a NoSQL database.

The library provides powerful functions for creating, updating and managing NoSQL databases. It integrates seamlessly with any project and allows you to quickly create databases that can store large amounts of data without using schemas and queries.

We are confident that our library will make the process of creating NoSQL databases easier and faster for developers. It also provides the ability to create distributed databases, which makes it an ideal solution for large and complex projects.

Download our library right now and start creating your NoSQL databases today!
Create diffrent entities   
# Plans
- Creation of documentation for NOSQL library
- Study of existing solutions for NOSQL storage
- Implementation of clustering support in the NOSQL library
- Creation of a demo project based on the NOSQL library
- Development of tests to test the functionality of the NOSQL library
- Performance optimization of NOSQL library
- Implementation of the data replication algorithm in the NOSQL library
- Creating a graphical interface for managing NOSQL storage
- Support for the extensibility of the NOSQL library via plugins
- Integration of NOSQL library with various programming languages
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




