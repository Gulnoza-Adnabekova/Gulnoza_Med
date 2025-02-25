namespace Gulnoza_Med.Models
{
    public class Doctors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int FieldsId { get; set; }
        public Fields Fields { get; set; }

    }
}
