namespace TodoAPI
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
    }

    public class CreateTodoRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }

    public class UpdateTodoRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
