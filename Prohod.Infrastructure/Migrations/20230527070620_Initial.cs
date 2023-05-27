using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prohod.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Passport_FullName = table.Column<string>(type: "text", nullable: false),
                    Passport_Series = table.Column<string>(type: "text", nullable: false),
                    Passport_Number = table.Column<string>(type: "text", nullable: false),
                    Passport_WhoIssued = table.Column<string>(type: "text", nullable: false),
                    Passport_IssueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    VisitTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserToVisitId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailToSendReply = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_Users_UserToVisitId",
                        column: x => x.UserToVisitId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormId = table.Column<Guid>(type: "uuid", nullable: false),
                    WhoProcessedId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RejectionReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitRequests_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitRequests_Users_WhoProcessedId",
                        column: x => x.WhoProcessedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_UserToVisitId",
                table: "Forms",
                column: "UserToVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitRequests_FormId",
                table: "VisitRequests",
                column: "FormId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitRequests_WhoProcessedId",
                table: "VisitRequests",
                column: "WhoProcessedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitRequests");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
