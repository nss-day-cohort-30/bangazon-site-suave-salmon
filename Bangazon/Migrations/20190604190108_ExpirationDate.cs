﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class ExpirationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(maxLength: 55, nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 20, nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.PaymentTypeId);
                    table.ForeignKey(
                        name: "FK_PaymentType_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Title = table.Column<string>(maxLength: 55, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ProductTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateCompleted = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "09e348ff-91cb-45b9-9401-6d59375acd9e", 0, "dd902efc-21c1-4dcf-801c-579fef9c83a5", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEOgT/dXVwnBjJaRlQSqWnHHNvIY5sw9/Y0omowFh4DBXsImwsyS5ox8hvSKsWMWbxA==", null, false, "0cd2c37c-2049-4037-9267-ecfd7d3468c3", "123 Infinity Way", false, "admin@admin.com" },
                    { "76e46903-acca-4f97-ad10-fd7935f315ea", 0, "d5dc4db9-cbe0-4414-80c6-8ca846c07e73", "xdomix52@yahoo.com", true, "Dom", "kantrude", false, null, "XDOMI52X@YAHOO.COM", "XDOMI52X@YAHOO.COM", "AQAAAAEAACcQAAAAEA0wChwMt57uuyTwbBCSIiUUCJ7SbPATi6vVMa233/su8kI/XtQDlf7EZ40Cio9Tmg==", null, false, "9b0a5b94-19ec-46c5-953f-f4dfba1c1b05", "5937 place", false, "xdomix52@yahoo.com" },
                    { "afe72120-70fa-4489-9c1d-31e86ee327f7", 0, "a1f32bc9-7073-4913-8d65-540b2c6eab66", "person@person.com", true, "person", "three", false, null, "PERSON@PERSON.COM", "PERSON@PERSON.COM", null, null, false, "ee73e7d4-1701-4ecf-af36-7f7fd1c1da49", "another place", false, "person@person.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ProductTypeId", "Label" },
                values: new object[,]
                {
                    { 1, "Sporting Goods" },
                    { 2, "Appliances" },
                    { 3, "Video Game" },
                    { 4, "Stuff" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "DateCompleted", "PaymentTypeId", "UserId" },
                values: new object[] { 1, null, null, "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "DateCompleted", "PaymentTypeId", "UserId" },
                values: new object[] { 2, null, null, "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "DateCompleted", "PaymentTypeId", "UserId" },
                values: new object[] { 3, null, null, "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "DateCompleted", "PaymentTypeId", "UserId" },
                values: new object[] { 4, null, null, "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "PaymentTypeId", "AccountNumber", "Description", "ExpirationDate", "UserId" },
                values: new object[] { 1, "86753095551212", "American Express", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "PaymentTypeId", "AccountNumber", "Description", "ExpirationDate", "UserId" },
                values: new object[] { 2, "4102948572991", "Discover", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "PaymentTypeId", "AccountNumber", "Description", "ExpirationDate", "UserId" },
                values: new object[] { 3, "0000133700000", "Visa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "PaymentTypeId", "AccountNumber", "Description", "ExpirationDate", "UserId" },
                values: new object[] { 4, "1111800711111", "American Express", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "City", "Description", "ImagePath", "Price", "ProductTypeId", "Quantity", "Title", "UserId" },
                values: new object[] { 1, null, "It flies high", null, 2.9900000000000002, 1, 100, "Kite", "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "City", "Description", "ImagePath", "Price", "ProductTypeId", "Quantity", "Title", "UserId" },
                values: new object[] { 2, null, "It rolls fast", null, 29.989999999999998, 2, 5, "Wheelbarrow", "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "City", "Description", "ImagePath", "Price", "ProductTypeId", "Quantity", "Title", "UserId" },
                values: new object[] { 3, null, "Its cold yo", null, 29.989999999999998, 2, 5, "Fridge", "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "City", "Description", "ImagePath", "Price", "ProductTypeId", "Quantity", "Title", "UserId" },
                values: new object[] { 4, null, "Tear people in half", null, 29.989999999999998, 3, 5, "God of War", "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "City", "Description", "ImagePath", "Price", "ProductTypeId", "Quantity", "Title", "UserId" },
                values: new object[] { 5, null, "Its a thing idk", null, 29.989999999999998, 4, 5, "something", "09e348ff-91cb-45b9-9401-6d59375acd9e" });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentTypeId",
                table: "Order",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_UserId",
                table: "PaymentType",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
