using Microsoft.AspNetCore.Mvc;
using P013KatmanliBlog.Core.Entities;
using P013KatmanliBlog.Service.Abstract;

namespace P013KatmanliBlog.MVCUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IService<Category> _service;
        private readonly IService<Post> _post;

        public CategoriesController(IService<Category> service, IService<Post> post)
        {
            _service = service;
            _post = post;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }
    }
}
