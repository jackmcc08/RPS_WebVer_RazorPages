using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSWebVersionRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            TestInfo = "this is a sample Property";
            
        }

        public string TestInfo { get; set; }
        public string TestSelect { get; set; }
        public List<SelectListItem> TestList { get; set; }

        public string Players { get; set; }

        public void OnGet()
        {
            ViewData["testString"] = "This is a string put into viewData from the model";
            TestList = new List<SelectListItem>
            {
                new SelectListItem("1", "This is a First element, added with the Add() method"),
                new SelectListItem("2", "This is a Second element, added with the Add() method"),
                new SelectListItem("3", "This is a Third element, added with the Add() method"),
                new SelectListItem("This is a Third element, added with the Add() method", "4"),
            };
           
        }

        public IActionResult OnPost(string players)
        {
            Players = players;
            return RedirectToPage("/RpsGame/RoundStart");
        }
    }
}
