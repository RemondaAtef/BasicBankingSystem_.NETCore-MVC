using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Basic_Banking_System.Migrations
{
    public partial class bank1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Account_Num = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Current_Balance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Account_Num);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Senderid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiverid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Account_Num", "Current_Balance", "Email", "Name" },
                values: new object[,]
                {
                    { "1258-6943-5764-12384", "1234$", "Tom@gmail.com", "Tom" },
                    { "4867-2134-6458-4796", "4590$", "Jena@gmail.com", "Jena" },
                    { "9745-1463-4795-1423", "487$", "Seray@gmail.com", "Seray" },
                    { "7436-1965-4567-2497", "500$", "Jerry@gmail.com", "Jerry" },
                    { "7894-5369-4126-7894", "15$", "Dina@gmail.com", "Dina" },
                    { "4897-1235-4795-6879", "800$", "Novier@gmail.com", "Novier" },
                    { "7842-3694-1287-9465", "9870$", "Nevya@gmail.com", "Nevya" },
                    { "9473-1658-4239-7458", "8700$", "Nehal@gmail.com", "Nehal" },
                    { "2436-8756-4123-4891", "6743200$", "Mona@gmail.com", "Mona" },
                    { "1297-5304-7890-1435", "970$", "Sally@gmail.com", "Sally" },
                    { "8402-9413-78912-1436", "5460$", "Yasin@gmail.com", "Yasin" },
                    { "2049-4503-7942-8576", "600$", "Ruchir@gmail.com", "Ruchir" },
                    { "8730-4591-2576-3971", "75600$", "Preetha@gmail.com", "Preetha" },
                    { "4975-2364-7941-0367", "400$", "Roy@gmail.com", "Roy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "History");
        }
    }
}
