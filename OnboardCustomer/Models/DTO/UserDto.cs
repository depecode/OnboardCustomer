namespace OnboardCustomer.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? StateofResidence { get; set; }
        public string? LGA { get; set; }
    }
}
