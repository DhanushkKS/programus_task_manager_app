namespace ProgromusTaskForge.Application.Dtos.Task;

public class CreateTaskDto
{
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime DueDate { get; set; }
}