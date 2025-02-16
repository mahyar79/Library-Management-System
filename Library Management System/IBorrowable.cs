using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public interface IBorrowable
    {
        bool IsBorrowed { get; set; }
        int? BorrowedByMemberId { get; set; }
        void Borrow(int memberid);
        void Return();

    }
}
