using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public interface REsourses
    {
        int cost { get; }
        int number { get; set; }
        bool Buying(int money, int res);
        bool Sale(int res);
    }
}
