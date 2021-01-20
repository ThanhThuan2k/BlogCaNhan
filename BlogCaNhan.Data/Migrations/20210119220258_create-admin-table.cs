using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogCaNhan.Data.Migrations
{
    public partial class createadmintable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 500, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 500, nullable: true),
                    SDT = table.Column<string>(maxLength: 13, nullable: true),
                    isBlock = table.Column<bool>(nullable: false),
                    isSupper = table.Column<bool>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    HoTen = table.Column<string>(nullable: true),
                    isMale = table.Column<bool>(nullable: true),
                    QueQuan = table.Column<string>(maxLength: 1000, nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    Salt = table.Column<Guid>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
