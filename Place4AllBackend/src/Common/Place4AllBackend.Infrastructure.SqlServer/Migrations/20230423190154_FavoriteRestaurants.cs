using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Place4AllBackend.Infrastructure.SqlServer.Migrations
{
    public partial class FavoriteRestaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteRestaurants",
                columns: table => new
                {
                    FavoriteRestaurantsId = table.Column<int>(type: "int", nullable: false),
                    FavoriteUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteRestaurants", x => new { x.FavoriteRestaurantsId, x.FavoriteUsersId });
                    table.ForeignKey(
                        name: "FK_FavoriteRestaurants_AspNetUsers_FavoriteUsersId",
                        column: x => x.FavoriteUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteRestaurants_Restaurants_FavoriteRestaurantsId",
                        column: x => x.FavoriteRestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteRestaurants_FavoriteUsersId",
                table: "FavoriteRestaurants",
                column: "FavoriteUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteRestaurants");
        }
    }
}
