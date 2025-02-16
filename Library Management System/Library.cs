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
            var book = _db.Books.Find(bookId);
            var member = _db.Members.Find(memberId);
            if (member == null)
            {
                Console.WriteLine("Member not found!");
                return;
            }
            if (book == null)
            {
                Console.WriteLine("book not found!");
                return;
            }
           
            if (book.IsBorrowed)
            {
                Console.WriteLine($"Sorry! the {book.Title} is already borrowed");
                return;
            }

            book.Borrow(memberId);
            _db.BorrowHistories.Add(new BorrowHistory
            {
                MemberId = memberId,
                BookId = bookId,
                BorrowDate = DateTime.Now

            });
            _db.SaveChanges();

            Console.WriteLine($"The book: {book.Title} has been borrowed by {member.Name}");

        }

        public void ReturnBook(int bookId, int memberId)
        {
            var book = _db.Books.Find(bookId);
            var history = _db.BorrowHistories
                .Where(b => b.BookId == bookId && b.ReturnDate == null).FirstOrDefault();

            if (book == null || history == null)
            {
                Console.WriteLine("No active borrow record found!");
                return;
            }
            if(book.BorrowedByMemberId != memberId)
            {
                Console.WriteLine("This book is borrowed by another member");
                return;
            }

            book.Return();
            history.ReturnDate = DateTime.Now;
            _db.SaveChanges();

            Console.WriteLine($"{book.Title} has been returned");
        }

        public void DisplayBorrowHistory()
        {
            var history = _db.BorrowHistories.ToList();
            Console.WriteLine("\n Borrowing History:");
                foreach(var record in history)
            {
                Console.WriteLine($"Member ID: {record.MemberId}, Book ID: {record.BookId}, Borrowed: {record.BorrowDate}," +
                    $" Returned: {(record.ReturnDate.HasValue ? record.ReturnDate.Value.ToString() : "Not Returned")}");
            }
        }

        public void SearchBooks(string query)
        {
            var result = _db.Books
                .Where(b => b.Title.Contains(query) || b.Author.Contains(query) || b.ISBN.Contains(query))
                .ToList();
            if(result.Count == 0)
            {
                Console.WriteLine("No books found");
                return;
            }
            Console.WriteLine("\n Search Results:"); 
            foreach(var book in result)
            {
                Console.WriteLine($" {book.Title} - {book.Author} (ISBN: {book.ISBN}) - Borrowed: {book.IsBorrowed}");
            }
        }
    }
}