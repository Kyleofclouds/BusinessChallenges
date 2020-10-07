using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApps
{
    class CafeApp
    {
        static void Main(string[] args)
        {
            CafeMenuRepo Menu = new CafeMenuRepo();
            CafeUI ui = new CafeUI(Menu);
            ui.Run();
        }
    }
}
