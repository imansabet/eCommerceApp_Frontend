using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.Models.Product;

public class UpdateProduct : ProductBase
{
    [Required]
    public Guid Id { get; set; }
}
