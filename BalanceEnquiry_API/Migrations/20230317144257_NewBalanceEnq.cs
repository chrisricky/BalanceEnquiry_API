using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BalanceEnquiry_API.Migrations
{
    /// <inheritdoc />
    public partial class NewBalanceEnq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsableBalance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookBalance = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");
        }
    }
}
