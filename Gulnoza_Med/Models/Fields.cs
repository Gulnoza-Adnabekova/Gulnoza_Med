namespace Gulnoza_Med.Models;

public class Fields
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<Doctors> Doctors { get; set; }
}