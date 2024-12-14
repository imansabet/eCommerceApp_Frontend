using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.Models.Category;

public class UpdateCategory : CategoryBase
{
    [Required]
    public Guid Id { get; set; }


}
