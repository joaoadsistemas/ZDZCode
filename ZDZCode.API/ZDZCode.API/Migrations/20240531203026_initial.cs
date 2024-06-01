using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZDZCode.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgsUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DepartureDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => new { x.HotelId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_Rents_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Description", "ImgsUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("8661a44d-78ec-495a-a204-1fa5cb69b1c6"), "Perca-se nos jardins eternos do Eternal Garden Retreat. Com sua atmosfera serena e paisagens exuberantes, este retiro é um refúgio para a alma em busca de paz e tranquilidade.", "[\"https://images.pexels.com/photos/1134176/pexels-photo-1134176.jpeg?auto=compress\\u0026cs=tinysrgb\\u0026w=600\",\"https://images.pexels.com/photos/2096983/pexels-photo-2096983.jpeg?auto=compress\\u0026cs=tinysrgb\\u0026w=600\"]", "Eternal Garden Retreat" },
                    { new Guid("a4b30340-ef8a-4209-916e-e1f9f7084c3b"), "Descubra o luxo e o conforto no Golden Sands Resort. Com praias douradas e instalações de primeira classe, este resort oferece uma experiência inesquecível para os viajantes exigentes.", "[\"https://images.pexels.com/photos/594077/pexels-photo-594077.jpeg?auto=compress\\u0026cs=tinysrgb\\u0026w=600\",\"https://images.pexels.com/photos/1838554/pexels-photo-1838554.jpeg?auto=compress\\u0026cs=tinysrgb\\u0026w=600\"]", "Golden Sands Resort" },
                    { new Guid("b50e3174-2aa7-465d-a5ca-45219d85e543"), "Entre na mística e explore a beleza natural do Mystic Mountain Lodge. Situado entre as majestosas montanhas, este lodge oferece uma experiência única em harmonia com a natureza.", "[\"https://images.pexels.com/photos/338504/pexels-photo-338504.jpeg?auto=compress\\u0026cs=tinysrgb\\u0026w=600\",\"https://images.pexels.com/photos/2034335/pexels-photo-2034335.jpeg?auto=compress\\u0026cs=tinysrgb\\u0026w=600\"]", "Mystic Mountain Lodge" },
                    { new Guid("b9f5a8b7-719c-4c25-bb6f-89fb34f63376"), "Desfrute de um oásis tropical no Sunset Paradise Resort. Com vistas deslumbrantes para o mar e praias de areia branca, este resort oferece a escapada perfeita para relaxamento e diversão.", "[\"https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?auto=compress\\u0026cs=tinysrgb\\u0026w=600\",\"https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg?auto=compress\\u0026cs=tinysrgb\\u0026w=600\"]", "Sunset Paradise Resort" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CPF", "Email", "LastName", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("165370e7-dddd-4caa-90e0-5945d919e814"), "987.654.321-00", "maria@example.com", "Santos", "Maria", "987654321" },
                    { new Guid("27bc7dd8-d17c-4078-a5e1-d981e6aa777f"), "111.222.333-00", "carlos@example.com", "Souza", "Carlos", "111222333" },
                    { new Guid("3fa773f2-cfcf-4ff6-b9f8-7b171e902499"), "555.666.777-00", "fernando@example.com", "Martins", "Fernando", "555666777" },
                    { new Guid("4957ed00-76f0-413c-bfdb-1313a2d7a60f"), "123.456.789-00", "joao@example.com", "Silva", "João", "123456789" },
                    { new Guid("59349c4d-6dab-43d3-a061-ed8491434616"), "999.000.111-00", "gabriel@example.com", "Almeida", "Gabriel", "999000111" },
                    { new Guid("8cba7beb-e86f-4c1a-baa7-586c4d3ce102"), "888.999.000-00", "mariana@example.com", "Pereira", "Mariana", "888999000" },
                    { new Guid("9292ef7a-97f1-4636-86a2-181b3701787c"), "222.333.444-00", "laura@example.com", "Costa", "Laura", "222333444" },
                    { new Guid("af5f8d39-c972-4e03-bfdb-0d6a8bfe2e70"), "123.123.123-00", "juliana@example.com", "Lima", "Juliana", "123123123" },
                    { new Guid("b747d5f3-2ad6-4ee6-a108-ec8619cb7edc"), "777.888.999-00", "pedro@example.com", "Rodrigues", "Pedro", "777888999" },
                    { new Guid("d17124d0-1c83-4618-aed9-a2c545ef23c1"), "444.555.666-00", "ana@example.com", "Oliveira", "Ana", "444555666" }
                });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "HotelId", "PersonId", "DepartureDate", "EntryDate" },
                values: new object[,]
                {
                    { new Guid("8661a44d-78ec-495a-a204-1fa5cb69b1c6"), new Guid("27bc7dd8-d17c-4078-a5e1-d981e6aa777f"), new DateTimeOffset(new DateTime(2024, 6, 6, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6142), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 2, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("8661a44d-78ec-495a-a204-1fa5cb69b1c6"), new Guid("3fa773f2-cfcf-4ff6-b9f8-7b171e902499"), new DateTimeOffset(new DateTime(2024, 6, 12, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 7, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a4b30340-ef8a-4209-916e-e1f9f7084c3b"), new Guid("8cba7beb-e86f-4c1a-baa7-586c4d3ce102"), new DateTimeOffset(new DateTime(2024, 6, 13, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6151), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 8, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6151), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a4b30340-ef8a-4209-916e-e1f9f7084c3b"), new Guid("d17124d0-1c83-4618-aed9-a2c545ef23c1"), new DateTimeOffset(new DateTime(2024, 6, 7, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6144), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 1, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6143), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b50e3174-2aa7-465d-a5ca-45219d85e543"), new Guid("165370e7-dddd-4caa-90e0-5945d919e814"), new DateTimeOffset(new DateTime(2024, 6, 8, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 3, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6139), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b50e3174-2aa7-465d-a5ca-45219d85e543"), new Guid("9292ef7a-97f1-4636-86a2-181b3701787c"), new DateTimeOffset(new DateTime(2024, 6, 11, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6148), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 6, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6147), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b50e3174-2aa7-465d-a5ca-45219d85e543"), new Guid("af5f8d39-c972-4e03-bfdb-0d6a8bfe2e70"), new DateTimeOffset(new DateTime(2024, 6, 14, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6155), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 9, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6154), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b9f5a8b7-719c-4c25-bb6f-89fb34f63376"), new Guid("4957ed00-76f0-413c-bfdb-1313a2d7a60f"), new DateTimeOffset(new DateTime(2024, 6, 5, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6118), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 5, 31, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6116), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b9f5a8b7-719c-4c25-bb6f-89fb34f63376"), new Guid("59349c4d-6dab-43d3-a061-ed8491434616"), new DateTimeOffset(new DateTime(2024, 6, 10, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6153), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 5, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6152), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b9f5a8b7-719c-4c25-bb6f-89fb34f63376"), new Guid("b747d5f3-2ad6-4ee6-a108-ec8619cb7edc"), new DateTimeOffset(new DateTime(2024, 6, 9, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6146), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 4, 20, 30, 25, 573, DateTimeKind.Unspecified).AddTicks(6145), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_PersonId",
                table: "Rents",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
