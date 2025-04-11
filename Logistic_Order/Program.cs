using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Logics.IServices;
using Logistic_Order.Logics.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LoginDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IBuyerServices, BuyerServices>();
builder.Services.AddTransient<ICommodityServices, CommodityServices>();
builder.Services.AddTransient<ISupplier, SupplierServices>();
builder.Services.AddTransient<IWareHouse, WareHouseServices>();
builder.Services.AddTransient<ICommodities_Category,Commodity_Category_Services>();
builder.Services.AddTransient<IDeliveryServices, DeliveryServices>();
builder.Services.AddTransient<IFeedbackServices, FeedbackServices>();
builder.Services.AddTransient<IInvoiceServices, InvoiceServices>();
builder.Services.AddTransient<ILoginServices, LoginServices>();
builder.Services.AddTransient<ILogin_Buyer, Login_Buyer_Services>();
builder.Services.AddTransient<ILogin_Supplier, Login_Supplier_Services>();
builder.Services.AddTransient<ILoginRole, LoginRoleServices>();
builder.Services.AddTransient<IOrder, Order_Services>();
builder.Services.AddTransient<IOrderSupplier, Order_supplier_Services>();
builder.Services.AddTransient<IOrderCommodities, OrderCommodities_Services>();
builder.Services.AddTransient<IPayment, PaymentServices>();
builder.Services.AddTransient<IPermissionServices, PermissionServices>();
builder.Services.AddTransient<IPermissionRole, PermissionRole_Services>();
builder.Services.AddTransient<IRoleServices, RoleServices>();
builder.Services.AddTransient<IShippingServices,ShippingServices>();
builder.Services.AddTransient<IShipping_Route, Shipping_Route_Services>();
builder.Services.AddTransient<IStockServices, StockServices>();
builder.Services.AddTransient<IStore, Store_Services>();
builder.Services.AddTransient<ITracking_Services, Tracking_Services>();
builder.Services.AddTransient<ITotalCost,TotalCostServices>();
builder.Services.AddTransient<ITracking_Services,Tracking_Services>();
builder.Services.AddTransient<IShippingType, ShippingType_Services>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
