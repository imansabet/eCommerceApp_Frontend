namespace ClientLibrary.Models.Category;

public class GetCategory
{
    public Guid Id { get; set; }
    public ICollection<GetProduct>? Products { get; set; }
}
