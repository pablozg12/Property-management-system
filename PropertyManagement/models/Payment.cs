namespace ApartmentManagement.Models

    public class Payment{
        [Key]
        public long IdPayment {get; set;}

        public DateTime payDate {get; set;}



        [Column(TypeName = "decimal(10,2)")]
        public Double amount {get; set;}

        [Column(TypeName = "decimal(10,2)")]
        public Double residue {get; set;}

        public String details {get; set;}

        public long IdRent {get; set;}

        [ForeignKey("IdRent")]
        public Rent rent {get; set;} = null!;
    }