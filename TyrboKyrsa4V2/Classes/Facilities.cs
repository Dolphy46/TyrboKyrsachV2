using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public interface Facilities
    {
        int[] cost { get; }
        int number { get; set; }
        bool Build(int money);
        void InfoRes(int res0, int res1, int res2);
    }
}
