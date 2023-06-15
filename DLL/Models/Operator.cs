namespace DLL.Models;

public sealed class Operator
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Team>? Teams { get; set; }
}