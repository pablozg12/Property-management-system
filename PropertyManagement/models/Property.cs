namespace ApartmentManagement.Models

    public class Property{
        [Key]
        public long IdProperty {get; set;}

        [Required, MaxLength(100)]
        public string name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public Double monthlyPayment { get; set; }

        public string? description { get; set; }

        public ICollection<string> photoRutes { get; set; } = new List<string>();

        public propertyState state {get; set;} = propertyState.AVAILABLE;
    }