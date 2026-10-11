namespace ApartmentManagement.Models

    public class Rent{
        [Key]
        public long IdRent {get; set;}

        public long IdProperty {get; set;}

        [ForeignKey("IdProperty")]
        public Property property {get; set;} = null!;

        public long IdUser { get; set; }

        [ForeignKey("IdUser")]
        public Client Client { get; set; } = null!;

        public DateTime startDate {get; set;}
        public DateTime finishDate {get; set;}

        [Column(TypeName = "decimal(10,2)")]
        public deciaml amount {get; set;}

        public rentState state {get; set;} = rentState.ACTIVE;
    }