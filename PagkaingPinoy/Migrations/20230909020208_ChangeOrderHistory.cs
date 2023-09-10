using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PagkaingPinoy.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDetail",
                table: "OrderHistories",
                newName: "NumberOfItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfItems",
                table: "OrderHistories",
                newName: "OrderDetail");
        }
    }
}
