using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public  class Member
    {

        public Member()
        {
                
        }
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        
      //  public List<Book> BorrowedBooks { get; set; }

        public Member(string name, int id)
        {
            Name = name;
            Id = id;
          
        }

        public void DisplayMemberInfo()
        {
            Console.WriteLine($"Member Name: {Name}, ID: {Id}");
        }
    }
}
