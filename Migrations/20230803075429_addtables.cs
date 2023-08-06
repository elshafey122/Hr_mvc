using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvclab2.Migrations
{
    public partial class addtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "offices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "emp_Projects",
                columns: table => new
                {
                    Emp_id = table.Column<int>(type: "int", nullable: false),
                    Project_id = table.Column<int>(type: "int", nullable: false),
                    Working_hours = table.Column<int>(type: "int", nullable: false),
                    employeesId = table.Column<int>(type: "int", nullable: true),
                    projectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emp_Projects", x => new { x.Emp_id, x.Project_id });
                    table.ForeignKey(
                        name: "FK_emp_Projects_employees_employeesId",
                        column: x => x.employeesId,
                        principalTable: "employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_emp_Projects_projects_projectsId",
                        column: x => x.projectsId,
                        principalTable: "projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_emp_Projects_employeesId",
                table: "emp_Projects",
                column: "employeesId");

            migrationBuilder.CreateIndex(
                name: "IX_emp_Projects_projectsId",
                table: "emp_Projects",
                column: "projectsId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_OfficeId",
                table: "employees",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emp_Projects");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "offices");
        }
    }
}
