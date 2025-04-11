using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Commodity
    {
        public int Id { get; set; }
        [Key]
        public int Commodity_Id { get; set; }
        public string Commodity_Name { get; set; } = string.Empty;
        public string Commodity_Description { get; set; } = string.Empty;
        public string Commodity_Type { get; set; } = string.Empty;
        public string Commodity_Weight { get; set; } = string.Empty;
        public string Commodity_Quantity { get; set; } = string.Empty;
        public decimal Commodity_Price { get; set; }
        public string Commodity_Unit { get; set; } = string.Empty;

        public string Commodity_Status { get; set; } = string.Empty;
        public string Commodity_Date { get; set; } = string.Empty;
        public string Commodity_Expiry { get; set; } = string.Empty;
        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }
        public Supplier Supplier { get; set; }

        public Commodity_Category Commodity_Category { get; set; }
        public ICollection<OrderCommodities> OrderCommodities { get; set; }

        public ICollection<Stock> Stocks { get; set; }

    }
}
