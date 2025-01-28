using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApi.Models
{
    public class Customer
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_name")]
    public string ProductName { get; set; }

    [Column("product_description")]
    public string ProductDescription { get; set; }

    [Column("product_code")]
    public string ProductCode { get; set; }

    [Column("product_price")]
    public string ProductPrice { get; set; }
}
}
