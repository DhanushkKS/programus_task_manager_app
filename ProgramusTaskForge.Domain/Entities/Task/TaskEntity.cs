namespace ProgromusTaskForge.Domain.Entities.Task;

public class TaskEntity:BaseEntity
{
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime DueDate { get; set; }
}