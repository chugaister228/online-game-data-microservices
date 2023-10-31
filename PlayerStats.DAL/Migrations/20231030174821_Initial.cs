using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlayerStats.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWID()"),
                    Username = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Wins = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalGamesPlayed = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWID()"),
                    Friendname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PlayerID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Friends_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWID()"),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    PlayerID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Violations_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "Rating", "TotalGamesPlayed", "Username", "Wins" },
                values: new object[,]
                {
                    { new Guid("06fe26a4-47d4-4628-a5dc-c18d1f15b0d9"), 3365, 665, "Jim_Ritchie24", 405 },
                    { new Guid("0783bd61-1e52-46f2-88f0-4e9bf6f6a88b"), 4942, 672, "Orlando.Hand", 260 },
                    { new Guid("09ee2357-74bc-4cd9-8bbd-4863198d9da7"), 392, 746, "Judy.Lemke", 452 },
                    { new Guid("0f03d9f6-7e0f-4135-8c21-9a7e4451f965"), 652, 196, "Marcella.Roob", 37 },
                    { new Guid("10836ada-4dcc-443a-b0c9-5d3d8aa9d57a"), 1320, 119, "Debbie28", 129 },
                    { new Guid("2371eb0e-2dc0-4190-aca2-b5b51b7a1585"), 4631, 333, "Geraldine_Zboncak", 79 },
                    { new Guid("2e488102-7e53-435d-978f-d10a1fa870aa"), 3063, 142, "Jan.Weimann80", 463 },
                    { new Guid("308567d4-5ff1-4ee5-a762-d06d3b36e3d7"), 1582, 659, "Mindy.Shanahan23", 217 },
                    { new Guid("334962bb-5d84-4748-bbae-ea30b4420e12"), 1153, 596, "Gerald_Swift", 480 },
                    { new Guid("354a7e14-f789-4fde-ba1b-ced25965e92d"), 372, 397, "Yvonne_Grant94", 392 },
                    { new Guid("41aa18d8-5bcf-4d7f-9ea1-6126033e17fc"), 2761, 241, "Ernest_Runte", 211 },
                    { new Guid("47240f49-8838-4b37-879b-4c7fd060c5bc"), 2500, 635, "Joel82", 171 },
                    { new Guid("51add663-9d4d-4331-b9d2-cdcb87632548"), 680, 961, "Martha_Cremin", 346 },
                    { new Guid("615fa766-4a11-4e64-8a85-8c1271656937"), 565, 917, "Dianne.Bernier97", 318 },
                    { new Guid("6e9eece7-030c-4df2-8837-0f34512ae00a"), 1136, 725, "Angelo18", 302 },
                    { new Guid("7a9bca42-b153-4b7b-bd6b-d8d41d38c9ab"), 130, 851, "Jody.Hessel", 263 },
                    { new Guid("830d7f42-fd93-43ec-a591-1de3573b39f7"), 496, 24, "Maryann_Nienow", 361 },
                    { new Guid("a71fe834-ec65-411f-a351-fdf7162bc151"), 1661, 321, "Darrin.Roob", 454 },
                    { new Guid("af028519-704f-4b49-b255-95c51b1bb27d"), 1771, 494, "Sylvester.Flatley", 18 },
                    { new Guid("b304e995-91a3-4ac5-b44e-b98f99d42425"), 3284, 400, "Jim32", 123 },
                    { new Guid("cb12e787-7b31-417b-990d-8de66b99aac4"), 3545, 668, "Calvin71", 191 },
                    { new Guid("cb4b065e-7cf6-476e-bb77-7dda17d266c7"), 2244, 705, "Roderick_Beahan63", 86 },
                    { new Guid("cee0e022-f8e6-4a60-aedb-e425d2314f5a"), 4643, 50, "Antonio_Dicki98", 66 },
                    { new Guid("d0395477-058b-46df-86fd-a5593dde3b40"), 1920, 630, "Heidi42", 130 },
                    { new Guid("d0c73a24-6ed3-42ff-956e-a2d3ddfddc74"), 2752, 936, "Alan5", 167 },
                    { new Guid("d1fbdaf0-e67f-4402-ae5b-c9177e2209de"), 240, 95, "Christie_Schoen", 75 },
                    { new Guid("eaf5cac5-b9c1-4a00-ba33-eaa4d22d88a7"), 2267, 609, "Steve86", 452 },
                    { new Guid("eeb867ef-e5e0-4d83-b1d0-31148e84d772"), 4022, 99, "Donald_Reinger57", 198 },
                    { new Guid("f71e61bc-b633-4b8d-a50b-8522d7c937b2"), 1877, 835, "Wallace49", 427 },
                    { new Guid("ff9db84c-3a78-47ee-be4c-f080c98bb52b"), 3572, 419, "Melinda_Huel", 445 }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "ID", "Friendname", "PlayerID" },
                values: new object[,]
                {
                    { new Guid("00981f8a-7318-4439-9883-96c7f439b4e9"), "Carmen.Koch9", new Guid("b304e995-91a3-4ac5-b44e-b98f99d42425") },
                    { new Guid("01d632f4-2635-4051-92ce-dca114d0caf2"), "Marco_Johnson", new Guid("d0395477-058b-46df-86fd-a5593dde3b40") },
                    { new Guid("0349ea85-77e6-4696-94ea-b6431d50a6cc"), "Judith_Fisher91", new Guid("10836ada-4dcc-443a-b0c9-5d3d8aa9d57a") },
                    { new Guid("03555ee3-4863-45f5-b462-df84a3b540fc"), "Lela_Yost54", new Guid("10836ada-4dcc-443a-b0c9-5d3d8aa9d57a") },
                    { new Guid("036ce6f6-06a3-4a81-aad7-50429abfe73a"), "Bertha.Bruen21", new Guid("41aa18d8-5bcf-4d7f-9ea1-6126033e17fc") },
                    { new Guid("0c857436-c356-4b92-93d8-0d2508a80607"), "Evelyn_Williamson", new Guid("ff9db84c-3a78-47ee-be4c-f080c98bb52b") },
                    { new Guid("111fb07d-00dd-4e34-85dc-51c7a37b5d00"), "Cheryl_Rutherford", new Guid("a71fe834-ec65-411f-a351-fdf7162bc151") },
                    { new Guid("15fc989f-0312-4f1d-bc83-e32091fe78c7"), "Cynthia.Brown15", new Guid("0783bd61-1e52-46f2-88f0-4e9bf6f6a88b") },
                    { new Guid("21fbb439-8201-4d1b-bee4-c8b4d4fcf95c"), "Eleanor76", new Guid("354a7e14-f789-4fde-ba1b-ced25965e92d") },
                    { new Guid("405a368a-6ee5-47c5-9108-9d3302fa26ed"), "Mae.Satterfield64", new Guid("615fa766-4a11-4e64-8a85-8c1271656937") },
                    { new Guid("4442f03e-55d5-4014-bb7d-80501ea25b16"), "Joe.Zulauf25", new Guid("b304e995-91a3-4ac5-b44e-b98f99d42425") },
                    { new Guid("45399727-118f-4f9e-9c4d-3e86532c5d1d"), "Anna_Lynch65", new Guid("41aa18d8-5bcf-4d7f-9ea1-6126033e17fc") },
                    { new Guid("5d097fed-ef51-4b67-9e2a-79fdf162ba0e"), "Arnold.Murazik84", new Guid("a71fe834-ec65-411f-a351-fdf7162bc151") },
                    { new Guid("5d8917a9-5398-44a9-b2af-70af33abfd71"), "Ronnie38", new Guid("308567d4-5ff1-4ee5-a762-d06d3b36e3d7") },
                    { new Guid("62285a30-e542-4b84-9a93-29eb919a2474"), "Brett21", new Guid("10836ada-4dcc-443a-b0c9-5d3d8aa9d57a") },
                    { new Guid("6b23400e-330d-4578-872f-4c1133e0777c"), "Lawrence_Gislason55", new Guid("47240f49-8838-4b37-879b-4c7fd060c5bc") },
                    { new Guid("836b3c5a-f5be-4639-9c38-fc0807a8b09b"), "Walter98", new Guid("eeb867ef-e5e0-4d83-b1d0-31148e84d772") },
                    { new Guid("9539ad3f-b82b-4fac-817a-7c0b5ac225dc"), "Nelson18", new Guid("09ee2357-74bc-4cd9-8bbd-4863198d9da7") },
                    { new Guid("9677784a-2ad4-4dc9-9edd-88296430dbfb"), "Verna31", new Guid("51add663-9d4d-4331-b9d2-cdcb87632548") },
                    { new Guid("a23a5a2a-b364-4682-9137-6fb577aa9bf4"), "Javier.Miller", new Guid("cee0e022-f8e6-4a60-aedb-e425d2314f5a") },
                    { new Guid("a2698844-61ca-4a09-9ad8-660a45077622"), "Gretchen.Boyer", new Guid("d0395477-058b-46df-86fd-a5593dde3b40") },
                    { new Guid("ad506d49-43fe-41f1-819f-74a93030c9f5"), "Anthony.Muller50", new Guid("eeb867ef-e5e0-4d83-b1d0-31148e84d772") },
                    { new Guid("b5a9b1d6-9ed2-4265-b486-378dcf89c57e"), "Alton.Connelly", new Guid("0783bd61-1e52-46f2-88f0-4e9bf6f6a88b") },
                    { new Guid("ba28e56c-9f4d-46d7-8a90-c11d14f9025f"), "Andrew9", new Guid("308567d4-5ff1-4ee5-a762-d06d3b36e3d7") },
                    { new Guid("bf873518-b81c-4b88-aa49-70c9a4920619"), "Mable.Waelchi3", new Guid("cb12e787-7b31-417b-990d-8de66b99aac4") },
                    { new Guid("c6d54db6-1696-4e6b-8509-df4669748481"), "Harriet.Abshire", new Guid("ff9db84c-3a78-47ee-be4c-f080c98bb52b") },
                    { new Guid("e393885e-3e8e-4342-8b46-1c3e945ea1b3"), "Shelly_Kub52", new Guid("cb12e787-7b31-417b-990d-8de66b99aac4") },
                    { new Guid("e837719a-8bde-4a2c-a951-fc9a6fe9695f"), "Violet_Lang20", new Guid("06fe26a4-47d4-4628-a5dc-c18d1f15b0d9") },
                    { new Guid("f59862af-d4bb-454b-966c-baefbbaf0cb6"), "Melinda37", new Guid("10836ada-4dcc-443a-b0c9-5d3d8aa9d57a") },
                    { new Guid("f6501fdb-2eab-415b-8577-2d5c793ac567"), "Edmund_West", new Guid("334962bb-5d84-4748-bbae-ea30b4420e12") }
                });

            migrationBuilder.InsertData(
                table: "Violations",
                columns: new[] { "ID", "Description", "PlayerID", "Type" },
                values: new object[,]
                {
                    { new Guid("06357afd-20c7-4b4e-b254-bf9b682fa5d3"), "vitae", new Guid("41aa18d8-5bcf-4d7f-9ea1-6126033e17fc"), "aut" },
                    { new Guid("0a596d51-eebb-4e6b-b6b8-2b7a3aa30edf"), "est", new Guid("a71fe834-ec65-411f-a351-fdf7162bc151"), "blanditiis" },
                    { new Guid("109cb07a-20d1-4c46-8804-c9c56b13a7b5"), "necessitatibus", new Guid("ff9db84c-3a78-47ee-be4c-f080c98bb52b"), "et" },
                    { new Guid("11fb2f5f-483f-448a-8bc9-7947086304a6"), "minima", new Guid("41aa18d8-5bcf-4d7f-9ea1-6126033e17fc"), "ut" },
                    { new Guid("2035d3a3-4603-440f-842a-6037940a8342"), "voluptatem", new Guid("354a7e14-f789-4fde-ba1b-ced25965e92d"), "occaecati" },
                    { new Guid("2de01f99-8e0a-4c6a-974a-6d3ddd4caa14"), "accusamus", new Guid("06fe26a4-47d4-4628-a5dc-c18d1f15b0d9"), "non" },
                    { new Guid("32ac7b23-f562-41fb-a6fa-232c8f25ee6e"), "et", new Guid("d0395477-058b-46df-86fd-a5593dde3b40"), "sapiente" },
                    { new Guid("385d4f85-f781-47e7-90a4-300644499bc2"), "sit", new Guid("7a9bca42-b153-4b7b-bd6b-d8d41d38c9ab"), "repellat" },
                    { new Guid("38c30985-08ee-48eb-8166-c6061ea019b1"), "mollitia", new Guid("354a7e14-f789-4fde-ba1b-ced25965e92d"), "quas" },
                    { new Guid("39c30532-08be-4e56-b3e1-a3b1217461c5"), "omnis", new Guid("41aa18d8-5bcf-4d7f-9ea1-6126033e17fc"), "fugit" },
                    { new Guid("3bd23e0e-df19-4024-bcac-b2399c6c6b75"), "maxime", new Guid("47240f49-8838-4b37-879b-4c7fd060c5bc"), "sed" },
                    { new Guid("3f083cc7-0918-4e7f-94ca-cb1a02021301"), "laboriosam", new Guid("eeb867ef-e5e0-4d83-b1d0-31148e84d772"), "accusamus" },
                    { new Guid("571e03eb-f845-47c2-af7c-089db1afa0d3"), "et", new Guid("d1fbdaf0-e67f-4402-ae5b-c9177e2209de"), "eum" },
                    { new Guid("6756bdfb-76f0-4dc3-be0c-5f9ca9fc1a44"), "qui", new Guid("51add663-9d4d-4331-b9d2-cdcb87632548"), "occaecati" },
                    { new Guid("69a3a9dc-078b-429a-964b-ac70b51d9bdb"), "sed", new Guid("47240f49-8838-4b37-879b-4c7fd060c5bc"), "est" },
                    { new Guid("6fc925a0-fb40-4b3e-9a6c-27a154476b2a"), "reprehenderit", new Guid("cb4b065e-7cf6-476e-bb77-7dda17d266c7"), "iure" },
                    { new Guid("7061eb90-a28d-4898-8c11-58c344e2922d"), "aut", new Guid("47240f49-8838-4b37-879b-4c7fd060c5bc"), "quas" },
                    { new Guid("79cb595f-06a7-4d32-b428-0466aa47fc12"), "inventore", new Guid("cb12e787-7b31-417b-990d-8de66b99aac4"), "ea" },
                    { new Guid("7a154e09-178b-4fda-9e02-a944486259a7"), "animi", new Guid("830d7f42-fd93-43ec-a591-1de3573b39f7"), "nam" },
                    { new Guid("7bcb2427-0eac-4322-a709-3eabd9e518f3"), "ullam", new Guid("cee0e022-f8e6-4a60-aedb-e425d2314f5a"), "qui" },
                    { new Guid("88f38fa3-1ca8-4273-a6bb-17b7884bb16d"), "consectetur", new Guid("51add663-9d4d-4331-b9d2-cdcb87632548"), "mollitia" },
                    { new Guid("939c297b-4ee7-4589-acbe-190124324f34"), "ipsum", new Guid("eeb867ef-e5e0-4d83-b1d0-31148e84d772"), "voluptas" },
                    { new Guid("979af70e-0b6a-495b-852c-15d8c0decb59"), "enim", new Guid("eaf5cac5-b9c1-4a00-ba33-eaa4d22d88a7"), "impedit" },
                    { new Guid("9c807a80-610a-47c9-822c-8daaa70d2c4f"), "sit", new Guid("0783bd61-1e52-46f2-88f0-4e9bf6f6a88b"), "natus" },
                    { new Guid("b40a0260-fb20-4476-873d-e057ec01a199"), "optio", new Guid("ff9db84c-3a78-47ee-be4c-f080c98bb52b"), "ipsum" },
                    { new Guid("c90f8cee-0e88-4ff4-a57f-3b10bfb8049e"), "odio", new Guid("51add663-9d4d-4331-b9d2-cdcb87632548"), "tenetur" },
                    { new Guid("d1c05f7d-a303-45b5-9430-b5da68d12545"), "sit", new Guid("cb12e787-7b31-417b-990d-8de66b99aac4"), "amet" },
                    { new Guid("da05257d-8d53-44f3-b477-8737df867410"), "sunt", new Guid("830d7f42-fd93-43ec-a591-1de3573b39f7"), "et" },
                    { new Guid("dbb22c65-275a-469f-95a2-595210a0de51"), "dolores", new Guid("7a9bca42-b153-4b7b-bd6b-d8d41d38c9ab"), "sequi" },
                    { new Guid("e4f34095-1cf5-4dfb-9ad9-453d63172428"), "quos", new Guid("615fa766-4a11-4e64-8a85-8c1271656937"), "odit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_PlayerID",
                table: "Friends",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Violations_PlayerID",
                table: "Violations",
                column: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Violations");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
