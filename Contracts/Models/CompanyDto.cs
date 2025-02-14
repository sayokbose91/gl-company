using System.ComponentModel.DataAnnotations;

namespace Contracts.Models;

public class CompanyDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "CompanyTests name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Exchange is required.")]
    public string Exchange { get; set; }

    [Required(ErrorMessage = "Ticker is required.")]
    public string Ticker { get; set; }

    [Required(ErrorMessage = "ISIN is required.")]
    [RegularExpression("^(?=.{12}$)[A-Za-z]{2}[0-9A-Za-z]{10}$", 
        ErrorMessage = "ISIN must be exactly 12 characters long and start with two letters.")]
    public string Isin { get; set; }

    public string Website { get; set; }
}