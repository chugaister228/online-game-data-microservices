using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Skins.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWID()"),
                    RaceOfCharacter = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Rarity = table.Column<int>(type: "INTEGER", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWID()"),
                    KindOfAnimal = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CharacterID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Rarity = table.Column<int>(type: "INTEGER", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pets_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWID()"),
                    TypeOfWeapon = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CharacterID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Rarity = table.Column<int>(type: "INTEGER", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "ID", "Name", "RaceOfCharacter", "Rarity" },
                values: new object[,]
                {
                    { new Guid("07868e4b-4ca3-4ccd-a514-7a40c183b239"), "Ella", "et", 3 },
                    { new Guid("0ee808aa-ea32-4b51-9fb3-19886c91ca03"), "Chad", "quas", 0 },
                    { new Guid("14b54d9d-5f39-4db2-a7af-c116b0549def"), "Elijah", "quod", 2 },
                    { new Guid("1bda794e-1552-40e0-afb0-f64d924136cc"), "Jessica", "eius", 0 },
                    { new Guid("242acdbe-b839-46b7-8d37-fecdcac83ee3"), "Freddie", "enim", 2 },
                    { new Guid("3f143503-4f80-438b-8d02-4b9634b5e50d"), "Roosevelt", "ut", 1 },
                    { new Guid("43aea403-10ea-46bf-8a9a-fb90434f6460"), "Willis", "veritatis", 1 },
                    { new Guid("4547c345-8e5b-4c92-bce5-908e8d4cb984"), "Myra", "exercitationem", 2 },
                    { new Guid("5255c4e3-6244-4ae3-ad37-ec43043905bf"), "Garry", "voluptates", 0 },
                    { new Guid("5a423f94-6c6d-43ef-8ed6-0733002948f2"), "Joseph", "et", 5 },
                    { new Guid("5b281a24-6503-4650-aa56-bc4e235e2cb0"), "Jesse", "et", 3 },
                    { new Guid("675c5103-4f0a-4fc9-8fbc-2cf2b3680cf8"), "Lorene", "voluptatem", 4 },
                    { new Guid("6983e121-8efb-47cf-b63d-39364cd9cbdc"), "Krista", "exercitationem", 4 },
                    { new Guid("69db49c3-cbf7-4860-9cfb-1ad56b56fbdc"), "Terry", "sint", 1 },
                    { new Guid("6ffbe56d-897f-428b-a493-8c5335f08d17"), "Kelly", "corrupti", 0 },
                    { new Guid("7d5ccb14-9e76-4fb6-a242-f46c8b7cc871"), "Trevor", "necessitatibus", 2 },
                    { new Guid("7f0e7ba5-7635-451f-8de9-98f4937e0424"), "Nora", "ab", 2 },
                    { new Guid("828779aa-727f-495d-995d-287f6e47af25"), "Terence", "ratione", 0 },
                    { new Guid("84b5779e-012f-4a34-b992-c389e2d8864b"), "Juana", "id", 0 },
                    { new Guid("887100da-337f-4f17-b18a-a2065646c7b8"), "Josephine", "nisi", 5 },
                    { new Guid("9025bec3-2c90-40fd-9ce6-960347ad6a0f"), "Seth", "mollitia", 1 },
                    { new Guid("97814a50-1efa-4beb-8793-68f5c7969237"), "Antoinette", "eum", 4 },
                    { new Guid("bc853465-9558-4766-82d0-9831451d4dc4"), "Luz", "atque", 0 },
                    { new Guid("c1cea1ce-90fd-446a-b89a-0d240c697d0a"), "Juan", "harum", 2 },
                    { new Guid("c31f5463-3c4e-4e17-a6b2-6c2dc3314e0c"), "Alicia", "quam", 3 },
                    { new Guid("c5ee9577-66c4-4862-ae59-b0af6c988a24"), "Brittany", "vel", 1 },
                    { new Guid("d5db1a45-19d2-4b4c-8e1d-14e4b95ce70d"), "Hilda", "nisi", 3 },
                    { new Guid("e9b4541a-1f25-4a3e-b678-d56c1bf808c5"), "Jean", "et", 5 },
                    { new Guid("f6fcc26b-4a0f-4cc1-bf02-63336aed6b55"), "Martin", "asperiores", 3 },
                    { new Guid("f93d8370-8e7c-42e0-9d2f-33e01412f05d"), "Brenda", "quia", 3 }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "ID", "CharacterID", "KindOfAnimal", "Name", "Rarity" },
                values: new object[,]
                {
                    { new Guid("12fb7be2-3e43-43c7-b17f-616177d6a4a3"), new Guid("6ffbe56d-897f-428b-a493-8c5335f08d17"), "tenetur", "Darryl", 0 },
                    { new Guid("1784922e-6b56-49d6-aff8-0caac71c5c01"), new Guid("14b54d9d-5f39-4db2-a7af-c116b0549def"), "illum", "Bonnie", 2 },
                    { new Guid("1d0707cc-e340-419e-929d-b38d84bede04"), new Guid("1bda794e-1552-40e0-afb0-f64d924136cc"), "ut", "Christine", 2 },
                    { new Guid("23673694-2010-48f9-b016-1013a5e0e5d0"), new Guid("bc853465-9558-4766-82d0-9831451d4dc4"), "nesciunt", "Vicky", 4 },
                    { new Guid("3ba70ea6-d4e2-4a99-94ec-0d058aaebac4"), new Guid("828779aa-727f-495d-995d-287f6e47af25"), "qui", "Cody", 1 },
                    { new Guid("3dd749a9-d228-4783-a711-fa4c43fee43b"), new Guid("43aea403-10ea-46bf-8a9a-fb90434f6460"), "non", "Alfonso", 2 },
                    { new Guid("45387e68-40b2-4367-bbcb-a0bb17aa3206"), new Guid("9025bec3-2c90-40fd-9ce6-960347ad6a0f"), "natus", "Hugh", 2 },
                    { new Guid("488a0a76-4468-44ce-987d-e4c7570e227d"), new Guid("c31f5463-3c4e-4e17-a6b2-6c2dc3314e0c"), "neque", "Jon", 2 },
                    { new Guid("5041d4b8-0674-4879-9ade-a568430c68ba"), new Guid("07868e4b-4ca3-4ccd-a514-7a40c183b239"), "ea", "Vivian", 1 },
                    { new Guid("5b59bc16-7586-4985-9b2d-2667691bb127"), new Guid("e9b4541a-1f25-4a3e-b678-d56c1bf808c5"), "omnis", "Rhonda", 1 },
                    { new Guid("5d0f4bde-2af7-4705-94cf-abf9198325e5"), new Guid("675c5103-4f0a-4fc9-8fbc-2cf2b3680cf8"), "voluptatem", "Marcia", 0 },
                    { new Guid("60b797ae-8024-44a7-92ed-87bf0894c330"), new Guid("5255c4e3-6244-4ae3-ad37-ec43043905bf"), "voluptatem", "Marcella", 0 },
                    { new Guid("63692750-dda7-4271-afe0-dd60aea80189"), new Guid("84b5779e-012f-4a34-b992-c389e2d8864b"), "dicta", "Carrie", 4 },
                    { new Guid("67de6ef9-6504-44cd-aec9-784d6716c360"), new Guid("f6fcc26b-4a0f-4cc1-bf02-63336aed6b55"), "blanditiis", "Steven", 5 },
                    { new Guid("842768a3-a661-480a-8444-bd292dacee9f"), new Guid("5b281a24-6503-4650-aa56-bc4e235e2cb0"), "autem", "Mario", 2 },
                    { new Guid("85da6d9b-9b8a-452d-86d3-f30e0b723f4d"), new Guid("7f0e7ba5-7635-451f-8de9-98f4937e0424"), "odit", "Hugo", 1 },
                    { new Guid("8659367e-3d51-40f5-bb45-78b6fb287b15"), new Guid("d5db1a45-19d2-4b4c-8e1d-14e4b95ce70d"), "voluptatibus", "Shirley", 2 },
                    { new Guid("8d202163-b5d1-49b9-a52c-1d0b95d700e8"), new Guid("97814a50-1efa-4beb-8793-68f5c7969237"), "officia", "Sylvia", 4 },
                    { new Guid("92d8261a-6e4b-47bf-90ab-0f14dc3cb542"), new Guid("f93d8370-8e7c-42e0-9d2f-33e01412f05d"), "nisi", "Joy", 5 },
                    { new Guid("9722e064-d2ff-4264-82ec-501bd65a6ec0"), new Guid("7d5ccb14-9e76-4fb6-a242-f46c8b7cc871"), "molestias", "John", 2 },
                    { new Guid("a3740a30-b4d6-4817-a420-09222ddb70c5"), new Guid("242acdbe-b839-46b7-8d37-fecdcac83ee3"), "excepturi", "Heidi", 0 },
                    { new Guid("a47be091-9b8f-4d57-939b-a3003ae55cae"), new Guid("6983e121-8efb-47cf-b63d-39364cd9cbdc"), "consequatur", "Wallace", 5 },
                    { new Guid("ada9e2f8-e854-4200-94ab-fe176736e99b"), new Guid("69db49c3-cbf7-4860-9cfb-1ad56b56fbdc"), "voluptate", "Damon", 3 },
                    { new Guid("aef4ae0c-893b-4d9a-b372-1ed8b5ab9fd6"), new Guid("0ee808aa-ea32-4b51-9fb3-19886c91ca03"), "qui", "Gilberto", 2 },
                    { new Guid("b1e9237a-e06f-4399-b771-c22778f5f86f"), new Guid("3f143503-4f80-438b-8d02-4b9634b5e50d"), "eius", "Sonja", 3 },
                    { new Guid("e7321fab-be9d-4488-9d21-373f669f8022"), new Guid("887100da-337f-4f17-b18a-a2065646c7b8"), "voluptas", "Brett", 0 },
                    { new Guid("e9edc8c9-efbd-4f14-8f59-361a97e46a69"), new Guid("c5ee9577-66c4-4862-ae59-b0af6c988a24"), "et", "Carol", 5 },
                    { new Guid("ea1383b7-61bf-46e6-a7a2-a2a24b7c6559"), new Guid("c1cea1ce-90fd-446a-b89a-0d240c697d0a"), "unde", "Yvette", 0 },
                    { new Guid("f7e8d1b8-b35c-4ca4-abef-628dd80bbfca"), new Guid("5a423f94-6c6d-43ef-8ed6-0733002948f2"), "eius", "Clinton", 0 },
                    { new Guid("ffbb8486-f249-4cc5-b374-493c6d80c7aa"), new Guid("4547c345-8e5b-4c92-bce5-908e8d4cb984"), "rerum", "Beverly", 1 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "ID", "CharacterID", "Name", "Rarity", "TypeOfWeapon" },
                values: new object[,]
                {
                    { new Guid("08d2dd3f-5b69-4080-835e-833ce7fdbc8a"), new Guid("07868e4b-4ca3-4ccd-a514-7a40c183b239"), "Wallace", 2, "earum" },
                    { new Guid("10a2dd77-d409-455e-bbfd-abfa1a1360c8"), new Guid("675c5103-4f0a-4fc9-8fbc-2cf2b3680cf8"), "Gail", 5, "minus" },
                    { new Guid("2947b70b-1f3b-4e73-9a11-16299df6fa31"), new Guid("5255c4e3-6244-4ae3-ad37-ec43043905bf"), "Kim", 3, "et" },
                    { new Guid("29c7b7a8-9813-4976-b7d1-02387d10bce4"), new Guid("1bda794e-1552-40e0-afb0-f64d924136cc"), "Cedric", 1, "quia" },
                    { new Guid("2a54ae38-6729-4456-9efc-9cd83839033a"), new Guid("97814a50-1efa-4beb-8793-68f5c7969237"), "Steven", 5, "aliquid" },
                    { new Guid("33f48c89-c7d4-4706-8ccb-7ad97c5fbd44"), new Guid("bc853465-9558-4766-82d0-9831451d4dc4"), "Rick", 4, "aut" },
                    { new Guid("38fc261d-5d4e-4334-bd65-044a34883820"), new Guid("69db49c3-cbf7-4860-9cfb-1ad56b56fbdc"), "Patrick", 2, "omnis" },
                    { new Guid("4a964ded-735e-4ca5-9061-68bf8f003b1d"), new Guid("0ee808aa-ea32-4b51-9fb3-19886c91ca03"), "Alicia", 2, "est" },
                    { new Guid("4b02ff00-d83f-4ef1-9131-12f81c936f09"), new Guid("7f0e7ba5-7635-451f-8de9-98f4937e0424"), "Toni", 4, "accusantium" },
                    { new Guid("54be799c-971a-4781-8e5a-943d8be987f0"), new Guid("c5ee9577-66c4-4862-ae59-b0af6c988a24"), "Sonia", 2, "voluptatem" },
                    { new Guid("57f68038-b464-43b0-82ac-9c0997253592"), new Guid("887100da-337f-4f17-b18a-a2065646c7b8"), "Jeanne", 4, "soluta" },
                    { new Guid("66baf759-b6cd-4217-9bae-cb5fb0d693b1"), new Guid("4547c345-8e5b-4c92-bce5-908e8d4cb984"), "Meredith", 1, "maiores" },
                    { new Guid("6c3214aa-a96e-4c9b-9c75-9c7e7e6a14be"), new Guid("84b5779e-012f-4a34-b992-c389e2d8864b"), "Robin", 1, "nihil" },
                    { new Guid("6ce732d6-54ec-434d-b7a2-6299a99ee57d"), new Guid("242acdbe-b839-46b7-8d37-fecdcac83ee3"), "Devin", 5, "quaerat" },
                    { new Guid("7b87762d-1122-4a53-9055-f5f39a6ec1fe"), new Guid("f93d8370-8e7c-42e0-9d2f-33e01412f05d"), "Angel", 3, "et" },
                    { new Guid("81cb8949-1f4e-485b-992c-5b861cbe4e95"), new Guid("14b54d9d-5f39-4db2-a7af-c116b0549def"), "Brent", 4, "earum" },
                    { new Guid("98ddb1f8-cc43-431d-b5ea-fed15876ba6f"), new Guid("6ffbe56d-897f-428b-a493-8c5335f08d17"), "Rene", 3, "perferendis" },
                    { new Guid("a6e8e985-20bd-4281-9214-9cafdfd0f784"), new Guid("3f143503-4f80-438b-8d02-4b9634b5e50d"), "Gregg", 1, "quisquam" },
                    { new Guid("a736f6a1-021a-401f-9f39-081777720619"), new Guid("c31f5463-3c4e-4e17-a6b2-6c2dc3314e0c"), "Christie", 5, "ut" },
                    { new Guid("a748f7fb-18c3-4d2e-aecf-1af09cb5a963"), new Guid("f6fcc26b-4a0f-4cc1-bf02-63336aed6b55"), "Douglas", 5, "non" },
                    { new Guid("ab640046-e41d-4217-be61-67f03cd25e9f"), new Guid("d5db1a45-19d2-4b4c-8e1d-14e4b95ce70d"), "Elizabeth", 0, "voluptatem" },
                    { new Guid("add716dc-4527-4a41-aa48-1bb91bbe0592"), new Guid("43aea403-10ea-46bf-8a9a-fb90434f6460"), "Alexandra", 4, "voluptatem" },
                    { new Guid("ae6eeff7-77d7-4d51-add6-d8183f902800"), new Guid("6983e121-8efb-47cf-b63d-39364cd9cbdc"), "Cathy", 5, "dolor" },
                    { new Guid("ba296e46-1915-44e9-84bf-949d23eef9da"), new Guid("828779aa-727f-495d-995d-287f6e47af25"), "Bernice", 4, "nesciunt" },
                    { new Guid("bac7e120-42da-45e8-b8a4-8be879d425d4"), new Guid("9025bec3-2c90-40fd-9ce6-960347ad6a0f"), "Irma", 1, "dolores" },
                    { new Guid("c0c37481-32be-4373-84d9-4e4573f2b0cb"), new Guid("c1cea1ce-90fd-446a-b89a-0d240c697d0a"), "Abel", 0, "tenetur" },
                    { new Guid("e46dc932-00ef-4950-a3b7-0793f8aebd59"), new Guid("5b281a24-6503-4650-aa56-bc4e235e2cb0"), "Nichole", 5, "voluptatum" },
                    { new Guid("ef8b6615-76d5-4bcf-9276-c9f0bb17a4cd"), new Guid("7d5ccb14-9e76-4fb6-a242-f46c8b7cc871"), "Tracy", 4, "et" },
                    { new Guid("f7e6ef38-360f-42ab-b10a-b93a21332f0b"), new Guid("5a423f94-6c6d-43ef-8ed6-0733002948f2"), "Norman", 2, "ab" },
                    { new Guid("fa597a8c-9e55-4d2c-b612-207eeb2fc71a"), new Guid("e9b4541a-1f25-4a3e-b678-d56c1bf808c5"), "Bert", 5, "nesciunt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CharacterID",
                table: "Pets",
                column: "CharacterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterID",
                table: "Weapons",
                column: "CharacterID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
