using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clothes_Shop.Migrations.BD2Sklep
{
    public partial class backup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandTab",
                columns: table => new
                {
                    BrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTab", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTab",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(unicode: false, maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTab", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CityTab",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTab", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "ColorTab",
                columns: table => new
                {
                    ColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorName", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "GenderTab",
                columns: table => new
                {
                    GenderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTab", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTab",
                columns: table => new
                {
                    MaterialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTab", x => x.MaterialID);
                });

            migrationBuilder.CreateTable(
                name: "Shipper",
                columns: table => new
                {
                    ShipperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, fixedLength: true, maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipper", x => x.ShipperID);
                });

            migrationBuilder.CreateTable(
                name: "SizeTab",
                columns: table => new
                {
                    SizeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeTab", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "StreetTab",
                columns: table => new
                {
                    StreetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetTab", x => x.StreetID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(unicode: false, fixedLength: true, maxLength: 130, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, fixedLength: true, maxLength: 9, nullable: false),
                    CityID = table.Column<int>(nullable: true),
                    StreetID = table.Column<int>(nullable: true),
                    HomeNumber = table.Column<int>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: true),
                    AccessLevel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    Season = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    GenderID = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false),
                    SizeID = table.Column<int>(nullable: false),
                    MaterialID = table.Column<int>(nullable: false),
                    Pattern = table.Column<string>(maxLength: 30, nullable: false),
                    BrandID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_BrandTab",
                        column: x => x.BrandID,
                        principalTable: "BrandTab",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_CategoryTab",
                        column: x => x.CategoryID,
                        principalTable: "CategoryTab",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ColorName",
                        column: x => x.ColorID,
                        principalTable: "ColorTab",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_GenderTab",
                        column: x => x.GenderID,
                        principalTable: "GenderTab",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_MaterialTab",
                        column: x => x.MaterialID,
                        principalTable: "MaterialTab",
                        principalColumn: "MaterialID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_SizeTab",
                        column: x => x.SizeID,
                        principalTable: "SizeTab",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    BasketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.BasketID);
                    table.ForeignKey(
                        name: "FK_Basket_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddress",
                columns: table => new
                {
                    ClientAddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    StreetID = table.Column<int>(nullable: false),
                    StreetNumber = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    HomeNumber = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    isMain = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddress", x => x.ClientAddressID);
                    table.ForeignKey(
                        name: "FK_ClientAddress_CityTab1",
                        column: x => x.CityID,
                        principalTable: "CityTab",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_StreetTab",
                        column: x => x.StreetID,
                        principalTable: "StreetTab",
                        principalColumn: "StreetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAddress_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    PaymentType = table.Column<string>(maxLength: 30, nullable: false),
                    PaymentStatus = table.Column<string>(maxLength: 30, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "date", nullable: true),
                    ShipperID = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Shipper",
                        column: x => x.ShipperID,
                        principalTable: "Shipper",
                        principalColumn: "ShipperID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Opinion",
                columns: table => new
                {
                    OpinionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Rate = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinion", x => x.OpinionID);
                    table.ForeignKey(
                        name: "FK_Opinion_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opinion_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasketDetails",
                columns: table => new
                {
                    BasketDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketDetails", x => x.BasketDetailsID);
                    table.ForeignKey(
                        name: "FK_BasketDetails_Basket",
                        column: x => x.BasketID,
                        principalTable: "Basket",
                        principalColumn: "BasketID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketDetails_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailsID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_UserID",
                table: "Basket",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_BasketID",
                table: "BasketDetails",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_ProductID",
                table: "BasketDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTab",
                table: "BrandTab",
                column: "BrandName");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTab",
                table: "CategoryTab",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_CityTab",
                table: "CityTab",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_CityID",
                table: "ClientAddress",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_StreetID",
                table: "ClientAddress",
                column: "StreetID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_UserID",
                table: "ClientAddress",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ColorTab",
                table: "ColorTab",
                column: "ColorName");

            migrationBuilder.CreateIndex(
                name: "IX_GenderTab",
                table: "GenderTab",
                column: "GenderName");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTab",
                table: "MaterialTab",
                column: "MaterialName");

            migrationBuilder.CreateIndex(
                name: "IX_Opinion_ProductID",
                table: "Opinion",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Opinion_UserID",
                table: "Opinion",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_1",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipperID",
                table: "Orders",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_5",
                table: "Product",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ColorID",
                table: "Product",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_GenderID",
                table: "Product",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MaterialID",
                table: "Product",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_4",
                table: "Product",
                column: "Pattern");

            migrationBuilder.CreateIndex(
                name: "IX_Product_1",
                table: "Product",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Product_2",
                table: "Product",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "IX_Product_3",
                table: "Product",
                column: "Season");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeID",
                table: "Product",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_SizeTab",
                table: "SizeTab",
                column: "SizeName");

            migrationBuilder.CreateIndex(
                name: "IX_StreetTab",
                table: "StreetTab",
                column: "StreetName");

            migrationBuilder.CreateIndex(
                name: "IX_User_5",
                table: "User",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_User_1",
                table: "User",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_User_3",
                table: "User",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_User_7",
                table: "User",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_4",
                table: "User",
                column: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketDetails");

            migrationBuilder.DropTable(
                name: "ClientAddress");

            migrationBuilder.DropTable(
                name: "Opinion");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "CityTab");

            migrationBuilder.DropTable(
                name: "StreetTab");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Shipper");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BrandTab");

            migrationBuilder.DropTable(
                name: "CategoryTab");

            migrationBuilder.DropTable(
                name: "ColorTab");

            migrationBuilder.DropTable(
                name: "GenderTab");

            migrationBuilder.DropTable(
                name: "MaterialTab");

            migrationBuilder.DropTable(
                name: "SizeTab");
        }
    }
}
