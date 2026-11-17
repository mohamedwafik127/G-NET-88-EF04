using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalBank.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Branch_BranchCode",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Manager_ManagerId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccount_Account_AccountNumber",
                table: "CustomerAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccount_Customer_CustomerId",
                table: "CustomerAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_AccountNumber",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerAccount",
                table: "CustomerAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.RenameTable(
                name: "CustomerAccount",
                newName: "CustomerAccounts");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AccountNumber",
                table: "Transactions",
                newName: "IX_Transactions_AccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccount_AccountNumber",
                table: "CustomerAccounts",
                newName: "IX_CustomerAccounts_AccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_ManagerId",
                table: "Branches",
                newName: "IX_Branches_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_BranchCode",
                table: "Accounts",
                newName: "IX_Accounts_BranchCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerAccounts",
                table: "CustomerAccounts",
                columns: new[] { "CustomerId", "AccountNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "AccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branches_BranchCode",
                table: "Accounts",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Managers_ManagerId",
                table: "Branches",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_Accounts_AccountNumber",
                table: "CustomerAccounts",
                column: "AccountNumber",
                principalTable: "Accounts",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_Customers_CustomerId",
                table: "CustomerAccounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountNumber",
                table: "Transactions",
                column: "AccountNumber",
                principalTable: "Accounts",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branches_BranchCode",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Managers_ManagerId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_Accounts_AccountNumber",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_Customers_CustomerId",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountNumber",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerAccounts",
                table: "CustomerAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "CustomerAccounts",
                newName: "CustomerAccount");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccountNumber",
                table: "Transaction",
                newName: "IX_Transaction_AccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccounts_AccountNumber",
                table: "CustomerAccount",
                newName: "IX_CustomerAccount_AccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_ManagerId",
                table: "Branch",
                newName: "IX_Branch_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_BranchCode",
                table: "Account",
                newName: "IX_Account_BranchCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "TransactionNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerAccount",
                table: "CustomerAccount",
                columns: new[] { "CustomerId", "AccountNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "AccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Branch_BranchCode",
                table: "Account",
                column: "BranchCode",
                principalTable: "Branch",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Manager_ManagerId",
                table: "Branch",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccount_Account_AccountNumber",
                table: "CustomerAccount",
                column: "AccountNumber",
                principalTable: "Account",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccount_Customer_CustomerId",
                table: "CustomerAccount",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_AccountNumber",
                table: "Transaction",
                column: "AccountNumber",
                principalTable: "Account",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
