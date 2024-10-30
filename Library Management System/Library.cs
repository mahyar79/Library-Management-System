using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Library
    {
        private List<Book> books;
        private List<Member> members;

        public Library()
        {
            books = new List<Book>();
            members = new List<Member>();
        }

        public void AddBook(Book book)
        {
            books.Add(book); 
        }
        public void RemoveBook(string isbn)
        {
            var bookToRemove = books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
        }
        public void RegisterMember(Member member)
        {
            members.Add(member);
        }
        public void RemoveMember(string memberId)
        {
            var memberToRemove = members.FirstOrDefault(m => m.MemberId == memberId);
            if(memberToRemove != null)
            {
                members.Remove(memberToRemove);
            }
        }
        public void BorrowBook(string memberId, string isbn)
        {
            var member = members.FirstOrDefault(m => m.MemberId == memberId);
            var book = books.FirstOrDefault(b => b.ISBN == isbn && !b.IsBorrowed);
            if (book != null && member != null)
            {
                member.ManageBook(book, true);
                book.IsBorrowed = true;

            }  
        }
        public void ReturnBook(string memberId, string isbn)
        {
            var member = members.FirstOrDefault(m => m.MemberId == memberId);
            var book = books.FirstOrDefault(b => b.ISBN == isbn && b.IsBorrowed);
            if (book != null && member != null)
            {
                member.ManageBook(book, false);
                book.IsBorrowed = false;
            }
        }
        public void DisplayBooks()
        {
            foreach(var book in books)
            {

                Console.WriteLine($"{book.Title}, {book.Author}, {book.ISBN}, Borrowed: {book.IsBorrowed}");
            }
        }
    }
}
