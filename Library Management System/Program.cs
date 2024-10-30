using Library_Management_System;
using System;
using System.Collections.Generic;

namespace LibraryManagemt
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBook(new Book("If Beale Street Could Talk", "James Baldwin", "999777"));
            library.AddBook(new Book("In Cold Blood", "Truman Capote", "887766"));

            Console.WriteLine("Books in the library:");
            library.DisplayBooks();


            library.RegisterMember(new Member("Scott", "1"));
            library.RegisterMember(new Member("Carey", "2"));

            bool exit = false;
            while(exit == false)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. return Book");
                Console.WriteLine("4. Register Member");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();
                        library.AddBook(new Book(title, author, isbn));
                        break;
                    case "2":
                        Console.WriteLine("Enter Member ID: ");
                        string memberId = Console.ReadLine();
                        Console.WriteLine("Enter ISBN: ");
                        isbn = Console.ReadLine();
                        library.BorrowBook(memberId, isbn);
                        break;
                    case "3":
                        Console.WriteLine("Enter Member ID: ");
                        memberId = Console.ReadLine();
                        Console.WriteLine("Enter ISBN: ");
                        isbn = Console.ReadLine();
                        library.ReturnBook(memberId, isbn);
                        break;
                    case "4":
                        Console.WriteLine("Enter member name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Member ID");
                        memberId = Console.ReadLine();
                        library.RegisterMember(new Member(name, memberId));
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. please try again!");
                        break;
                }
            }
        }
    }
}

