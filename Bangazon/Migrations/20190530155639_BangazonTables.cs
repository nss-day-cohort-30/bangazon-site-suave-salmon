using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class BangazonTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0c84761-fd7d-43d5-ab80-1d1168a4a987");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c453d0c5-5f9d-4a07-ad71-c9a56ee28dbc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "70f75005-fadc-4625-8b16-281415e28466", 0, "123d8ae5-49b3-426b-837b-3cb4697aeb32", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEG+wq7ldFrmtjXZTzW3bS/WFBIUVNWlj9bkkDr9Z4f06VMthdoVibLoxNZec6kiheQ==", null, false, "05b6748d-0450-4ad3-8f65-fdb00a5993b8", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "64785967-88d1-4d9f-9f40-9e22597a1f4f", 0, "02561686-8064-4a99-bc4d-f707b77dad57", "xdomix52@yahoo.com", true, "Dom", "kantrude", false, null, "XDOMI52X@YAHOO.COM", "XDOMI52X@YAHOO.COM", "AQAAAAEAACcQAAAAENTZosgiaV31OAt8PA7Db7vD1RzoyVMrr9OILv565tYecm8O4IWBrXvWNHSdsmRAwQ==", null, false, "28c23c5f-433e-4bb3-b681-34de9b8bb7f6", "5937 place", false, "xdomix52@yahoo.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "93a3c99d-4988-4451-a623-c82241c5d81c", 0, "1ae40f5e-c496-49fb-8387-445d33ec8e78", "person@person.com", true, "person", "three", false, null, "PERSON@PERSON.COM", "PERSON@PERSON.COM", null, null, false, "b917ab63-462a-41a7-80bd-737b3d2e4a9a", "another place", false, "person@person.com" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 1,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 2,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 3,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 4,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "UserId",
                value: "70f75005-fadc-4625-8b16-281415e28466");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64785967-88d1-4d9f-9f40-9e22597a1f4f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70f75005-fadc-4625-8b16-281415e28466");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93a3c99d-4988-4451-a623-c82241c5d81c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7d1f99f-6683-4586-aa76-d1de17b2867c", 0, "e40148dc-83c8-4863-b2b2-fa42c4b202b7", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPhS0dCVAEPRhD4spwECq8opEhyhizNMBASa+qDSw67926CZJRz1dAkl2fkcH7x9Cw==", null, false, "dde3ec8a-b928-4bb3-a030-bc1bdbec165d", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c0c84761-fd7d-43d5-ab80-1d1168a4a987", 0, "d5214ab4-2663-4232-8fee-08a50a895ced", "xdomix52@yahoo.com", true, "Dom", "kantrude", false, null, "XDOMI52X@YAHOO.COM", "XDOMI52X@YAHOO.COM", "AQAAAAEAACcQAAAAEN+ZGqBQaiAxmYl1bunqsPjnZ7jWhw9MAZypwRB8H/go/GP4wSSlEX3+C2Jzly2jrQ==", null, false, "20d06697-bd21-43f8-b142-fc2655f2ea1a", "5937 place", false, "xdomix52@yahoo.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c453d0c5-5f9d-4a07-ad71-c9a56ee28dbc", 0, "61914633-1a94-45f3-98dd-618ecee78007", "person@person.com", true, "person", "three", false, null, "PERSON@PERSON.COM", "PERSON@PERSON.COM", null, null, false, "5138ec02-c73f-429d-88b1-098345365e90", "another place", false, "person@person.com" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 1,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 2,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 3,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 4,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "UserId",
                value: "c7d1f99f-6683-4586-aa76-d1de17b2867c");
        }
    }
}
