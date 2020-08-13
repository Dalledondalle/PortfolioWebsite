using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelanWeb.StaticInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MelanWeb.Pages
{
    public class ContactModel : PageModel
    {
        public string PageTitle { get; set; } = "Kontakt Mig";
        public void OnGet()
        {

        }
    }
}