using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System
{
    public class Book : IBorrowable
    {
        public Book()
        {       
        }
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }
        [Key] 
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Author {  get; set; }
        public string ISBN { get; set; }


        public bool IsBorrowed { get; set; } = false;
        public int? BorrowedByMemberId { get; set; } = null;

        public void Borrow(int memberId)
        {
            if (IsBorrowed)
            {
                Console.WriteLine("The Book is already borrowed");
                return;
            }
            IsBorrowed = true;
            BorrowedByMemberId = memberId;
           // Console.WriteLine($"{Title} has been borrowed by member {memberId}");
        }

        public void Return()
        {
            if (!IsBorrowed)
            {
                Console.WriteLine("This book is not borrowed.");
                return;
            }
            IsBorrowed = false;
            BorrowedByMemberId = null;
           // Console.WriteLine($"{Title} has been returned");
        }
      

        //public void DisplayInfo()
        //{
        //    Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}");
        //}
    }
}
