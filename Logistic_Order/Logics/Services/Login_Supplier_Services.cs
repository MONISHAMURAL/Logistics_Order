using System.Security.Cryptography.X509Certificates;
using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class Login_Supplier_Services : ILogin_Supplier
    {
        private readonly LoginDbContext _context;
        public Login_Supplier_Services(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Login_Supplier_Response>> GetAllLogin_Suppliers()
        {
            try
            {
                var loginSuppliers = await _context.LoginSuppliers.ToListAsync();
                return loginSuppliers.Select(ls => new Login_Supplier_Response
                {
                    Login_Id = ls.Login_Id,
                    Login_Supplier_Id = ls.Login_Supplier_Id,
                    Supplier_Id = ls.Supplier_Id,
                });
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Login_Supplier_Response>();
            }
        }
        public async Task<Login_Supplier_Response> GetLogin_SupplierById(int id)
        {
            try
            {
                var loginSupplier = await _context.LoginSuppliers.FindAsync(id);
                if (loginSupplier == null)
                {
                    return null;
                }
                return new Login_Supplier_Response
                {
                    Login_Id = loginSupplier.Login_Id,
                    Login_Supplier_Id = loginSupplier.Login_Supplier_Id,
                    Supplier_Id = loginSupplier.Supplier_Id,
                };
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<string> CreateLogin_Supplier(Login_Supplier_Request login_Supplier)
        {
            try
            {
                var newLoginSupplier = new Login_Supplier
                {
                    Login_Id = login_Supplier.Login_Id,
                    Login_Supplier_Id = login_Supplier.Login_Supplier_Id,
                    Supplier_Id = login_Supplier.Supplier_Id,

                };
                    await _context.LoginSuppliers.AddAsync(newLoginSupplier);
                await _context.SaveChangesAsync();
                return "Login Supplier created successfully";
            }
            catch (Exception ex)
            {
                return "Error creating Login Supplier: " + ex.Message;
            }
        }

        public async Task<string> UpdateLogin_Supplier(int id, Login_Supplier_Request login_Supplier)
        {
            try
            {
                var existingLoginSupplier = await _context.LoginSuppliers.FindAsync(id);
                if (existingLoginSupplier == null)
                {
                    return "Login Supplier not found";
                }
                existingLoginSupplier.Login_Id = login_Supplier.Login_Id;
                existingLoginSupplier.Supplier_Id = login_Supplier.Supplier_Id;
                _context.LoginSuppliers.Update(existingLoginSupplier);
                await _context.SaveChangesAsync();
                return "Login Supplier updated successfully";
            }
            catch (Exception ex)
            {
                return "Error updating Login Supplier: " + ex.Message;
            }
        }
        public async Task<string> DeleteLogin_Supplier(int id)
        {
            try
            {
                var loginSupplier = await _context.LoginSuppliers.FindAsync(id);
                if (loginSupplier == null)
                {
                    return "Login Supplier not found";
                }
                _context.LoginSuppliers.Remove(loginSupplier);
                await _context.SaveChangesAsync();
                return "Login Supplier deleted successfully";
            }
            catch (Exception ex)
            {
                return "Error deleting Login Supplier: " + ex.Message;
            }
        }
    }
    }
