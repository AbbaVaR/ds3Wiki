using Microsoft.EntityFrameworkCore.Migrations;

namespace ds3Wiki.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Magic_protection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalysts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_of_catalyst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spell_Buff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalysts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gem_Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gem_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NPC_Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPC_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale_Magics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale_Magics", x => x.Id);
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
                    Support_for_improvement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Improvement_Paths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gem_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advantages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disadvantage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gem_LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Improvement_Paths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Improvement_Paths_Gem_Locations_Gem_LocationId",
                        column: x => x.Gem_LocationId,
                        principalTable: "Gem_Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Received_money = table.Column<int>(type: "int", nullable: false),
                    NPC_locationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemies_NPC_Locations_NPC_locationId",
                        column: x => x.NPC_locationId,
                        principalTable: "NPC_Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Magics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concentration_costs = table.Column<int>(type: "int", nullable: false),
                    Occupied_cells = table.Column<int>(type: "int", nullable: false),
                    Sale_magicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Magics_Sale_Magics_Sale_magicId",
                        column: x => x.Sale_magicId,
                        principalTable: "Sale_Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArmorId = table.Column<int>(type: "int", nullable: true),
                    NPC_locationId = table.Column<int>(type: "int", nullable: true),
                    Sale_itemId = table.Column<int>(type: "int", nullable: true),
                    Sale_magicId = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_NPC_Locations_NPC_locationId",
                        column: x => x.NPC_locationId,
                        principalTable: "NPC_Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Sale_Items_Sale_itemId",
                        column: x => x.Sale_itemId,
                        principalTable: "Sale_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Sale_Magics_Sale_magicId",
                        column: x => x.Sale_magicId,
                        principalTable: "Sale_Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bonfire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArmorId = table.Column<int>(type: "int", nullable: true),
                    Gem_LocationId = table.Column<int>(type: "int", nullable: true),
                    NPC_locationId = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Gem_Locations_Gem_LocationId",
                        column: x => x.Gem_LocationId,
                        principalTable: "Gem_Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_NPC_Locations_NPC_locationId",
                        column: x => x.NPC_locationId,
                        principalTable: "NPC_Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Negative_Effects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negative_Effects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Negative_Effects_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Type_Of_Magics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalystId = table.Column<int>(type: "int", nullable: true),
                    MagicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Of_Magics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Type_Of_Magics_Catalysts_CatalystId",
                        column: x => x.CatalystId,
                        principalTable: "Catalysts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Type_Of_Magics_Magics_MagicId",
                        column: x => x.MagicId,
                        principalTable: "Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games_Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_game = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games_Info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Info_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consumable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Use_for = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Negative_effectId = table.Column<int>(type: "int", nullable: true),
                    Sale_itemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Negative_Effects_Negative_effectId",
                        column: x => x.Negative_effectId,
                        principalTable: "Negative_Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Sale_Items_Sale_itemId",
                        column: x => x.Sale_itemId,
                        principalTable: "Sale_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Character_Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Influence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_of_magicId = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Characteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Characteristics_Type_Of_Magics_Type_of_magicId",
                        column: x => x.Type_of_magicId,
                        principalTable: "Type_Of_Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Characteristics_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_Characteristics_Type_of_magicId",
                table: "Character_Characteristics",
                column: "Type_of_magicId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Characteristics_WeaponId",
                table: "Character_Characteristics",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ArmorId",
                table: "Characters",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_NPC_locationId",
                table: "Characters",
                column: "NPC_locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Sale_itemId",
                table: "Characters",
                column: "Sale_itemId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Sale_magicId",
                table: "Characters",
                column: "Sale_magicId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WeaponId",
                table: "Characters",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_NPC_locationId",
                table: "Enemies",
                column: "NPC_locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Info_LocationId",
                table: "Games_Info",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Improvement_Paths_Gem_LocationId",
                table: "Improvement_Paths",
                column: "Gem_LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Negative_effectId",
                table: "Items",
                column: "Negative_effectId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Sale_itemId",
                table: "Items",
                column: "Sale_itemId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ArmorId",
                table: "Locations",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Gem_LocationId",
                table: "Locations",
                column: "Gem_LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_NPC_locationId",
                table: "Locations",
                column: "NPC_locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_WeaponId",
                table: "Locations",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Magics_Sale_magicId",
                table: "Magics",
                column: "Sale_magicId");

            migrationBuilder.CreateIndex(
                name: "IX_Negative_Effects_WeaponId",
                table: "Negative_Effects",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Magics_CatalystId",
                table: "Type_Of_Magics",
                column: "CatalystId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Magics_MagicId",
                table: "Type_Of_Magics",
                column: "MagicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character_Characteristics");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Games_Info");

            migrationBuilder.DropTable(
                name: "Improvement_Paths");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Type_Of_Magics");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Negative_Effects");

            migrationBuilder.DropTable(
                name: "Sale_Items");

            migrationBuilder.DropTable(
                name: "Catalysts");

            migrationBuilder.DropTable(
                name: "Magics");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Gem_Locations");

            migrationBuilder.DropTable(
                name: "NPC_Locations");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Sale_Magics");
        }
    }
}
