namespace Rhein.AgenticHub.Domain.Entities;

public class Agent
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    private readonly List<Event> _assignedEvents = new(); 
    public IReadOnlyCollection<Event> AssignedEvents => _assignedEvents.AsReadOnly();

    public Agent(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Agent name cannot be null or empty.", nameof(name));
        
        Id = Guid.NewGuid();
        Name = name;
    }
    
    public void AssignEvent(Event @event)
    {
        if (@event == null) 
            throw new ArgumentNullException(nameof(@event));
        
        if (_assignedEvents.Count >= 5)
            throw new InvalidOperationException("This agent already has an assigned event.");

        @event.AssignTo(this.Id);
        _assignedEvents.Add(@event);
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Agent name cannot be null or empty.", nameof(newName));
        
        Name = newName;
    }
}