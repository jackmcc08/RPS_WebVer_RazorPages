using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPSWebVersionRazorPages.Pages.Learn
{
    public class IndexModel : PageModel
    { 
        [BindProperty]
        public string TheWord { get; set; }
        public int Number { get; set; }
        public bool DisplaySpecNum { get; set; }
    
        public void OnGet(int? number)
        {
            if (number.HasValue)
            {
                Number = number.Value;
                DisplaySpecNum = true;
            }
            else
            {
                Number = 0;
                DisplaySpecNum = false;
            }
        }
/* all returns need an IActionResult*/
        public async Task<IActionResult> OnPostAsync()
        {
            if (TheWord == "Not Found")
            {
                return NotFound();
            }
            else if (TheWord == "Home")
            {
                return RedirectToPage("/Index");
            }
            
            using (StreamWriter writer = new StreamWriter("log.txt", append: true))
            {
                await writer.WriteLineAsync($"OnPostAsync() called at {DateTime.Now}. They entered the word: {TheWord}.");

                return Page();
            }

        }
    }
}
