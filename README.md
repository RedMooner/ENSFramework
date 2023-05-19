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

# Entity?
Entity Framework is an Object Relational Mapping (ORM) tool that allows developers to work with databases using an object-oriented approach. However, this tool has its drawbacks:

1. **Performance**: Entity Framework may be slower than working directly with the database. This is especially noticeable when performing complex queries.
2. **Difficulty in setting up**: Setting up the Entity Framework can be difficult and take a lot of time. It is necessary to properly configure the database context, mappings and other parameters to get good performance.
3. **Limitations in queries**: Entity Framework can sometimes limit the ability to write complex queries. For example, queries using multiple UNION operators can be difficult.
4. **Migration Issues**: Migration issues may occur when updating the database model. Sometimes Entity Framework cannot apply changes to the database correctly, which leads to errors.
5. **Debugging Complexity**: Debugging Entity Framework can be difficult. Errors may not be obvious and require a lot of time to fix them.

In general, Entity Framework is a powerful tool that can speed up application development. However, developers should be careful when using it to avoid performance, configuration, and debugging issues.
Since I myself faced a number of problems, I decided to create exactly what I need for my needs
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

      public class Program
        {
            public static void Main(string[] args)
            {
                DataBase dataBase = new DataBase();
                dataBase.Migrate();
                Console.Read();
            }
        }




