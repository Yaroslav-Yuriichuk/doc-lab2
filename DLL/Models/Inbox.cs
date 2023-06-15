namespace DLL.Models;

public sealed class Inbox
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int TeamId { get; set; }
    public Team? Team { get; set; }

    public ICollection<Channel>? Channels { get; set; }
}