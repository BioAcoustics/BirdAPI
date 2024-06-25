using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdAPI.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    small = table.Column<string>(type: "TEXT", nullable: false),
                    med = table.Column<string>(type: "TEXT", nullable: false),
                    large = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recordings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Duration = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    small = table.Column<string>(type: "TEXT", nullable: false),
                    med = table.Column<string>(type: "TEXT", nullable: false),
                    large = table.Column<string>(type: "TEXT", nullable: false),
                    full = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sono", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecordingId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Label_Recordings_RecordingId",
                        column: x => x.RecordingId,
                        principalTable: "Recordings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XenoCantoEntries",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    gen = table.Column<string>(type: "TEXT", nullable: true),
                    sp = table.Column<string>(type: "TEXT", nullable: true),
                    ssp = table.Column<string>(type: "TEXT", nullable: true),
                    group = table.Column<string>(type: "TEXT", nullable: true),
                    en = table.Column<string>(type: "TEXT", nullable: true),
                    rec = table.Column<string>(type: "TEXT", nullable: true),
                    cnt = table.Column<string>(type: "TEXT", nullable: true),
                    lat = table.Column<string>(type: "TEXT", nullable: true),
                    loc = table.Column<string>(type: "TEXT", nullable: true),
                    lng = table.Column<string>(type: "TEXT", nullable: true),
                    alt = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    sex = table.Column<string>(type: "TEXT", nullable: true),
                    stage = table.Column<string>(type: "TEXT", nullable: true),
                    method = table.Column<string>(type: "TEXT", nullable: true),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    file = table.Column<string>(type: "TEXT", nullable: true),
                    fileName = table.Column<string>(type: "TEXT", nullable: true),
                    SonoId = table.Column<int>(type: "INTEGER", nullable: false),
                    OsciId = table.Column<int>(type: "INTEGER", nullable: false),
                    lic = table.Column<string>(type: "TEXT", nullable: true),
                    q = table.Column<string>(type: "TEXT", nullable: false),
                    length = table.Column<string>(type: "TEXT", nullable: true),
                    time = table.Column<string>(type: "TEXT", nullable: true),
                    date = table.Column<string>(type: "TEXT", nullable: true),
                    uploaded = table.Column<string>(type: "TEXT", nullable: true),
                    also = table.Column<string>(type: "TEXT", nullable: true),
                    rmk = table.Column<string>(type: "TEXT", nullable: true),
                    birdSeen = table.Column<string>(type: "TEXT", nullable: true),
                    animalSeen = table.Column<string>(type: "TEXT", nullable: true),
                    playbackUsed = table.Column<string>(type: "TEXT", nullable: true),
                    temp = table.Column<string>(type: "TEXT", nullable: true),
                    regnr = table.Column<string>(type: "TEXT", nullable: true),
                    auto = table.Column<string>(type: "TEXT", nullable: true),
                    dvc = table.Column<string>(type: "TEXT", nullable: true),
                    mic = table.Column<string>(type: "TEXT", nullable: true),
                    smp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XenoCantoEntries", x => x.id);
                    table.ForeignKey(
                        name: "FK_XenoCantoEntries_Osci_OsciId",
                        column: x => x.OsciId,
                        principalTable: "Osci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XenoCantoEntries_Sono_SonoId",
                        column: x => x.SonoId,
                        principalTable: "Sono",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Label_RecordingId",
                table: "Label",
                column: "RecordingId");

            migrationBuilder.CreateIndex(
                name: "IX_XenoCantoEntries_OsciId",
                table: "XenoCantoEntries",
                column: "OsciId");

            migrationBuilder.CreateIndex(
                name: "IX_XenoCantoEntries_SonoId",
                table: "XenoCantoEntries",
                column: "SonoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "XenoCantoEntries");

            migrationBuilder.DropTable(
                name: "Recordings");

            migrationBuilder.DropTable(
                name: "Osci");

            migrationBuilder.DropTable(
                name: "Sono");
        }
    }
}
