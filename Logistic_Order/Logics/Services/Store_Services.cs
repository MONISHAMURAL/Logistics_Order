using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class Store_Services:IStore
    {
        private readonly LoginDbContext loginDbContext;
        public Store_Services(LoginDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }
        public async Task<IEnumerable<Store_Response>> GetAllStoresAsync()
        {
            var stores = await loginDbContext.Stores.ToListAsync();
            return stores.Select(store => new Store_Response
            {
                Id = store.Id,
                Supplier_Id = store.Supplier_Id,
                Warehouse_Id = store.Warehouse_Id,
            });
        }
        public async Task<Store_Response> GetStoreByIdAsync(int id)
        {
            var store = await loginDbContext.Stores.FindAsync(id);
            if (store == null)
            {
                return null;
            }
            return new Store_Response
            {
                Id = store.Id,
              Supplier_Id = store.Supplier_Id,
              Warehouse_Id =store.Warehouse_Id,
                
            };
        }
        public async Task<string> CreateStoreAsync(Store_Request store)
        {
            var newStore = new Store
            {
                Id= store.Id,
                Supplier_Id = store.Supplier_Id,
                Warehouse_Id = store.Warehouse_Id,
            };
            await loginDbContext.Stores.AddAsync(newStore);
            await loginDbContext.SaveChangesAsync();
            return "Store created successfully";
        }
        public async Task<Store_Response> UpdateStore(int id, Store_Request store)
        {
            var existingStore = await loginDbContext.Stores.FindAsync(id);
            if (existingStore == null)
            {
                return null;
            }
           existingStore.Supplier_Id = store.Supplier_Id;
            existingStore.Warehouse_Id = store.Warehouse_Id;

            await loginDbContext.SaveChangesAsync();
            return new Store_Response
            {
                Id = existingStore.Id,
                Supplier_Id = existingStore.Supplier_Id,
                Warehouse_Id = existingStore.Warehouse_Id,
            };
        }
        public async Task<bool> DeleteStore(int id)
        {
            var store = await loginDbContext.Stores.FindAsync(id);
            if (store == null)
            {
                return false;
            }
            loginDbContext.Stores.Remove(store);
            await loginDbContext.SaveChangesAsync();
            return true;
        }

    }
}
