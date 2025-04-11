using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class Commodity_Category_Services:ICommodities_Category
    {
        private readonly LoginDbContext _context;
        public Commodity_Category_Services(LoginDbContext _context)
        {
            this._context = _context;
        }
        public async  Task<string> CreateCategory(Commodity_Category_Request request)
        {
            try
            {
                var existingCategory = await _context.Commodity_Categories
                    .FirstOrDefaultAsync(c => c.CommodityId == request.CommodityId);
                if (existingCategory != null)
                {
                    return "Category already exists";
                }
                Commodity_Category category = new Commodity_Category()
                {
                    CategoryName = request.CategoryName,
                    Id = request.Id,
                    CommodityId = request.CommodityId,
                    
                };
                _context.Commodity_Categories.Add(category);
                await _context.SaveChangesAsync();
                return "Category added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<IEnumerable<Commodity_Category_Response>> GetCategory()
        {
            try
            {
                var categories = await _context.Commodity_Categories.ToListAsync();
                return categories.Select(c => new Commodity_Category_Response
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    CommodityId = c.CommodityId,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories: " + ex.Message);
            }
        }
        public async Task<Commodity_Category_Response> GetCategoryById(int categoryId)
        {
            try
            {
                var category = await _context.Commodity_Categories.FindAsync(categoryId);
                if (category == null)
                {
                    throw new Exception("Category not found");
                }
                return new Commodity_Category_Response
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    CommodityId = category.CommodityId,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving category: " + ex.Message);
            }
        }
        public async Task<string> UpdateCategory(Commodity_Category_Request request)
        {
            try
            {
                var category = await _context.Commodity_Categories.FindAsync(request.Id);
                if (category == null)
                {
                    return "Category not found";
                }
                category.CategoryName = request.CategoryName;
                category.CommodityId = request.CommodityId;
                _context.Commodity_Categories.Update(category);
                await _context.SaveChangesAsync();
                return "Category updated successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<bool> DeleteCategory(int categoryId)
        {
            try
            {
                var category = await _context.Commodity_Categories.FindAsync(categoryId);
                if (category == null)
                {
                    return false;
                }
                _context.Commodity_Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
