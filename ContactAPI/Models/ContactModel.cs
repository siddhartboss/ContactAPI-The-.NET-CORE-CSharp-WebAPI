namespace ContactAPI.Models
{
    public class ContactModel
    {
        public Guid  Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
