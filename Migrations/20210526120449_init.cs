using Microsoft.EntityFrameworkCore.Migrations;

namespace ds3Wiki.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character_Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Influence = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Characteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HP = table.Column<int>(type: "int", nullable: false),
                    Received_money = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games_Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_game = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Improvement_Paths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gem_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advantages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disadvantage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Improvement_Paths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_Of_Magics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Character_characteristicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Of_Magics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Type_Of_Magics_Character_Characteristics_Character_characteristicId",
                        column: x => x.Character_characteristicId,
                        principalTable: "Character_Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bonfire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Game_InfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Games_Info_Game_InfoId",
                        column: x => x.Game_InfoId,
                        principalTable: "Games_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalysts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_of_catalyst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spell_Buff = table.Column<int>(type: "int", nullable: false),
                    Type_of_magicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalysts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalysts_Type_Of_Magics_Type_of_magicId",
                        column: x => x.Type_of_magicId,
                        principalTable: "Type_Of_Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Magics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_of_magicId = table.Column<int>(type: "int", nullable: false),
                    Concentration_costs = table.Column<int>(type: "int", nullable: false),
                    Occupied_cells = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Magics_Type_Of_Magics_Type_of_magicId",
                        column: x => x.Type_of_magicId,
                        principalTable: "Type_Of_Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Physical_protection = table.Column<int>(type: "int", nullable: false),
                    Fire_protection = table.Column<int>(type: "int", nullable: false),
                    Lightning_protection = table.Column<int>(type: "int", nullable: false),
                    Magic_protection = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armors_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Armors_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gem_Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Improvement_pathId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gem_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gem_Locations_Improvement_Paths_Improvement_pathId",
                        column: x => x.Improvement_pathId,
                        principalTable: "Improvement_Paths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gem_Locations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NPC_Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPC_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NPC_Locations_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NPC_Locations_Enemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NPC_Locations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Support_for_improvement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Character_characteristicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Character_Characteristics_Character_characteristicId",
                        column: x => x.Character_characteristicId,
                        principalTable: "Character_Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weapons_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale_Magics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MagicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale_Magics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Magics_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Magics_Magics_MagicId",
                        column: x => x.MagicId,
                        principalTable: "Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armors_CharacterId",
                table: "Armors",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Armors_LocationId",
                table: "Armors",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalysts_Type_of_magicId",
                table: "Catalysts",
                column: "Type_of_magicId");

            migrationBuilder.CreateIndex(
                name: "IX_Gem_Locations_Improvement_pathId",
                table: "Gem_Locations",
                column: "Improvement_pathId");

            migrationBuilder.CreateIndex(
                name: "IX_Gem_Locations_LocationId",
                table: "Gem_Locations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Game_InfoId",
                table: "Locations",
                column: "Game_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Magics_Type_of_magicId",
                table: "Magics",
                column: "Type_of_magicId");

            migrationBuilder.CreateIndex(
                name: "IX_NPC_Locations_CharacterId",
                table: "NPC_Locations",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_NPC_Locations_EnemyId",
                table: "NPC_Locations",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_NPC_Locations_LocationId",
                table: "NPC_Locations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_Magics_CharacterId",
                table: "Sale_Magics",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_Magics_MagicId",
                table: "Sale_Magics",
                column: "MagicId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Magics_Character_characteristicId",
                table: "Type_Of_Magics",
                column: "Character_characteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_Character_characteristicId",
                table: "Weapons",
                column: "Character_characteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_LocationId",
                table: "Weapons",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Catalysts");

            migrationBuilder.DropTable(
                name: "Gem_Locations");

            migrationBuilder.DropTable(
                name: "NPC_Locations");

            migrationBuilder.DropTable(
                name: "Sale_Magics");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Improvement_Paths");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Magics");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Type_Of_Magics");

            migrationBuilder.DropTable(
                name: "Games_Info");

            migrationBuilder.DropTable(
                name: "Character_Characteristics");
        }
    }
}
