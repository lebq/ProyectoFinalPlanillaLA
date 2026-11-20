using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galaxy.Bank.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Bank");

            migrationBuilder.CreateTable(
                name: "CreditProducts",
                schema: "Bank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    minimum_term = table.Column<int>(type: "int", nullable: false),
                    maximum_term = table.Column<int>(type: "int", nullable: false),
                    maximum_amount_currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    maximum_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    minimum_amount_currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    minimum_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    annual_interest_rate = table.Column<decimal>(type: "decimal(5,4)", precision: 5, scale: 4, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Bank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    document_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    document_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    born_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                schema: "Bank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    credit_product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    term_months = table.Column<int>(type: "int", nullable: false),
                    interest_rate = table.Column<decimal>(type: "decimal(5,4)", precision: 5, scale: 4, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    reason_status = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_CreditProducts_credit_product_id",
                        column: x => x.credit_product_id,
                        principalSchema: "Bank",
                        principalTable: "CreditProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loans_Customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "Bank",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "Bank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    interest_currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    interest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    paid_amount_currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    paid_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Loans_loan_id",
                        column: x => x.loan_id,
                        principalSchema: "Bank",
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditProducts_Name",
                schema: "Bank",
                table: "CreditProducts",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Document_Type_Number",
                schema: "Bank",
                table: "Customers",
                columns: new[] { "document_type", "document_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CreditProductId",
                schema: "Bank",
                table: "Loans",
                column: "credit_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                schema: "Bank",
                table: "Loans",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_LoanId",
                schema: "Bank",
                table: "Payments",
                column: "loan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_LoanId_Number",
                schema: "Bank",
                table: "Payments",
                columns: new[] { "loan_id", "number" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments",
                schema: "Bank");

            migrationBuilder.DropTable(
                name: "Loans",
                schema: "Bank");

            migrationBuilder.DropTable(
                name: "CreditProducts",
                schema: "Bank");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Bank");
        }
    }
}
