using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public  class Member
    {
        public string Name { get; set; }
        public string MemberID {  get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Member(string name, string memberId)
        {
            Name = name;
            MemberID = memberId;
            BorrowedBooks = new List<Book>();
        }

        public void DisplayMemberInfo()
        {
            Console.WriteLine($"Member Name: {Name}, ID: {MemberID}, Borrowed Books: {BorrowedBooks}");
        }
    }
}
