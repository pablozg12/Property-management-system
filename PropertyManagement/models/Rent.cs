using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PropertyManagement.models;

    public class Rent{
        [Key]
        public long IdRent {get; set;}

        public long IdProperty {get; set;}

        [ForeignKey("IdProperty")]
        public Property property {get; set;} = null!;

        public long IdClient { get; set; }

        [ForeignKey("IdClient")]
        public UserClient Client { get; set; } = null!;

        public DateTime startDate {get; set;}
        public DateTime finishDate {get; set;}

        [Column(TypeName = "decimal(10,2)")]
        public Double amount {get; set;}

        public rentState state {get; set;} = rentState.ACTIVE;
    }