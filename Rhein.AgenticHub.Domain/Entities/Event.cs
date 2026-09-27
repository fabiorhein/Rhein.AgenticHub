namespace Rhein.AgenticHub.Domain.Entities;

public class Event
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Status { get; private set; }
    public Guid? AssignedAgentId { get; private set; }

    public Event(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or empty.", nameof(title));
        
        Id = Guid.NewGuid();
        Title = title;
        Status = "Pending";
    }
    
    internal void AssignTo(Guid agentId)
    {
        if (agentId == Guid.Empty)
            throw new ArgumentException("Invalid Agent Id.", nameof(agentId));

        AssignedAgentId = agentId;
        Status = "In Progress";
    }
}