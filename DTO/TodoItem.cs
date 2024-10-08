namespace todos.dto
{

    public class TodoItemResponse
    {
        public string Id { get; set; } = "";

        public required string Task { get; set; }

        public required string Status { get; set; }

        public required string Deadline { get; set; }
    }

    public class TodoItemPutRequest : TodoItemResponse
    {
    }


    public class TodoItemRequest
    {
        public required string Task { get; set; }

        public string Deadline { get; set; } = "";
    }
}