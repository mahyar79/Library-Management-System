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
        private LibraryDbContext _db;

        public Library()
        {
           _books = new List<Book>();
            _members = new List<Member>();
            _db = new LibraryDbContext();
        }

        public void AddBook(Book book)
        {
            
                _db.Books.Add(book);
                _db.SaveChanges();
                Console.WriteLine("Book added successfully");
            
        }

        public void RemoveBook(string isbn)
        {
            
                var bookToRemove = _db.Books.FirstOrDefault(b => b.ISBN == isbn);
                if(bookToRemove != null)
                {
                    _db.Books.Remove(bookToRemove);
                    _db.SaveChanges();
                    Console.WriteLine("Removed Successfully");
                }
                else
                {
                    Console.WriteLine("Book not found!");
                }
            
            
           
        }

        public void DisplayBooks()
        {
           
                var _books = _db.Books.ToList();
                if (_books.Count == 0)
                {
                    Console.WriteLine("No books found!");
                }

                Console.WriteLine("\nBooks in the Library:");
                foreach (var book in _books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Borrowed: {book.IsBorrowed}");
                }
        }


        public void RegisterMember(Member member)
        {
            {
           
                _db.Members.Add(member);
                _db.SaveChanges();
                Console.WriteLine($"Member {member.Name} registered successfully");
            }
        }
        public void DisplayMembers()
        {
                var _members = _db.Members.ToList();
                if ( _members.Count == 0)
                {
                    Console.WriteLine("No members registered.");
                    return;
                }
                Console.WriteLine("\nRegistered Members: ");
                foreach (var members in _members)
                {
                    Console.WriteLine($"ID: {members.Id}, Name: {members.Name}");
                }         
        }

        public void BorrowBook(int bookId, int memberId)
        {
            var member = _db.Members.Find(memberId);
            var book = _db.Books.Find(bookId);
            if (book == null)
            {
                Console.WriteLine("book not found!");
               
            }
            if(member == null)
            {
                Console.WriteLine("Member not found!");
            }
            if (book.IsBorrowed)
            {
                Console.WriteLine($"Sorry! the {book.Title} is already borrowed");
                return;
            }
            book.IsBorrowed = true;
            book.BorrowedByMemberId = memberId;
            _db.SaveChanges();

            Console.WriteLine($"The book: {book.Title} has been borrowed by {member.Name}");

        }

        public void ReturnBook(int bookId, int memberId)
        {
            var member = _db.Members.Find(memberId);
            var book = _db.Books.Find(bookId);
            if (book == null)
            {
                Console.WriteLine("Book not Found");
                return;
            }
            if (!book.IsBorrowed)
            {
                Console.WriteLine($"the {book.Title} is already in the library");
            }
            if(book.BorrowedByMemberId != memberId)
            {
                Console.WriteLine("This book is borrowed ny another member");
            }

            book.IsBorrowed = false;
            book.BorrowedByMemberId = null;
            _db.SaveChanges();

            Console.WriteLine($"{book.Title} has returned");
        }
    }
}