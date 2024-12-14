
namespace ClientLibrary.Models;

public class ApiCall
{
    public HttpClient? Client { get; set; }
    public string? Type { get; set; }
    public string? Route { get; set; }
    public string? Id { get; set; }
    public dynamic? Model { get; set; }

    public void ToString(Guid id) => id.ToString();
}
