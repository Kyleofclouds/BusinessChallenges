using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesConsoleApp
{
    class BadgeApp
    {
        static void Main(string[] args)
        {
            BadgeRepo repo = new BadgeRepo();
            BadgeUI ui = new BadgeUI(repo);
            ui.Run();
        }
    }
}
