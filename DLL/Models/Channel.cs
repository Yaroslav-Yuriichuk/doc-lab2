namespace DLL.Models;

public sealed class Channel
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Message>? Messages { get; set; }

    public int InboxId { get; set; }
    public Inbox? Inbox { get; set; }
}