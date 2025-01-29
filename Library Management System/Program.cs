using System;


namespace Library_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Display Books");
                Console.WriteLine("3. Remove book");
                Console.WriteLine("4. Register Member");
                Console.WriteLine("5. Display Members");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        Console.WriteLine("Enter Book title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter author: ");
                        string author = Console.ReadLine();

                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();

                        Book newBook = new Book(title, author, isbn);
                        library.AddBook(newBook);
                        break;
                    case "2":
                        library.DisplayBooks();
                        break;
                    case "3":
                        Console.Write("Enter the ISBN of the book to remove: ");
                        string removeIsbn = Console.ReadLine();
                        library.RemoveBook(removeIsbn);
                        break;
                    case "4":
                        Console.Write("Enter member's name: ");
                            string name = Console.ReadLine();
                        Console.Write(("Enter member ID: "));
                        string memberId = Console.ReadLine();
                        library.RegisterMember(new Member(name, memberId));
                        break;
                    case"5":
                        library.DisplayMembers();
                        break;

                    case "6":
                        exit = true;
                        Console.Write("Exiting...");
                        break;
                    default:
                        Console.Write("Invalid Option! try again");
                        break;

                }
            }
        }
    }
}