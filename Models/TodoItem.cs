using todo.enums;

namespace todo.models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public required string Task { get; set; }

        public required Status Status { get; set; }

        public DateOnly Deadline { get; set; }
    }
}