using Microsoft.AspNetCore.Mvc;
using todo.services;
using todos.dto;

namespace todos.Controller
{
    [ApiController]
    [Route("/api")]
    public class TodosController : ControllerBase
    {

        private ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet()]
        [Route("todos")]
        public IActionResult GetAllTodos()
        {
            return Ok(_todoService.GetAllTodos());
        }

        [HttpGet()]
        [Route("todos/{id:guid}")]
        public IActionResult GetTodoById(Guid id)
        {
            var result = _todoService.GetTodoById(id);

            if (result is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost()]
        [Route("todos")]
        public IActionResult AddTodo([FromBody] TodoItemRequest requestBody)
        {
            _todoService.AddTodo(requestBody);
            return Created();
        }


        [HttpPut()]
        [Route("todos/{id:guid}")]
        public IActionResult EditTodo(Guid Id, [FromBody] TodoItemPutRequest request)
        {

            var x = _todoService.EditTodo(Id, request);

            if (x is null)
            {
                return NotFound();
            }


            return Ok(x);
        }

        [HttpDelete()]
        [Route("todos/{id:guid}")]
        public IActionResult DeleteTodo(Guid id)
        {
            try
            {
                var result = _todoService.DeleteTodo(id) ?? throw new Exception("Something went worng");
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }
    }
}