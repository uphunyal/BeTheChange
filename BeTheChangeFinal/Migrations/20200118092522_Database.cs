using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeTheChangeFinal.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charity_Type",
                columns: table => new
                {
                    ctype_name = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Charity___AEFECC1A1C13ADD2", x => x.ctype_name);
                });

            migrationBuilder.CreateTable(
                name: "Custom_Causes",
                columns: table => new
                {
                    custom_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custom_name = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    custom_details = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    custom_location = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    cause_type = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    donate_link = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Custom_C__8664B23A2218D9AE", x => x.custom_id);
                });

            migrationBuilder.CreateTable(
                name: "Disaster_type",
                columns: table => new
                {
                    dtype_name = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Disaster__56E16900129580B2", x => x.dtype_name);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    post_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post_details = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    post_date = table.Column<DateTime>(type: "date", nullable: false),
                    post_title = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    user_email = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Posts__3ED7876680D93C76", x => x.post_id);
                });

            migrationBuilder.CreateTable(
                name: "Charity",
                columns: table => new
                {
                    charity_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    charity_details = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    charity_name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    charity_organization = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    charity_location = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    charity_link = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    ctype_name = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charity", x => x.charity_id);
                    table.ForeignKey(
                        name: "FK__Charity__ctype_n__2C3393D0",
                        column: x => x.ctype_name,
                        principalTable: "Charity_Type",
                        principalColumn: "ctype_name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disaster",
                columns: table => new
                {
                    disaster_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    disaster_name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    disaster_details = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    disaster_location = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    disaster_link = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    urgency = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    dtype_name = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disaster", x => x.disaster_id);
                    table.ForeignKey(
                        name: "FK__Disaster__dtype___2F10007B",
                        column: x => x.dtype_name,
                        principalTable: "Disaster_type",
                        principalColumn: "dtype_name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charity_ctype_name",
                table: "Charity",
                column: "ctype_name");

            migrationBuilder.CreateIndex(
                name: "IX_Disaster_dtype_name",
                table: "Disaster",
                column: "dtype_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charity");

            migrationBuilder.DropTable(
                name: "Custom_Causes");

            migrationBuilder.DropTable(
                name: "Disaster");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Charity_Type");

            migrationBuilder.DropTable(
                name: "Disaster_type");
        }
    }
}
