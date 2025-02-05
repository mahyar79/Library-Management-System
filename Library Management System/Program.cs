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
                Console.WriteLine("\n\nLibrary Management System\n");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Display Books");
                Console.WriteLine("3. Remove book");
                Console.WriteLine("4. Register Member");
                Console.WriteLine("5. Display Members");
                Console.WriteLine("6. Borrow Book");
                Console.WriteLine("7. Return Book");
                Console.WriteLine("8. Exit");
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
                        library.AddBook(new Book { Title = title, Author = author, ISBN = isbn, Id = Convert.ToInt32(isbn),  IsBorrowed = false });
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
                        
                        library.RegisterMember(new Member { Name = name });
                        break;
                    case"5":
                        library.DisplayMembers();
                        break;
                    case "6":
                        Console.WriteLine("Please Enter BookId");

                        int borrowBookId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please Enter MemerId");
                        int borrowMemberId = Convert.ToInt32(Console.ReadLine());
                        library.BorrowBook(borrowBookId, borrowMemberId);
                        break;
                    case "7":
                        Console.WriteLine("Please Enter BookId");

                        int returnBookId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please Enter MemerId");
                        int returnMemberId = Convert.ToInt32(Console.ReadLine());
                        library.ReturnBook(returnBookId, returnMemberId);
                        break;


                    case "8":
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