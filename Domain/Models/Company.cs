namespace Domain.Models;

public class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Exchange { get; set; } = null!;

    public string Ticker { get; set; } = null!;

    public string Isin { get; set; } = null!;

    public string? Website { get; set; }
}
