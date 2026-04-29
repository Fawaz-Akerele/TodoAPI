using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TodoAPI.Data;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ApiDbContext db;

        public TodosController(ApiDbContext db)
        {
            this.db = db;
        }
        [HttpPost]
        public async Task<ActionResult> CreateTodo([FromBody] CreateTodoRequest request)
        {
            // Logic to create a new todo item
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newTodo = new Todo
            {
                Title = request.Title,
                Description = request.Description,
                CreatedBy = request.CreatedBy,
            };
            await db.Todos.AddAsync(newTodo);
            await db.SaveChangesAsync();
            return Ok("New todo created successfully");
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Todo>> GetTodoById(int Id)
        {
            var todo = await db.Todos.FindAsync(Id);
            if (todo == null)
            {
                return NotFound("Todo not found");
            }
            return Ok(todo);
        }

        [HttpGet]
        public ActionResult<List<Todo>> GetAllTodos()
        {
            var todos = db.Todos.ToList();
            return Ok(todos);
        }

        [HttpPatch("{Id}")]
        public async Task<ActionResult> UpdateTodo(int Id, [FromBody] UpdateTodoRequest request)
        {
            var todo = await db.Todos.FindAsync(Id);
            if (todo == null)
            {
                return NotFound("Todo not found");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.DateUpdated = DateTime.UtcNow;
            await db.SaveChangesAsync();
            return Ok("Todo updated successfully");
        }
    }
}
