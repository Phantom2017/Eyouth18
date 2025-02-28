using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eyouth1.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MgrName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Img = table.Column<string>(type: "varchar(max)", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "MgrName", "Name" },
                values: new object[,]
                {
                    { 1, "Robert King", "Human Resources" },
                    { 2, "Emily Carter", "Finance" },
                    { 3, "Michael Adams", "IT" },
                    { 4, "Sophia Martinez", "Marketing" },
                    { 5, "Daniel Thompson", "Sales" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DeptId", "Img", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "123 Main St", 3, "boy.jpg", "Alice Johnson", 75432.67m },
                    { 2, "456 Elm St", 1, "girl.jpg", "Bob Smith", 52789.34m },
                    { 3, "789 Oak St", 5, "boy.jpg", "Charlie Brown", 88123.45m },
                    { 4, "101 Maple Ave", 2, "girl.jpg", "David Williams", 63543.12m },
                    { 5, "222 Pine St", 4, "girl.jpg", "Emma Davis", 91876.89m },
                    { 6, "333 Birch Rd", 3, "boy.jpg", "Frank Miller", 47654.23m },
                    { 7, "444 Cedar Ln", 1, "girl.jpg", "Grace Wilson", 68789.45m },
                    { 8, "555 Spruce Ct", 2, "boy.jpg", "Henry Moore", 79999.99m },
                    { 9, "666 Willow Dr", 5, "girl.jpg", "Ivy Taylor", 56432.78m },
                    { 10, "777 Ash Blvd", 4, "girl.jpg", "Jack White", 84567.90m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptId",
                table: "Employees",
                column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
