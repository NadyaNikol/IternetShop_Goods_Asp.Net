using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class UserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Goods",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(nullable: true),
            //        Price = table.Column<double>(nullable: false),
            //        FileName = table.Column<string>(nullable: true),
            //        Path = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Goods", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
