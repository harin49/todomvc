using todos.dto;

namespace todo.services
{
    public interface ITodoService
    {
        public List<TodoItemResponse> GetAllTodos();

        public string AddTodo(TodoItemRequest request);

        public TodoItemResponse? GetTodoById(Guid id);

        public string? EditTodo(Guid Id, TodoItemPutRequest request);

        public int? DeleteTodo(Guid Id);
    }
}