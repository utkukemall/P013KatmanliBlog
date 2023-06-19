using Microsoft.AspNetCore.Mvc;
using P013KatmanliBlog.WebAPIUsing.Models;
using P013KatmanliBlog.Core.Entities;
using System.Diagnostics;

namespace P013KatmanliBlog.WebAPIUsing.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly string _apiAdres = "https://localhost:7131/api/";

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres + "Posts");
            
            return View(model);
        }
        [Route("tum-postlarımız")]
        public async Task<IActionResult> BlogDetails(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
                return RedirectToAction(nameof(Index), "Home");
            }
            PostDetailViewModel model = new();

            var posts = await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres);
            var post = await _httpClient.GetFromJsonAsync<Post>(_apiAdres + "/" + id);

            model.Post = post;
            model.RelatedPosts = posts.Where(p => p.CategoryId == post.CategoryId && p.Id != id).ToList();

            if (model == null)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}