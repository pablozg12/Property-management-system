using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PropertyManagement.models;

    public class Payment{
        [Key]
        public long IdPayment {get; set;}

        public DateTime payDate {get; set;}

        [Column(TypeName = "decimal(10,2)")]
        public Double amount {get; set;}

        [Column(TypeName = "decimal(10,2)")]
        public Double residue {get; set;}

        public String details {get; set;} = string.Empty;

        public long IdRent {get; set;}

        [ForeignKey("IdRent")]
        public Rent rent {get; set;} = null!;

        public payMethod paymethod {get; set;}
    }