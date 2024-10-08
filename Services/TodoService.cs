using todo.enums;
using todo.models;
using todos.data;
using todos.dto;

namespace todo.services
{

    public class TodoService : ITodoService
    {

        private TodosDbContext _todosDb { get; }
        public TodoService(TodosDbContext todosDbContext)
        {
            _todosDb = todosDbContext;
        }

        public List<TodoItemResponse> GetAllTodos()
        {
            var result = _todosDb.Todos.ToList();
            return ConvertToListOfResponseDto(result);
        }

        public TodoItemResponse? GetTodoById(Guid id)
        {
            var result = _todosDb.Todos.Find(id);

            if (result == null)
            {
                return null;
            }
            else
            {
                return ConvertToResponseDto(result);
            }
        }

        public string AddTodo(TodoItemRequest request)
        {
            var result = new TodoItem
            {
                Id = Guid.NewGuid(),
                Task = request.Task,
                Status = Status.Incomplete,
                Deadline = DateOnly.ParseExact(request.Deadline, "dd-MM-yyyy"),
            };

            _todosDb.Todos.Add(result);

            _todosDb.SaveChanges();

            return result.Id.ToString();
        }


        public string? EditTodo(Guid Id, TodoItemPutRequest request)
        {

            var TodoToBeUpdated = _todosDb.Todos.Find(Id);
            if (TodoToBeUpdated is null)
            {
                return null;
            }
            else
            {

                TodoToBeUpdated.Status = Enum.Parse<Status>(request.Status);
                TodoToBeUpdated.Task = request.Task;
                TodoToBeUpdated.Deadline = DateOnly.ParseExact(request.Deadline, "dd-MM-yyyy");

                _todosDb.SaveChanges();
                return request.Id;
            }
        }


        public int? DeleteTodo(Guid Id)
        {
            var TodoToBeDeleted = _todosDb.Todos.Find(Id);
            if (TodoToBeDeleted is null)
            {
                return null;
            }

            _todosDb.Remove(TodoToBeDeleted);
            _todosDb.SaveChanges();
            return 1;
        }

        private static TodoItemResponse ConvertToResponseDto(TodoItem todoItem)
        {
            return new TodoItemResponse
            {
                Id = todoItem.Id.ToString(),
                Task = todoItem.Task,
                Status = todoItem.Status.ToString(),
                Deadline = todoItem.Deadline.ToString("dd-MM-yyyy"),
            };
        }

        private static List<TodoItemResponse> ConvertToListOfResponseDto(List<TodoItem> todoItems)
        {
            List<TodoItemResponse> x = [];

            todoItems.ForEach(t =>
            {
                var response = ConvertToResponseDto(t);

                x.Add(response);
            });

            return x;

        }

    }
}