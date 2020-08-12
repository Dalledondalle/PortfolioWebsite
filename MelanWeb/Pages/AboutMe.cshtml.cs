using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelanWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MelanWeb.Pages
{
    public class AboutMeModel : PageModel
    {
        private readonly ICosmosDBService db;
        public AboutMeModel(ICosmosDBService cosmosDbService)
        {
            db = cosmosDbService;
        }
        public MelanWeb.Models.AboutMeModel AboutMe { get; set; }
        public string PageTitle { get; set; } = "Om Mig";
        public void OnGet()
        {
            Task<MelanWeb.Models.AboutMeModel> s = db.GetAboutMeAsync();
            AboutMe = s.Result;
        }
    }
}