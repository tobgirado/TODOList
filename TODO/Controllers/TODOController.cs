using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Model;
using TODO.Services;

namespace TODO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TODOController : ControllerBase
    {
        private ITodoService _todoService;

        public TODOController(
            ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            return _todoService.Get().ToList();
        }

        [HttpGet("{completed}")]
        public ActionResult<IEnumerable<Todo>> Get(bool completed = false)
        {
            return _todoService.Get(completed).ToList();
        }

        [HttpPost]
        public ActionResult<Todo> Post([FromBody] Todo todo)
        {
            return _todoService.Post(todo);
        }

        [HttpPut("{id}")]
        public ActionResult<Todo> Put(int id, [FromBody] Todo todo)
        {
            if (_todoService.Exists(id))
                return _todoService.Put(todo);

            return BadRequest(new { message = "item no existe" });
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _todoService.Delete(id);
        }

    }
}
