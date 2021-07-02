using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RPSWebVersionRazorPages.Pages.RpsGame
{
    public class RoundStartModel : PageModel
    {
        [BindProperty]
        public string Players { get; set; }
        
        public void OnGet()
        {

        }

        /* On post does not seem to be routing properly, need to find a solution*/
  /*      public IActionResult OnPost(string players)
        { 
              return Page();
        }*/
    }
}
