using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class SupplierServices : ISupplier
    {
        private readonly LoginDbContext _context;
        public SupplierServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Supplier_Response>> GetAllSuppliers()
        {
            try
            {
                var suppliers = await _context.Suppliers.ToListAsync();
                var supplierResponses = suppliers.Select(s => new Supplier_Response
                {
                   Id = s.Id,
                    Supplier_Id = s.Supplier_Id,
                    Supplier_Company_Name = s.Supplier_Company_Name,
                    Supplier_Company_Address = s.Supplier_Company_Address,
                    Supplier_Company_City = s.Supplier_Company_City,
                    Supplier_Company_Country = s.Supplier_Company_Country,
                    Supplier_Company_State =s.Supplier_Company_State,
                    Supplier_Company_ZipCode = s.Supplier_Company_ZipCode,
                    Supplier_Description = s.Supplier_Description,
                    Supplier_Email = s.Supplier_Email,
                    Supplier_Phone = s.Supplier_Phone,
                    Supplier_Company_Website = s.Supplier_Company_Website,
                    Warehouse_Id = s.Warehouse_Id
                });

                return supplierResponses;

            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving suppliers: " + ex.Message);
            }
        }
        public async Task<Supplier_Response> GetSupplierById(int id)
        {
            try
            {
                var supplier = await _context.Suppliers.FindAsync(id);
                if (supplier == null)
                {
                    return null;
                }
                return new Supplier_Response
                {
                    Supplier_Id = supplier.Supplier_Id,
                    Supplier_Company_Name = supplier.Supplier_Company_Name,
                    Supplier_Company_Address = supplier.Supplier_Company_Address,
                    Supplier_Company_City = supplier.Supplier_Company_City,
                    Supplier_Company_State = supplier.Supplier_Company_State,
                    Supplier_Company_ZipCode = supplier.Supplier_Company_ZipCode,
                    Supplier_Description = supplier.Supplier_Description,
                    Supplier_Email = supplier.Supplier_Email,
                    Supplier_Phone = supplier.Supplier_Phone,
                    Supplier_Company_Website = supplier.Supplier_Company_Website,
                    Warehouse_Id = supplier.Warehouse_Id
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving supplier: " + ex.Message);
            }
        }
        public async Task<string> AddSupplier(Supplier_Request supplier)
        {
            try
            {
                bool exists = await _context.Commodities.AnyAsync(x => x.Supplier_Id ==supplier.Supplier_Id);

                if (exists)
                {
                    return "Department already exists";
                }
                var newSupplier = new Supplier
                {
                    Id = supplier.Id,
                    Supplier_Name=supplier.Supplier_Name,
                    Supplier_Id = supplier.Supplier_Id,
                    Supplier_Company_Name = supplier.Supplier_Company_Name,
                    Supplier_Company_Address = supplier.Supplier_Company_Address,
                    Supplier_Company_City = supplier.Supplier_Company_City,
                    Supplier_Company_State = supplier.Supplier_Company_State,
                    Supplier_Company_ZipCode = supplier.Supplier_Company_ZipCode,
                    Supplier_Description = supplier.Supplier_Description,
                    Supplier_Email = supplier.Supplier_Email,
                    Supplier_Phone = supplier.Supplier_Phone,
                    Supplier_Company_Website = supplier.Supplier_Company_Website,
                    Supplier_Company_Country = supplier.Supplier_Company_Country,
                    Warehouse_Id = supplier.Warehouse_Id

                };
                _context.Suppliers.Add(newSupplier);
                await _context.SaveChangesAsync();
                return "Supplier added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<Supplier_Response> UpdateSupplier(Supplier_Request supplier)
        {
            try
            {
                var existingSupplier = await _context.Suppliers.FindAsync(supplier.Supplier_Id);
                if (existingSupplier == null)
                {
                    return null;
                }
                existingSupplier.Supplier_Company_Name = supplier.Supplier_Company_Name;
                existingSupplier.Supplier_Company_Address = supplier.Supplier_Company_Address;
                existingSupplier.Supplier_Company_City = supplier.Supplier_Company_City;
                existingSupplier.Supplier_Company_State = supplier.Supplier_Company_State;
                existingSupplier.Supplier_Company_ZipCode = supplier.Supplier_Company_ZipCode;
                existingSupplier.Supplier_Description = supplier.Supplier_Description;
                existingSupplier.Supplier_Email = supplier.Supplier_Email;
                existingSupplier.Supplier_Phone = supplier.Supplier_Phone;
                existingSupplier.Supplier_Company_Website = supplier.Supplier_Company_Website;
                existingSupplier.Supplier_Company_Country = supplier.Supplier_Company_Country;
                existingSupplier.Warehouse_Id = supplier.Warehouse_Id;
                await _context.SaveChangesAsync();
                return new Supplier_Response
                {
                    Supplier_Id = existingSupplier.Supplier_Id,
                    Supplier_Company_Name = existingSupplier.Supplier_Company_Name,
                    Supplier_Company_Address = existingSupplier.Supplier_Company_Address,
                    Supplier_Company_City = existingSupplier.Supplier_Company_City,
                    Supplier_Company_State = existingSupplier.Supplier_Company_State,
                    Supplier_Company_ZipCode = existingSupplier.Supplier_Company_ZipCode,
                    Supplier_Description = existingSupplier.Supplier_Description,
                    Supplier_Email = existingSupplier.Supplier_Email,
                    Supplier_Phone = existingSupplier.Supplier_Phone,
                    Supplier_Company_Website = existingSupplier.Supplier_Company_Website,
                    Supplier_Company_Country = existingSupplier.Supplier_Company_Country,
                    Warehouse_Id = existingSupplier.Warehouse_Id

                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier: " + ex.Message);
            }
        }
        public async Task<bool> DeleteSupplier(int id)
        {
            try
            {
                var supplier = await _context.Suppliers.FindAsync(id);
                if (supplier == null)
                {
                    return false;
                }
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting supplier: " + ex.Message);
            }
        }
    }
}
