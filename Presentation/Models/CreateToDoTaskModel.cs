namespace Presentation.Models;

public record CreateToDoTaskModel(string Name, int Priority, Guid BoardId);