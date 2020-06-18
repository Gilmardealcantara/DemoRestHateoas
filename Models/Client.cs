namespace Hateoas.Models
{
    public class Client : Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}