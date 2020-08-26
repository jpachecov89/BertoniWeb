using BertoniWeb2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace BertoniWeb2.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient httpClient;

        public HomeController()
        {
            httpClient = new HttpClient();
        }

        public async Task<ActionResult> Index()
        {
            List<Album> result = new List<Album>();
            string urlAlbums = "https://jsonplaceholder.typicode.com/albums";
            using (HttpResponseMessage response = await this.httpClient.GetAsync(urlAlbums))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<List<Album>>(await response.Content.ReadAsStringAsync());
                }
            }
            
            return View(result);
        }

        public async Task<ActionResult> Album(int id, string title)
        {
            List<Image> result = new List<Image>();
            string urlImages = "https://jsonplaceholder.typicode.com/photos?albumId=" + id.ToString();
            using (HttpResponseMessage response = await this.httpClient.GetAsync(urlImages))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<List<Image>>(await response.Content.ReadAsStringAsync());
                }
            }
            ViewBag.Album = title;
            return View(result);
        }

        public async Task<ActionResult> Comment(int id)
        {
            List<Comment> result = new List<Comment>();
            string urlImages = "https://jsonplaceholder.typicode.com/comments?postId=" + id.ToString();
            using (HttpResponseMessage response = await this.httpClient.GetAsync(urlImages))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<List<Comment>>(await response.Content.ReadAsStringAsync());
                }
            }
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}