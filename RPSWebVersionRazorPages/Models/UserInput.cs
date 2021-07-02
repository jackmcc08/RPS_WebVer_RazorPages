using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSWebVersionRazorPages.Models
{
    public class UserInput
    {
        public static string GetMove()
        {
            return Console.ReadLine();
        }
    }
}
