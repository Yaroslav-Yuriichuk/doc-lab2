namespace DLL.Models;

public sealed class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Inbox>? Inboxes { get; set; }
    public ICollection<Operator>? Operators { get; set; }
}