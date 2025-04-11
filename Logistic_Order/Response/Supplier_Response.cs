using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Response
{
    public class Supplier_Response
    {
        public int Id { get; set; }

        public int Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Company_Name { get; set; }
        public string Supplier_Company_Address { get; set; }
        public string Supplier_Company_City { get; set; }
        public string Supplier_Company_State { get; set; }
        public string Supplier_Company_ZipCode { get; set; }
        public string Supplier_Company_Country { get; set; }
        public string Supplier_Phone { get; set; }
        public string Supplier_Email { get; set; }
        public string Supplier_Description { get; set; }
        public string Supplier_Company_Website { get; set; }

        [ForeignKey("Warehouse")]
        public int Warehouse_Id { get; set; }
    }
}
