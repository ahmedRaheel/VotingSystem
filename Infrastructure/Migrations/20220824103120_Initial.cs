using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateCategoryType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartySymbol",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartySymbol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    GenderType = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PartySymbolId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Party", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Party_PartySymbol_PartySymbolId",
                        column: x => x.PartySymbolId,
                        principalTable: "PartySymbol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoterContact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoterId = table.Column<long>(type: "bigint", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoterContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoterContact_Voter_VoterId",
                        column: x => x.VoterId,
                        principalTable: "Voter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    GenderType = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PartyId = table.Column<long>(type: "bigint", nullable: false),
                    CandidateCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidate_CandidateCategory_CandidateCategoryId",
                        column: x => x.CandidateCategoryId,
                        principalTable: "CandidateCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidate_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateContact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondidateId = table.Column<long>(type: "bigint", nullable: false),
                    CandidateId = table.Column<long>(type: "bigint", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateContact_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteCast",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<long>(type: "bigint", nullable: false),
                    VoterId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteCast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteCast_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoteCast_Voter_VoterId",
                        column: x => x.VoterId,
                        principalTable: "Voter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CandidateCategoryId",
                table: "Candidate",
                column: "CandidateCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_PartyId",
                table: "Candidate",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateContact_CandidateId",
                table: "CandidateContact",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Party_PartySymbolId",
                table: "Party",
                column: "PartySymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteCast_CandidateId",
                table: "VoteCast",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteCast_VoterId",
                table: "VoteCast",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_VoterContact_VoterId",
                table: "VoterContact",
                column: "VoterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateContact");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "VoteCast");

            migrationBuilder.DropTable(
                name: "VoterContact");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Voter");

            migrationBuilder.DropTable(
                name: "CandidateCategory");

            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.DropTable(
                name: "PartySymbol");
        }
    }
}
