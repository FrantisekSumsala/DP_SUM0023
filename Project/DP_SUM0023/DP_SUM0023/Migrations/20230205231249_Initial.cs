using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DPSUM0023.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "useraccountrole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useraccountrole", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_project_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "useraccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useraccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_useraccount_useraccountrole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "useraccountrole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "process",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_process", x => x.Id);
                    table.ForeignKey(
                        name: "FK_process_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_process_useraccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "useraccount",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "useraccountlogin",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(255)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false),
                    PasswordSalt = table.Column<string>(type: "longtext", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useraccountlogin", x => x.Username);
                    table.ForeignKey(
                        name: "FK_useraccountlogin_useraccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "useraccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "processevaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DatePerformed = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    EvaluatorAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processevaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_processevaluation_process_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "process",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_processevaluation_useraccount_EvaluatorAccountId",
                        column: x => x.EvaluatorAccountId,
                        principalTable: "useraccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_process_ProjectId",
                table: "process",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_process_UserAccountId",
                table: "process",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_processevaluation_EvaluatorAccountId",
                table: "processevaluation",
                column: "EvaluatorAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_processevaluation_ProcessId",
                table: "processevaluation",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_project_CompanyId",
                table: "project",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_useraccount_RoleId",
                table: "useraccount",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_useraccountlogin_AccountId",
                table: "useraccountlogin",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "processevaluation");

            migrationBuilder.DropTable(
                name: "useraccountlogin");

            migrationBuilder.DropTable(
                name: "process");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "useraccount");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "useraccountrole");
        }
    }
}
