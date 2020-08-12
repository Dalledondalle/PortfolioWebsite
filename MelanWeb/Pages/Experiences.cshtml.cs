using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelanWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MelanWeb.Pages
{
    public class ExperiencesModel : PageModel
    {
        public Models.ExperiencesModel Exp;
        private readonly ICosmosDBService db;
        public ExperiencesModel(ICosmosDBService cosmosDbService)
        {
            db = cosmosDbService;
        }
        public string PageTitle { get; set; } = "Erfaringer";
        public void OnGet()
        {
            Exp = db.GetExperiencesAsync().Result;
        }
    }
}