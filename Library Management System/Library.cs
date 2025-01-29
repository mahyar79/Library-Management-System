using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Library
    {
        private List<Book> _books;
        private List<Member> _members;

        public Library()
        {
            _books = new List<Book>();
            _members = new List<Member>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine("Book added successfully");
        }

        public void RemoveBook(string isbn)
        {
            var bookToRemove = _books.Find(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
                Console.WriteLine($"Book {bookToRemove.Title} removed successfully");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        public void DisplayBooks()
        {

            Console.WriteLine("\nBooks in the Library");
            foreach (var book in _books)
            {
                book.DisplayInfo();
            }
        }


        public void RegisterMember(Member member)
        {
            _members.Add(member);
            Console.WriteLine($"Member {member.Name} registered successfully");
        }
        public void DisplayMembers()
        {
            Console.WriteLine("\nRegistered Members: ");
            foreach(var members in _members)
            {
                members.DisplayMemberInfo();
            }
        }
    }
}
