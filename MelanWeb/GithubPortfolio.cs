using MelanWeb.Models;
using MelanWeb.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelanWeb
{
    public static class GithubPortfolio
    {
        public static PortfolioModel Content {get; set;}

        public static int Projects { get { return Content.PortfolioObjects.Length; } }

        public static int OnGoingProjects { get { return 2; } }

        public static int SuccesRate { get { return (int)(((float)(Projects - OnGoingProjects) / Projects * 100)); } }

        public static DateTime LastRefreshed { get; set; } = DateTime.Now;
    }
}
