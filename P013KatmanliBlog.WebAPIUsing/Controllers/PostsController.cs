using Microsoft.AspNetCore.Mvc;
using P013KatmanliBlog.WebAPIUsing.Models;
using P013KatmanliBlog.Core.Entities;

namespace P013KatmanliBlog.WebAPIUsing.Controllers
{
    //public class PostsController : Controller
    //{
    //    private readonly HttpClient _httpClient;
    //    private readonly string _apiAdres = "https://localhost:7131/api/Posts";
    //    public PostsController(HttpClient httpClient)
    //    {
    //        _httpClient = httpClient;
    //    }
    //    [Route("tum-postlarımız")]
    //    public async Task<IActionResult> IndexAsync()
    //    {
    //        var model = await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres);
    //        return View(model);
    //    }
    //    public async Task<IActionResult> Search(string q) // adres çubuğunda query string ile 
    //    {
    //        var products = await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres + "/GetSearch/" + q);
    //        return View(products);
    //    }
    //    public async Task<IActionResult> DetailAsync(int id)
    //    {
    //        var model = new PostDetailViewModel();
    //        var posts = await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres);
    //        var post = await _httpClient.GetFromJsonAsync<Post>(_apiAdres + "/" + id); 
    //        model.Post = post;
    //        model.RelatedProducts = posts.Where(p => p.CategoryId == post.CategoryId && p.Id != id).ToList(); 
    //        if (model is null)
    //        {
    //            return NotFound();
    //        }
    //        return View(model);
    //    }
    //}
}
