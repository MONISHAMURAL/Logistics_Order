using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Logistic_Order.Migrations
{
    /// <inheritdoc />
    public partial class Logistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Buyer_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Buyer_First_Name = table.Column<string>(type: "text", nullable: false),
                    Buyer_Last_Name = table.Column<string>(type: "text", nullable: false),
                    Buyer_Company_Name = table.Column<string>(type: "text", nullable: false),
                    Buyer_Company_Address = table.Column<string>(type: "text", nullable: false),
                    Buyer_Company_City = table.Column<string>(type: "text", nullable: false),
                    Buyer_Company_State = table.Column<string>(type: "text", nullable: false),
                    Buyer_Company_ZipCode = table.Column<string>(type: "text", nullable: false),
                    Buyer_Company_Country = table.Column<string>(type: "text", nullable: false),
                    Buyer_Phone = table.Column<string>(type: "text", nullable: false),
                    Buyer_Email = table.Column<string>(type: "text", nullable: false),
                    Buyer_Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Buyer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Login_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Login_Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Permission_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Permission_Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Permission_Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role_Name = table.Column<string>(type: "text", nullable: false),
                    Role_Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipping_Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Origin = table.Column<string>(type: "text", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: false),
                    Route_Description = table.Column<string>(type: "text", nullable: false),
                    Route_Status = table.Column<string>(type: "text", nullable: false),
                    Route_Tracking_History = table.Column<string>(type: "text", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingTypes",
                columns: table => new
                {
                    Shipping_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Shipping_Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingTypes", x => x.Shipping_Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Warehouse_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Warehouse_Name = table.Column<string>(type: "text", nullable: false),
                    Warehouse_Address = table.Column<string>(type: "text", nullable: false),
                    Warehouse_City = table.Column<string>(type: "text", nullable: false),
                    Warehouse_State = table.Column<string>(type: "text", nullable: false),
                    Warehouse_ZipCode = table.Column<string>(type: "text", nullable: false),
                    Warehouse_Country = table.Column<string>(type: "text", nullable: false),
                    Warehouse_Phone = table.Column<string>(type: "text", nullable: false),
                    Warehouse_Email = table.Column<string>(type: "text", nullable: false),
                    Warehouse_Description = table.Column<string>(type: "text", nullable: false),
                    Warehouse_Website = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Warehouse_Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Feedback_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Feedback_Message = table.Column<string>(type: "text", nullable: false),
                    Feedback_Rating = table.Column<string>(type: "text", nullable: false),
                    Buyer_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Feedback_Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Buyers_Buyer_Id",
                        column: x => x.Buyer_Id,
                        principalTable: "Buyers",
                        principalColumn: "Buyer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_No = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order_Date = table.Column<string>(type: "text", nullable: false),
                    Order_Status = table.Column<string>(type: "text", nullable: false),
                    Order_Cost = table.Column<int>(type: "integer", nullable: false),
                    Buyer_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_No);
                    table.ForeignKey(
                        name: "FK_Orders_Buyers_Buyer_Id",
                        column: x => x.Buyer_Id,
                        principalTable: "Buyers",
                        principalColumn: "Buyer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginBuyers",
                columns: table => new
                {
                    Login_Id = table.Column<int>(type: "integer", nullable: false),
                    Buyer_Id = table.Column<int>(type: "integer", nullable: false),
                    Login_Buyer_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginBuyers", x => new { x.Login_Id, x.Buyer_Id });
                    table.ForeignKey(
                        name: "FK_LoginBuyers_Buyers_Buyer_Id",
                        column: x => x.Buyer_Id,
                        principalTable: "Buyers",
                        principalColumn: "Buyer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoginBuyers_Logins_Login_Id",
                        column: x => x.Login_Id,
                        principalTable: "Logins",
                        principalColumn: "Login_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginRoles",
                columns: table => new
                {
                    Login_Id = table.Column<int>(type: "integer", nullable: false),
                    Role_Id = table.Column<int>(type: "integer", nullable: false),
                    Login_Role_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginRoles", x => new { x.Login_Id, x.Role_Id });
                    table.ForeignKey(
                        name: "FK_LoginRoles_Logins_Login_Id",
                        column: x => x.Login_Id,
                        principalTable: "Logins",
                        principalColumn: "Login_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoginRoles_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRoles",
                columns: table => new
                {
                    Permission_Id = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Role_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRoles", x => x.Permission_Id);
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Permissions_Permission_Id",
                        column: x => x.Permission_Id,
                        principalTable: "Permissions",
                        principalColumn: "Permission_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Supplier_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Supplier_Name = table.Column<string>(type: "text", nullable: false),
                    Supplier_Company_Name = table.Column<string>(type: "text", nullable: false),
                    Supplier_Company_Address = table.Column<string>(type: "text", nullable: false),
                    Supplier_Company_City = table.Column<string>(type: "text", nullable: false),
                    Supplier_Company_State = table.Column<string>(type: "text", nullable: false),
                    Supplier_Company_ZipCode = table.Column<string>(type: "text", nullable: false),
                    Supplier_Company_Country = table.Column<string>(type: "text", nullable: false),
                    Supplier_Phone = table.Column<string>(type: "text", nullable: false),
                    Supplier_Email = table.Column<string>(type: "text", nullable: false),
                    Supplier_Description = table.Column<string>(type: "text", nullable: false),
                    Supplier_Company_Website = table.Column<string>(type: "text", nullable: false),
                    Warehouse_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Supplier_Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Warehouses_Warehouse_Id",
                        column: x => x.Warehouse_Id,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commodities",
                columns: table => new
                {
                    Commodity_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Commodity_Name = table.Column<string>(type: "text", nullable: false),
                    Commodity_Description = table.Column<string>(type: "text", nullable: false),
                    Commodity_Type = table.Column<string>(type: "text", nullable: false),
                    Commodity_Weight = table.Column<string>(type: "text", nullable: false),
                    Commodity_Quantity = table.Column<string>(type: "text", nullable: false),
                    Commodity_Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Commodity_Unit = table.Column<string>(type: "text", nullable: false),
                    Commodity_Status = table.Column<string>(type: "text", nullable: false),
                    Commodity_Date = table.Column<string>(type: "text", nullable: false),
                    Commodity_Expiry = table.Column<string>(type: "text", nullable: false),
                    Supplier_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodities", x => x.Commodity_Id);
                    table.ForeignKey(
                        name: "FK_Commodities_Suppliers_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Supplier_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginSuppliers",
                columns: table => new
                {
                    Login_Id = table.Column<int>(type: "integer", nullable: false),
                    Supplier_Id = table.Column<int>(type: "integer", nullable: false),
                    Login_Supplier_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginSuppliers", x => new { x.Login_Id, x.Supplier_Id });
                    table.ForeignKey(
                        name: "FK_LoginSuppliers_Logins_Login_Id",
                        column: x => x.Login_Id,
                        principalTable: "Logins",
                        principalColumn: "Login_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoginSuppliers_Suppliers_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Supplier_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Suppliers",
                columns: table => new
                {
                    Order_No = table.Column<int>(type: "integer", nullable: false),
                    Supplier_Id = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Suppliers", x => new { x.Order_No, x.Supplier_Id });
                    table.ForeignKey(
                        name: "FK_Order_Suppliers_Orders_Order_No",
                        column: x => x.Order_No,
                        principalTable: "Orders",
                        principalColumn: "Order_No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Suppliers_Suppliers_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Supplier_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    Shipping_Id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    Shipping_Carrier_Name = table.Column<string>(type: "text", nullable: false),
                    Shipping_expected_Delivery = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Shipping_Status = table.Column<string>(type: "text", nullable: false),
                    Shipping_Address = table.Column<string>(type: "text", nullable: false),
                    Shipping_City = table.Column<string>(type: "text", nullable: false),
                    Buyer_Id = table.Column<int>(type: "integer", nullable: false),
                    Warehouse_Id = table.Column<int>(type: "integer", nullable: false),
                    Supplier_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.Shipping_Id);
                    table.ForeignKey(
                        name: "FK_Shippings_Buyers_Buyer_Id",
                        column: x => x.Buyer_Id,
                        principalTable: "Buyers",
                        principalColumn: "Buyer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shippings_ShippingTypes_Shipping_Id",
                        column: x => x.Shipping_Id,
                        principalTable: "ShippingTypes",
                        principalColumn: "Shipping_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shippings_Suppliers_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Supplier_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shippings_Warehouses_Warehouse_Id",
                        column: x => x.Warehouse_Id,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Supplier_Id = table.Column<int>(type: "integer", nullable: false),
                    Warehouse_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Suppliers_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Supplier_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stores_Warehouses_Warehouse_Id",
                        column: x => x.Warehouse_Id,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commodity_Categories",
                columns: table => new
                {
                    CommodityId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity_Categories", x => x.CommodityId);
                    table.ForeignKey(
                        name: "FK_Commodity_Categories_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "Commodities",
                        principalColumn: "Commodity_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderCommodities",
                columns: table => new
                {
                    Order_No = table.Column<int>(type: "integer", nullable: false),
                    CommodityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCommodities", x => new { x.Order_No, x.CommodityId });
                    table.ForeignKey(
                        name: "FK_OrderCommodities_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "Commodities",
                        principalColumn: "Commodity_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCommodities_Orders_Order_No",
                        column: x => x.Order_No,
                        principalTable: "Orders",
                        principalColumn: "Order_No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Warehouse_Id = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Commodity_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Warehouse_Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Commodities_Commodity_Id",
                        column: x => x.Commodity_Id,
                        principalTable: "Commodities",
                        principalColumn: "Commodity_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Warehouses_Warehouse_Id",
                        column: x => x.Warehouse_Id,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivered",
                columns: table => new
                {
                    Delivery_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Delivery_Carrier_Name = table.Column<string>(type: "text", nullable: false),
                    Delivery_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Delivery_Status = table.Column<string>(type: "text", nullable: false),
                    Delivery_Confirmation = table.Column<string>(type: "text", nullable: false),
                    Delivery_Tracking_History = table.Column<string>(type: "text", nullable: false),
                    Shipping_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivered", x => x.Delivery_Id);
                    table.ForeignKey(
                        name: "FK_Delivered_Shippings_Shipping_Id",
                        column: x => x.Shipping_Id,
                        principalTable: "Shippings",
                        principalColumn: "Shipping_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Invoice_No = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Invoice_Date = table.Column<string>(type: "text", nullable: false),
                    Invoice_Status = table.Column<string>(type: "text", nullable: false),
                    Invoice_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Order_No = table.Column<int>(type: "integer", nullable: false),
                    Payment_Id = table.Column<int>(type: "integer", nullable: false),
                    Shipping_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Invoice_No);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_Order_No",
                        column: x => x.Order_No,
                        principalTable: "Orders",
                        principalColumn: "Order_No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Shippings_Shipping_Id",
                        column: x => x.Shipping_Id,
                        principalTable: "Shippings",
                        principalColumn: "Shipping_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trackings",
                columns: table => new
                {
                    Tracking_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    TrackingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tracking_Status = table.Column<string>(type: "text", nullable: false),
                    Tracking_History = table.Column<string>(type: "text", nullable: false),
                    Current_location = table.Column<string>(type: "text", nullable: false),
                    Route_Id = table.Column<int>(type: "integer", nullable: false),
                    Shipping_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trackings", x => x.Tracking_Id);
                    table.ForeignKey(
                        name: "FK_Trackings_Shipping_Routes_Route_Id",
                        column: x => x.Route_Id,
                        principalTable: "Shipping_Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trackings_Shippings_Shipping_Id",
                        column: x => x.Shipping_Id,
                        principalTable: "Shippings",
                        principalColumn: "Shipping_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Payment_Type = table.Column<string>(type: "text", nullable: false),
                    Payment_Description = table.Column<string>(type: "text", nullable: false),
                    Payment_Status = table.Column<string>(type: "text", nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cost_Id = table.Column<int>(type: "integer", nullable: false),
                    Buyer_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK_Payments_Buyers_Buyer_Id",
                        column: x => x.Buyer_Id,
                        principalTable: "Buyers",
                        principalColumn: "Buyer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_Payment_Id",
                        column: x => x.Payment_Id,
                        principalTable: "Invoices",
                        principalColumn: "Invoice_No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TotalCosts",
                columns: table => new
                {
                    Cost_Id = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Total_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Shipping_Id = table.Column<int>(type: "integer", nullable: false),
                    Order_No = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalCosts", x => x.Cost_Id);
                    table.ForeignKey(
                        name: "FK_TotalCosts_Orders_Order_No",
                        column: x => x.Order_No,
                        principalTable: "Orders",
                        principalColumn: "Order_No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalCosts_Payments_Cost_Id",
                        column: x => x.Cost_Id,
                        principalTable: "Payments",
                        principalColumn: "Payment_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalCosts_Shippings_Shipping_Id",
                        column: x => x.Shipping_Id,
                        principalTable: "Shippings",
                        principalColumn: "Shipping_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_Supplier_Id",
                table: "Commodities",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Delivered_Shipping_Id",
                table: "Delivered",
                column: "Shipping_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Buyer_Id",
                table: "Feedbacks",
                column: "Buyer_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Order_No",
                table: "Invoices",
                column: "Order_No");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Shipping_Id",
                table: "Invoices",
                column: "Shipping_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoginBuyers_Buyer_Id",
                table: "LoginBuyers",
                column: "Buyer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoginRoles_Role_Id",
                table: "LoginRoles",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoginSuppliers_Supplier_Id",
                table: "LoginSuppliers",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Suppliers_Supplier_Id",
                table: "Order_Suppliers",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCommodities_CommodityId",
                table: "OrderCommodities",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Buyer_Id",
                table: "Orders",
                column: "Buyer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Buyer_Id",
                table: "Payments",
                column: "Buyer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_Role_Id",
                table: "PermissionRoles",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_Buyer_Id",
                table: "Shippings",
                column: "Buyer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_Supplier_Id",
                table: "Shippings",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_Warehouse_Id",
                table: "Shippings",
                column: "Warehouse_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Commodity_Id",
                table: "Stocks",
                column: "Commodity_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Supplier_Id",
                table: "Stores",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Warehouse_Id",
                table: "Stores",
                column: "Warehouse_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Warehouse_Id",
                table: "Suppliers",
                column: "Warehouse_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TotalCosts_Order_No",
                table: "TotalCosts",
                column: "Order_No",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TotalCosts_Shipping_Id",
                table: "TotalCosts",
                column: "Shipping_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trackings_Route_Id",
                table: "Trackings",
                column: "Route_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trackings_Shipping_Id",
                table: "Trackings",
                column: "Shipping_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commodity_Categories");

            migrationBuilder.DropTable(
                name: "Delivered");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "LoginBuyers");

            migrationBuilder.DropTable(
                name: "LoginRoles");

            migrationBuilder.DropTable(
                name: "LoginSuppliers");

            migrationBuilder.DropTable(
                name: "Order_Suppliers");

            migrationBuilder.DropTable(
                name: "OrderCommodities");

            migrationBuilder.DropTable(
                name: "PermissionRoles");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "TotalCosts");

            migrationBuilder.DropTable(
                name: "Trackings");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Commodities");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Shipping_Routes");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shippings");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "ShippingTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
