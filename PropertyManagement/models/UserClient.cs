using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PropertyManagement.models;

    public class Client : User{

        [Column(TypeName = "decimal(10,2)")]
        public Double debt { get; set; } 

        [Required]
        public string? photoRute { get; set; }

        public clientState state {get; set;} = clientState.AVAILABLE;

        public ICollection<Rent> Rents { get; set; } = new List<Rent>();
    }