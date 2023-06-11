using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P013KatmanliBlog.Core.Entities;
using System.Drawing.Drawing2D;

namespace P013KatmanliBlog.WebAPIUsing.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class PostsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7131/api/Posts";
        private readonly string _apiAdresCategory = "https://localhost:7131/api/Categories";
        private readonly string _apiAdresUsers = "https://localhost:7131/api/AppUsers";

        public PostsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: PostsController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres);
            return View(model);
        }

        // GET: PostsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.ParentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres), "Id", "Name");
            ViewBag.CategoryId = new SelectList(await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdresCategory), "Id", "Name");
            ViewBag.AppUserId = new SelectList(await _httpClient.GetFromJsonAsync<List<AppUser>>(_apiAdresUsers), "Id", "Name");
            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Post collection)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_apiAdres, collection);
                if (response.IsSuccessStatusCode) // api den başarılı bir istek kodu geldiyse (200 ok)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            ViewBag.ParentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres), "Id", "Name");
            ViewBag.CategoryId = new SelectList(await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdresCategory), "Id", "Name");
            ViewBag.AppUserId = new SelectList(await _httpClient.GetFromJsonAsync<List<AppUser>>(_apiAdresUsers), "Id", "Name");
            return View();
        }

        // GET: PostsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.ParentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres), "Id", "Name");
            ViewBag.CategoryId = new SelectList(await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdresCategory), "Id", "Name");
            ViewBag.AppUserId = new SelectList(await _httpClient.GetFromJsonAsync<List<AppUser>>(_apiAdresUsers), "Id", "Name");
            var model = await _httpClient.GetFromJsonAsync<Post>(_apiAdres + "/" + id);
            return View(model);
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Post collection)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(_apiAdres, collection);
                if (response.IsSuccessStatusCode) // api den başarılı bir istek kodu geldiyse (200 ok)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            ViewBag.ParentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Post>>(_apiAdres), "Id", "Name");
            ViewBag.CategoryId = new SelectList(await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdresCategory), "Id", "Name");
            ViewBag.AppUserId = new SelectList(await _httpClient.GetFromJsonAsync<List<AppUser>>(_apiAdresUsers), "Id", "Name"); 
            return View();
        }

        // GET: PostsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Post>(_apiAdres + "/" + id);
            return View(model);
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Post collection)
        {
            try
            {
                var model = await _httpClient.DeleteAsync(_apiAdres + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
