using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beautystbackend.Migrations
{
    /// <inheritdoc />
    public partial class Beautyst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleParagraph1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleParagraph2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedRecordImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedRecordVideo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleID);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "MyList",
                columns: table => new
                {
                    ListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    articleid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyList", x => x.ListID);
                    table.ForeignKey(
                        name: "FK_MyList_Article_articleid",
                        column: x => x.articleid,
                        principalTable: "Article",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyList_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyList_articleid",
                table: "MyList",
                column: "articleid");

            migrationBuilder.CreateIndex(
                name: "IX_MyList_userid",
                table: "MyList",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "MyList");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
