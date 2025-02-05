using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System
{
    public class Book
    {
        public Book()
        {
                
        }
        [Key] 
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Author {  get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; set; }

        public int? BorrowedByMemberId { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}");
        }
    }
}
