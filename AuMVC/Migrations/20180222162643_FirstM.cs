using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuMVC.Migrations
{
    public partial class FirstM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    ContractDate = table.Column<DateTime>(nullable: false),
                    ContractValueExGST = table.Column<double>(nullable: false),
                    ContractValueIncGST = table.Column<double>(nullable: false),
                    DOPCDate = table.Column<DateTime>(nullable: false),
                    HomeOwner = table.Column<string>(nullable: true),
                    HouseType = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    PreContactEOT = table.Column<int>(nullable: false),
                    SiteNumber = table.Column<string>(nullable: false),
                    TwelveMonthMaintenance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<int>(nullable: false),
                    DateRaised = table.Column<DateTime>(nullable: false),
                    IssueCode = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressStages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedBy = table.Column<string>(nullable: true),
                    CompletedBy = table.Column<string>(nullable: true),
                    DateApproved = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    PaymentStatus = table.Column<int>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    Stage = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressStages_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Claimed = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Contract = table.Column<int>(nullable: false),
                    DateReleased = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EOT = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Paid = table.Column<bool>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    VariationCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variations_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_SiteId",
                table: "Issues",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_SiteId",
                table: "Maintenances",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressStages_SiteId",
                table: "ProgressStages",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_SiteId",
                table: "Variations",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "ProgressStages");

            migrationBuilder.DropTable(
                name: "Variations");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
