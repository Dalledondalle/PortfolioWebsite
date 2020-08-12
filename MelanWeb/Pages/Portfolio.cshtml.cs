using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MelanWeb.Pages
{
    public class PortfolioModel : PageModel
    {
        public string PageTitle { get; set; } = "Portfolio";
        public void OnGet()
        {

        }
    }
}