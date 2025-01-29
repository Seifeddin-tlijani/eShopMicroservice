using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApi.Models
{
    [Table("customer", Schema = "dbo")]
    public class Customer
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required] 
        [Column("CustomerName")] 
        public string CustomerName { get; set; }

        [Required] 
        [Column("MobileNumber")] 
        public string MobileNumber { get; set; }

        [Required] 
        [EmailAddress] 
        [Column("Email")]
        public string Email { get; set; }
    }
}
