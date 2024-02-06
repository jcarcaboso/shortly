namespace Shortly.Infrastructure.Models;

public partial class ShortUrlMapping
{
    public string Id { get; set; } = null!;

    public string Url { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public bool? IsActive { get; set; } = true;
}
