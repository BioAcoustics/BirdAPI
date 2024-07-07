using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recordings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Duration = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XenoCantoEntries",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    gen = table.Column<string>(type: "text", nullable: true),
                    sp = table.Column<string>(type: "text", nullable: true),
                    ssp = table.Column<string>(type: "text", nullable: true),
                    group = table.Column<string>(type: "text", nullable: true),
                    en = table.Column<string>(type: "text", nullable: true),
                    rec = table.Column<string>(type: "text", nullable: true),
                    cnt = table.Column<string>(type: "text", nullable: true),
                    lat = table.Column<string>(type: "text", nullable: true),
                    loc = table.Column<string>(type: "text", nullable: true),
                    lng = table.Column<string>(type: "text", nullable: true),
                    alt = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    sex = table.Column<string>(type: "text", nullable: true),
                    stage = table.Column<string>(type: "text", nullable: true),
                    method = table.Column<string>(type: "text", nullable: true),
                    url = table.Column<string>(type: "text", nullable: true),
                    file = table.Column<string>(type: "text", nullable: true),
                    fileName = table.Column<string>(type: "text", nullable: true),
                    lic = table.Column<string>(type: "text", nullable: true),
                    q = table.Column<string>(type: "text", nullable: false),
                    length = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<string>(type: "text", nullable: true),
                    uploaded = table.Column<string>(type: "text", nullable: true),
                    also = table.Column<List<string>>(type: "text[]", nullable: true),
                    rmk = table.Column<string>(type: "text", nullable: true),
                    birdSeen = table.Column<string>(type: "text", nullable: true),
                    animalSeen = table.Column<string>(type: "text", nullable: true),
                    playbackUsed = table.Column<string>(type: "text", nullable: true),
                    temp = table.Column<string>(type: "text", nullable: true),
                    regnr = table.Column<string>(type: "text", nullable: true),
                    auto = table.Column<string>(type: "text", nullable: true),
                    dvc = table.Column<string>(type: "text", nullable: true),
                    mic = table.Column<string>(type: "text", nullable: true),
                    smp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XenoCantoEntries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordingId = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "Oscis",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    small = table.Column<string>(type: "text", nullable: false),
                    med = table.Column<string>(type: "text", nullable: false),
                    large = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oscis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oscis_XenoCantoEntries_Id",
                        column: x => x.Id,
                        principalTable: "XenoCantoEntries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sonos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    small = table.Column<string>(type: "text", nullable: false),
                    med = table.Column<string>(type: "text", nullable: false),
                    large = table.Column<string>(type: "text", nullable: false),
                    full = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sonos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sonos_XenoCantoEntries_Id",
                        column: x => x.Id,
                        principalTable: "XenoCantoEntries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Label_RecordingId",
                table: "Label",
                column: "RecordingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Oscis");

            migrationBuilder.DropTable(
                name: "Sonos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Recordings");

            migrationBuilder.DropTable(
                name: "XenoCantoEntries");
        }
    }
}
