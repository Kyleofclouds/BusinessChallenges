using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimConsoleApp
{
    class ClaimApp
    {
        static void Main(string[] args)
        {
            ClaimRepo ClaimRepo = new ClaimRepo();
            ClaimUI ui = new ClaimUI(ClaimRepo);
            ui.Run();
        }
    }
}
