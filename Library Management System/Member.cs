using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Member
    {
        public string Name { get; set; }
        public string MemberId {  get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Member(string name, string memberid)
        {
            Name = name;
            MemberId = memberid;
            BorrowedBooks = new List<Book>();
        }
       public void ManageBook(Book book, bool isBorrowed)
        {
            if (isBorrowed)
            {
                BorrowedBooks.Add(book);
            }
            else
            {
                BorrowedBooks.Remove(book);
            }
        }
        
    }
}
