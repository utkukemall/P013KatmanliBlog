using Microsoft.AspNetCore.Mvc;
using P013KatmanliBlog.Core.Entities;
using P013KatmanliBlog.MVCUI.Models;
using P013KatmanliBlog.Service.Abstract;
using System.Diagnostics;

namespace P013KatmanliBlog.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Post> _post;
        private readonly IService<Category> _postCategory;
        private readonly IService<AppUser> _postAppUser;

        public HomeController(IService<Post> post, IService<Category> postCategory, IService<AppUser> postUser)
        {
            _post = post;
            _postCategory = postCategory;
            _postAppUser = postUser;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _post.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> BlogPost(int? id)
        {
            if (id == null)
                return BadRequest();

            var model = await _post.FindAsync(id.Value);

            if (model == null)
                return NotFound();
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