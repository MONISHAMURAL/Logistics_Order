using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class StockServices:IStockServices
    {
        private readonly LoginDbContext loginDbContext;
        public StockServices(LoginDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }
        public async Task<IEnumerable<Stock_Response>> GetAllStocksAsync()
        {
            var stocks = await loginDbContext.Stocks.ToListAsync();
            return stocks.Select(stock => new Stock_Response
            {
                Id = stock.Id,
                Warehouse_Id = stock.Warehouse_Id,
                Commodity_Id = stock.Commodity_Id
            });
        }
        public async Task<Stock_Response> GetStockByIdAsync(int id)
        {
            var stock = await loginDbContext.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }
            return new Stock_Response
            {
                Id = stock.Id,
                Warehouse_Id = stock.Warehouse_Id,
                Commodity_Id = stock.Commodity_Id
            };
        }

        public async Task<string> CreateStockAsync(Stock_Request stock)
        {
            var newStock = new Stock
            {
                Warehouse_Id = stock.Warehouse_Id,
                Commodity_Id = stock.Commodity_Id,
                Id = stock.Id
            };
            await loginDbContext.Stocks.AddAsync(newStock);
            await loginDbContext.SaveChangesAsync();
            return "Stock created successfully";
        }
        public async Task <Stock_Response> UpdateStock(int id,Stock_Request stock)
        {
            var existingStock = await loginDbContext.Stocks.FindAsync(stock.Id);
            if (existingStock == null)
            {
                return null;
            }
            existingStock.Warehouse_Id = stock.Warehouse_Id;
            existingStock.Commodity_Id = stock.Commodity_Id;
            existingStock.Id = stock.Id;
            await loginDbContext.SaveChangesAsync();
            return new Stock_Response
            {
                Id = existingStock.Id,
                Warehouse_Id = existingStock.Warehouse_Id,
                Commodity_Id = existingStock.Commodity_Id
            };

        }
        public async Task<bool> DeleteStock(int id)
        {
            var stock = await loginDbContext.Stocks.FindAsync(id);
            if (stock == null)
            {
                return false;
            }
            loginDbContext.Stocks.Remove(stock);
            await loginDbContext.SaveChangesAsync();
            return true;
        }
    }
}
