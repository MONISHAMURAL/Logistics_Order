using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class TotalCostServices:ITotalCost
    {
        private readonly LoginDbContext loginDbContext;
        public TotalCostServices(LoginDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }
        public async Task<IEnumerable<TotalCostResponse>> GetAllTotalCostsAsync()
        {
            var totalCosts = await loginDbContext.TotalCosts.ToListAsync();
            return totalCosts.Select(totalCost => new TotalCostResponse
            {
                Id = totalCost.Id,
                Cost_Id = totalCost.Cost_Id,
                Discount = totalCost.Discount,
                Order_No = totalCost.Order_No,
                Shipping_Id = totalCost.Shipping_Id,
                Total_Amount = totalCost.Total_Amount,

              
            }).ToList();
        
        }
        public async Task<TotalCostResponse> GetTotalCostByIdAsync(int id)
        {
            var totalCost = await loginDbContext.TotalCosts.FindAsync(id);
            if (totalCost == null)
            {
                return null;
            }
            return new TotalCostResponse
            {
                Id = totalCost.Id,
                Cost_Id = totalCost.Cost_Id,
                Discount = totalCost.Discount,
                Order_No = totalCost.Order_No,
                Shipping_Id = totalCost.Shipping_Id,
                Total_Amount = totalCost.Total_Amount,
               

            };
        }
        public async Task<string> CreateTotalCostAsync(TotalCost_Request totalCost)
        {
            try { 
            TotalCost newTotalCost = new TotalCost
            {
                Id = totalCost.Id,
                Cost_Id = totalCost.Cost_Id,
                Discount = totalCost.Discount,
                Order_No = totalCost.Order_No,
                Shipping_Id = totalCost.Shipping_Id,
                Total_Amount = totalCost.Total_Amount,
                
                

            };
            await loginDbContext.TotalCosts.AddAsync(newTotalCost);
            await loginDbContext.SaveChangesAsync();
            return "Total cost created successfully";
        }
            catch (Exception ex)
            {
                return $"Error creating total cost: {ex.Message}";
            }
        }
        public async Task<TotalCostResponse> UpdateTotalCost(int id, TotalCost_Request totalCost)
        {
            try
            {
                var existingTotalCost = await loginDbContext.TotalCosts.FindAsync(id);
                if (existingTotalCost == null)
                {
                    return null;
                }
                existingTotalCost.Cost_Id = totalCost.Cost_Id;
                existingTotalCost.Discount = totalCost.Discount;
                existingTotalCost.Order_No = totalCost.Order_No;
                existingTotalCost.Shipping_Id = totalCost.Shipping_Id;
                existingTotalCost.Total_Amount = totalCost.Total_Amount;
                existingTotalCost.Id = totalCost.Id;
                

                await loginDbContext.SaveChangesAsync();
                return new TotalCostResponse
                {
                    Id = existingTotalCost.Id,
                    Cost_Id = existingTotalCost.Cost_Id,
                    Discount = existingTotalCost.Discount,
                    Order_No = existingTotalCost.Order_No,
                    Shipping_Id = existingTotalCost.Shipping_Id,
                    Total_Amount = existingTotalCost.Total_Amount,
                   

                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> DeleteTotalCost(int id)
        {

            try
            {
                var totalCost = await loginDbContext.TotalCosts.FindAsync(id);
                if (totalCost == null)
                {
                    return false;
                }
                loginDbContext.TotalCosts.Remove(totalCost);
                await loginDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
