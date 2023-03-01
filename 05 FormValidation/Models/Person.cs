namespace _05_FormValidation.Models
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EMail { get; set; }

        public string? Gender { get; set; }

        public string Country { get; set; }

        public bool? SubscribeMe { get; set; }

        public IFormFile? Photo { get; set; }
    }
}