using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class ShippingType
    {
        public int Id { get; set; }
        [Key]
        [ForeignKey("Shipping")]
        public int Shipping_Id { get; set; }
        public string Shipping_Type { get; set; } = string.Empty;

        public ICollection<Shipping> Shippings { get; set; }

    }
}
