using Microsoft.AspNetCore.Mvc;
using P013KatmanliBlog.Core.Entities;
using P013KatmanliBlog.Service.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P013KatmanliBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IService<Post> _service;

        public PostsController(IService<Post> service)
        {
            _service = service;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public async Task<IEnumerable<Post>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return _service.Find(id);
        }

        // POST api/<PostsController>
        [HttpPost]
        public void Post([FromBody] Post value)
        {
            _service.Add(value);
            _service.Save();
        }

        // PUT api/<PostsController>/5
        [HttpPut]
        public void Put(int id, [FromBody] Post value)
        {
            _service.Update(value);
            _service.Save();
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var kayit = _service.Find(id);
            if (kayit == null)
            {
                return BadRequest();
            }
            _service.Delete(kayit);
            _service.Save();
            return Ok(kayit);
        }
    }
}
