using Data.Model;

namespace Application.Dtos
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public int StreetNo { get; set; }
        public string? City { get; set; }
        public string? StreetName { get; set; }
        public Employee? Employee { get; set; }
        //public State State { get; set; }
    }
    public class CreateAddressDto
    {
        public Guid Id { get; set; }
        public int StreetNo { get; set; }
        public string? City { get; set; }
        public string? StreetName { get; set; }
        public Employee? Employee { get; set; }
        //public State State { get; set; }
    }
    public class UpdateAddressDto
    {
        public Guid Id { get; set; }
        public int StreetNo { get; set; }
        public string? City { get; set; }
        public string? StreetName { get; set; }
        public Employee? Employee { get; set; }
        //public State State { get; set; }
    }
}
