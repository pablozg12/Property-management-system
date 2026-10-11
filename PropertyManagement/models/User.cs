namespace ApartmentManagement.Models

    public class User{
        [Key]
        public long IdUser {get; set;}

        [Required, MaxLength(100)]
        public string name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string lastNamePaternal { get; set; } = string.Empty;

        public string? lastNameMaternal { get; set; }

        [MaxLength(20)]
        public string? phoneNum { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;
    }