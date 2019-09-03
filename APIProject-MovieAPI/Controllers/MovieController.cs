using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APIProject_MovieAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;

namespace APIProject_MovieAPI.Controllers
{
    public class MovieController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
       

        public async Task<IActionResult> SearchByTitle(string title, int year)
        {
            string yearstring = year.ToString();
            if (year != 0)
            {
                title.Replace(" ", "+");
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://www.omdbapi.com");
                //var apiKey = ConfigurationManager.AppSettings["APIKey"]; //need to hide the key
                var apiKey = "fbe002cf";
                var response = await client.GetAsync($"?t={title}&y={yearstring}&plot=full&apikey={apiKey}");
                var name = await response.Content.ReadAsAsync<Movie>();
                return View(name);
            }
            else
            {
                title.Replace(" ", "+");
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://www.omdbapi.com");
                //var apiKey = ConfigurationManager.AppSettings["APIKey"]; //need to hide the key
                var apiKey = "fbe002cf";
                var response = await client.GetAsync($"?t={title}&plot=full&apikey={apiKey}");
                var name = await response.Content.ReadAsAsync<Movie>();
                return View(name);
            }
        }
    }
}