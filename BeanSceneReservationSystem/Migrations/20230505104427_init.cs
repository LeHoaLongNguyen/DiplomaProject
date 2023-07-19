using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneReservationSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SittingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SittingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sittings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SittingTypeId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sittings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sittings_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sittings_SittingTypes_SittingTypeId",
                        column: x => x.SittingTypeId,
                        principalTable: "SittingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantTables_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestNumber = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationSourceId = table.Column<int>(type: "int", nullable: false),
                    ReservationStatusId = table.Column<int>(type: "int", nullable: false),
                    SittingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationSources_ReservationSourceId",
                        column: x => x.ReservationSourceId,
                        principalTable: "ReservationSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationStatus_ReservationStatusId",
                        column: x => x.ReservationStatusId,
                        principalTable: "ReservationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Sittings_SittingId",
                        column: x => x.SittingId,
                        principalTable: "Sittings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Name", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Main", null },
                    { 2, "Outside", null },
                    { 3, "Balcony", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "79ccb66a-fa8c-43b9-9856-08bd396ba3c0", "Manager", "MANAGER" },
                    { "60226d81-1906-41cb-8f00-44e34ee158cd", "e5fee4b7-156a-4426-8ad9-7709e4566527", "Staff", "STAFF" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "df44e2ff-0c54-46ba-89b3-c89844523d7b", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e545865-a24d-4543-a6c6-9443d048cdb9", 0, "f4061421-8cd5-4172-9a54-683b06133dcf", "Manager@test.com", true, false, null, "MANAGER@TEST.COM", "Manager@test.com", "AQAAAAEAACcQAAAAEPHCpnwf64h5hcGsdLfso/Ymeuz8hKjHkp1uIVrIDPT0lNFLfYbe8I3L99Ae1ZNFNQ==", null, false, "f3ee8470-c55e-4284-a708-1700f8130497", false, "Tester" },
                    { "8e645865-a24d-4543-a6c6-9443d048cdb9", 0, "4a9fce77-2d69-4245-b151-39565370b173", "Staff@test.com", true, false, null, "STAFF@TEST.COM", "Staff@test.com", "AQAAAAEAACcQAAAAEBMFVhQcWUTW1SzyN70Ttf3plcerKmIx9CTeLM6XOpJ1m1rr27eHhk/gsdQZoNivPA==", null, false, "770bf031-6a2b-4cab-b504-d8fdb6d99233", false, "Staff@test.com" },
                    { "8l645865-a24d-4543-a6c6-9443d048cdb9", 0, "f9069ceb-2913-4ecc-8184-70e4cf662583", "a@a.com", true, false, null, "A@A.COM", "A@A.COM", "AQAAAAEAACcQAAAAEHCbTxxijofD/5T8Zpc66XY+2xFIlyTJOueAiK4spLLfgGsXVH5LVhTMo6RgXW1LCQ==", null, false, "ece52e6f-c1c1-4e82-8ac6-dc7e1aea3cdf", false, "John" },
                    { "8l645865-b24d-4543-a6c6-9443d048cdb9", 0, "346d2aa9-98ea-4288-8f71-283b5ffaa167", "b@b.com", true, false, null, "B@B.COM", "B@B.COM", "AQAAAAEAACcQAAAAEBMMmpyUdV3wLZP9qOSO+99RLzQ30zzAnVmyYSc3EK/TxzyMqudbhduqSeJsJh1KgQ==", null, false, "b4ee65e0-3b2a-4512-bba8-7e3ecce95a09", false, "Fred" },
                    { "8l645865-c24d-4543-a6c6-9443d048cdb9", 0, "d9562bd3-d6b9-4fef-9ea7-51dc1607f3f5", "c@c.com", true, false, null, "C@C.COM", "C@C.COM", "AQAAAAEAACcQAAAAEENtZv9IzrwHRgvsjTage91wm/+HJEXIfsWhregrFghYm3VYrLhL2TI1bpMNdtHIdA==", null, false, "b57ec281-e783-4db6-9087-975b90804aaa", false, "Sarah" },
                    { "8l645865-d24d-4543-a6c6-9443d048cdb9", 0, "178ee8dd-38f9-4359-a8db-dc88f7890c6d", "d@d.com", true, false, null, "D@D.COM", "D@D.COM", "AQAAAAEAACcQAAAAEE4muhUJVnOpe2PfgBhDlNMh3GgedmArwr9Mi8VutYwp7S547QTmmbEba+f/r5SD+A==", null, false, "ea8c4ff1-87a3-4089-ac0e-abb5317b177d", false, "Lousie" },
                    { "8l645865-e24d-4543-a6c6-9443d048cdb9", 0, "b8d90c2d-4fd1-4227-88ee-ebbb1d4c9fe4", "e@e.com", true, false, null, "E@E.COM", "E@E.COM", "AQAAAAEAACcQAAAAEBZM2O0V3vtZYqYNjWrNPqCjRUAHTifpUjf8FOAIHrL+nbO4glj8TsTYalXoAKz76g==", null, false, "4d5b9d84-8220-4ed5-b8cc-4bee04f082ce", false, "Katie" },
                    { "8l645865-f24d-4543-a6c6-9443d048cdb9", 0, "8c069342-0166-4606-b6c0-99be67dbdcff", "f@f.com", true, false, null, "F@F.COM", "F@F.COM", "AQAAAAEAACcQAAAAECZ1ax/g1ATML0wVp16dlT5ki6ZfRrFhQg1wkoxZ66vJHMAVYEOkwzL72E4eDp5cJw==", null, false, "8945e52f-27f6-40dd-8101-818e64a5bec7", false, "Ben" },
                    { "8l645865-g24d-4543-a6c6-9443d048cdb9", 0, "40eddd92-1d9d-4c49-b02f-0a4ce03322c7", "g@g.com", true, false, null, "G@G.COM", "G@G.COM", "AQAAAAEAACcQAAAAEMuBGYMStCojEq2CwFlf7WV/DFGlGnMGQXA6PWknzwPeYwcc+ud3+GwKi4IBq99ezA==", null, false, "51d89aa9-a387-4813-b6b6-1340572d71dd", false, "Lucas" },
                    { "8l645865-h24d-4543-a6c6-9443d048cdb9", 0, "ca9a07c5-b0b3-4234-b4e8-261018d216aa", "h@h.com", true, false, null, "H@H.COM", "H@H.COM", "AQAAAAEAACcQAAAAEJqEm0j4QDQAlThN8KuQ3kGxaLW00gtX1qMD6zknjQW6UYxli+4tw2ib+lfh9kzG9Q==", null, false, "db83897e-f32e-4fee-a769-aa4685a38e16", false, "Liam" },
                    { "8l645865-i24d-4543-a6c6-9443d048cdb9", 0, "43ec8ec8-117c-4296-a9b9-ff376b800ed1", "i@i.com", true, false, null, "I@I.COM", "I@I.COM", "AQAAAAEAACcQAAAAEEMcyJzMUvQqeJDTdKH4qZLuAh5NrtKUFiuOxse7438I07hb1hDOKZe5XppdCg0MUg==", null, false, "4a1efc7c-bb1a-46bf-a1ab-9f2d63a47ff0", false, "Emma" },
                    { "8l645865-j24d-4543-a6c6-9443d048cdb9", 0, "51dcf6d7-b499-4de6-8a84-1eccbdc6effe", "j@j.com", true, false, null, "J@J.COM", "J@J.COM", "AQAAAAEAACcQAAAAELScdShW9QoECW6woTVf2Nrm6nFtK0B4UnvwSa8wFTikSKS3YfMgq7jpFOQmj3do2w==", null, false, "f698906a-1f51-44e3-9c9b-0d93e0edaf84", false, "Kayla" },
                    { "8l645865-k24d-4543-a6c6-9443d048cdb9", 0, "22ba8efe-896f-4efb-8f15-72a8bd5aeb93", "k@k.com", true, false, null, "K@K.COM", "K@K.COM", "AQAAAAEAACcQAAAAENeFPvc2b/OfxDZN8RNLVMy7D7vDlV9WmeVeEMuv9xbR8DO0DAZT+XW+6xruLghnGQ==", null, false, "63a1ddd7-b49b-487d-84f5-c53031d4465c", false, "Levi" },
                    { "8l645865-l24d-4543-a6c6-9443d048cdb9", 0, "5a0a94a5-0dcb-49b3-a417-1b8fed0cf70d", "l@l.com", true, false, null, "L@L.COM", "L@L.COM", "AQAAAAEAACcQAAAAECDI16l057PTacUD98TVwsYnGnEzSvEIihEPSPajjI6p0EBNHkxwUu5OUiEphYNiCQ==", null, false, "d1f6b185-f61d-41e0-861f-9e9339cc2905", false, "Noah" },
                    { "8l645865-m24d-4543-a6c6-9443d048cdb9", 0, "864b5b78-6f68-4b91-9234-eb8a6cbb9fa8", "m@m.com", true, false, null, "M@M.COM", "M@M.COM", "AQAAAAEAACcQAAAAECzVkLTKBf1sLy7hGxVth6JPBUTNchSkxI7qf/WihrdPPLWdLleBJqtsCbuOcZW7lA==", null, false, "8c2d8b67-aee3-42fe-83a6-ef6c4eb5fdd9", false, "Oliver" },
                    { "8l645865-n24d-4543-a6c6-9443d048cdb9", 0, "08c45b19-37a3-4d70-9ffc-ca3fcf40abf1", "n@n.com", true, false, null, "N@N.COM", "N@N.COM", "AQAAAAEAACcQAAAAEEx4tIyRSWpYUz7eCoN2crpqlKNi7Yn2VO4Vy/F8el2lLYilK+T+5DGkyl+3mvVMPQ==", null, false, "46bc2a00-64db-455f-928f-da63669dcf71", false, "Leo" },
                    { "8l645865-o24d-4543-a6c6-9443d048cdb9", 0, "6d26a410-897d-42c2-a6b7-999f57d4aa37", "o@o.com", true, false, null, "O@O.COM", "O@O.COM", "AQAAAAEAACcQAAAAEIxLcWtZFUTDvw9sH65ZVF/L2vxOjzCWNKd9Hc7h8ewasdJGBKv7qD8Q7dhFOXgy5A==", null, false, "fab6dede-4b9b-4808-a9e1-d6d6df8b48be", false, "Wyatt" },
                    { "8l645865-p24d-4543-a6c6-9443d048cdb9", 0, "cf035d72-b8eb-4303-94f3-6dec7c9237a2", "p@p.com", true, false, null, "P@P.COM", "P@P.COM", "AQAAAAEAACcQAAAAEFISwNy5ZZcm5jFnGVZ0/cbC7/2T6UfHaLbwRjADtqNPnoFYFJResG7gHNb6XNHrSg==", null, false, "2ca9258f-1316-401e-b1e6-a7a25f3a34e0", false, "Scarlett" },
                    { "8l645865-q24d-4543-a6c6-9443d048cdb9", 0, "2132ba8a-3ff5-498c-b5a2-5d238add08f0", "q@q.com", true, false, null, "Q@Q.COM", "Q@Q.COM", "AQAAAAEAACcQAAAAEM1Z6XofPbK4X4mLQi5NMi8F4l6tKUi6mGnVjijp0vsd7aXn1nkFW9SWRdTw1EUV/A==", null, false, "c742bd4c-105b-490c-9e23-6e4c444da80b", false, "Ella" },
                    { "8l645865-r24d-4543-a6c6-9443d048cdb9", 0, "8a8e870d-3c12-4ec4-9699-05273b5da5cc", "r@r.com", true, false, null, "R@R.COM", "R@R.COM", "AQAAAAEAACcQAAAAEMJhD4lGF/lSWC3DsCNaNK5Ymg3psXVW/MUd2vjZ7JxQmXe8pdieTyNzhXUQYZX21Q==", null, false, "74b1a6f3-1ba4-40c3-b37a-b675e59e7c52", false, "Ellie" },
                    { "8l645865-s24d-4543-a6c6-9443d048cdb9", 0, "60799b74-246b-4bc9-8c45-c9f29e01aa99", "s@s.com", true, false, null, "S@S.COM", "S@S.COM", "AQAAAAEAACcQAAAAENdFLJrhq7/p5pnqqTYdHMTswBl01ZbfHG5GrXkK9L3fZ2G6HGzyFXOQVgladXHLYg==", null, false, "a86b49dd-7b70-458c-a94a-16d0bcf9b4f6", false, "Sofia" },
                    { "8l645865-t24d-4543-a6c6-9443d048cdb9", 0, "21d553c4-2cba-4bc4-83bb-8edc3e186470", "t@t.com", true, false, null, "T@T.COM", "T@T.COM", "AQAAAAEAACcQAAAAEH3DnixNme8Bje7MRS+TooBVQM8IUb3MBV4z/4m3yukugn9hYAYoEC6D7hZAESfueA==", null, false, "604eec10-c425-4eba-a208-3cbe05c523e4", false, "Sebastian" },
                    { "8l645865-u24d-4543-a6c6-9443d048cdb9", 0, "fddcd979-e9b0-4ddb-af25-39660b5a310c", "u@u.com", true, false, null, "U@U.COM", "U@U.COM", "AQAAAAEAACcQAAAAEL4/P1Pw2vlXX/tQrEDPJn9B1EOyR7tbkWtEgaeyZ687b754nI07LRyWtSe5FzBFrg==", null, false, "b377740c-6467-4c8a-bd60-23e8de584961", false, "Violet" },
                    { "8l645865-v24d-4543-a6c6-9443d048cdb9", 0, "94401c43-4093-42ea-a761-d90abc5ce0af", "v@v.com", true, false, null, "V@V.COM", "V@V.COM", "AQAAAAEAACcQAAAAEIExHwwwQBXq25Ckh8Fwv4uqPlNEVzbzxfcC0l24ThB+wr1/rWJOfxHid9UuSC9mAA==", null, false, "1db4c644-47a2-49da-a96d-f185783de6c4", false, "Jack" },
                    { "8l645865-w24d-4543-a6c6-9443d048cdb9", 0, "455d614f-6850-425a-82bb-bd866c876454", "w@w.com", true, false, null, "W@W.COM", "W@W.COM", "AQAAAAEAACcQAAAAEH5fTldAngZkvJoQv3pU/R+z8z5gYpkXksyy00LJxwS7haNGr+76nKo+rffxxh502w==", null, false, "943eedbc-9d5f-41a7-9f99-f45e5bfc15f0", false, "Owen" },
                    { "8l645865-x24d-4543-a6c6-9443d048cdb9", 0, "8ba0fd0a-64af-43ac-b362-4c3caf3d3317", "x@x.com", true, false, null, "X@X.COM", "X@X.COM", "AQAAAAEAACcQAAAAENUVU0iKn1vZj/Dils84HTK+zXRJcUl9zy/qGWbQIF4Mn9g6SFfGbeB1/b6iNv4TcA==", null, false, "50326d89-e710-47f9-855a-9b14c6a626db", false, "Daniel" },
                    { "8l645865-y24d-4543-a6c6-9443d048cdb9", 0, "cd1b0835-bea7-4c2b-bf8e-9ee1e6ad7475", "y@y.com", true, false, null, "Y@Y.COM", "Y@Y.COM", "AQAAAAEAACcQAAAAEB3S4/5zN86W7ENBf2gxVMuQrigTVX1CYmsBw/GyAtKjd61eteB3Pol3720F09jAAg==", null, false, "ce51644b-44c0-4f07-b2ff-2c771cfba6c3", false, "Layla" },
                    { "8l645865-z24d-4543-a6c6-9443d048cdb9", 0, "bcabe1e5-0208-4ed4-81c8-c80f4b1a23a5", "z@z.com", true, false, null, "Z@Z.COM", "Z@Z.COM", "AQAAAAEAACcQAAAAEBo/9BxbwYbdkh1+2f6qr+kQpu7vMHqxLufhyK7oYcj2EmwGgFjxPGxlHkI7fmvlgw==", null, false, "0eaa0a99-7d85-4ef7-85c6-1ae8a95884cc", false, "Camila" }
                });

            migrationBuilder.InsertData(
                table: "ReservationSources",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Online" },
                    { 2, "Email" },
                    { 3, "In Person" },
                    { 4, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "ReservationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Confirmed" },
                    { 3, "Seated" },
                    { 4, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "ReservationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Cancelled" },
                    { 6, "Altered" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Bean Scene" });

            migrationBuilder.InsertData(
                table: "SittingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e545865-a24d-4543-a6c6-9443d048cdb9" },
                    { "60226d81-1906-41cb-8f00-44e34ee158cd", "8e645865-a24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-a24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-b24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-c24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-d24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-e24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-f24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-g24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-h24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-i24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-j24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-k24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-l24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-m24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-n24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-o24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-p24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-q24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-r24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-s24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-t24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-u24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-v24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-w24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-x24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-y24d-4543-a6c6-9443d048cdb9" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "8l645865-z24d-4543-a6c6-9443d048cdb9" }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Active", "Capacity", "EndTime", "Name", "RestaurantId", "SittingTypeId", "StartTime" },
                values: new object[,]
                {
                    { 1, true, 30, new DateTime(2023, 5, 6, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 6, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 2, true, 40, new DateTime(2023, 5, 6, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 6, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 3, true, 50, new DateTime(2023, 5, 6, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 6, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 4, true, 30, new DateTime(2023, 5, 7, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 7, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 5, true, 40, new DateTime(2023, 5, 7, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 7, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 6, true, 50, new DateTime(2023, 5, 7, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 7, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 7, true, 30, new DateTime(2023, 5, 8, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 8, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 8, true, 40, new DateTime(2023, 5, 8, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 8, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 9, true, 50, new DateTime(2023, 5, 8, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 8, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 10, true, 30, new DateTime(2023, 5, 9, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 9, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 11, true, 40, new DateTime(2023, 5, 9, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 9, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 12, true, 50, new DateTime(2023, 5, 9, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 9, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 13, true, 30, new DateTime(2023, 5, 10, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 10, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 14, true, 40, new DateTime(2023, 5, 10, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 10, 12, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Active", "Capacity", "EndTime", "Name", "RestaurantId", "SittingTypeId", "StartTime" },
                values: new object[,]
                {
                    { 15, true, 50, new DateTime(2023, 5, 10, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 10, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 16, true, 30, new DateTime(2023, 5, 11, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 11, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 17, true, 40, new DateTime(2023, 5, 11, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 11, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 18, true, 50, new DateTime(2023, 5, 11, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 11, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 19, true, 30, new DateTime(2023, 5, 12, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 12, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 20, true, 40, new DateTime(2023, 5, 12, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 12, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 21, true, 50, new DateTime(2023, 5, 12, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 12, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 22, true, 30, new DateTime(2023, 5, 13, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 13, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 23, true, 40, new DateTime(2023, 5, 13, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 13, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 24, true, 50, new DateTime(2023, 5, 13, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 13, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 25, true, 30, new DateTime(2023, 5, 14, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 14, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 26, true, 40, new DateTime(2023, 5, 14, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 14, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 27, true, 50, new DateTime(2023, 5, 14, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 14, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 28, true, 30, new DateTime(2023, 5, 15, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 15, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 29, true, 40, new DateTime(2023, 5, 15, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 15, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 30, true, 50, new DateTime(2023, 5, 15, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 15, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 31, true, 30, new DateTime(2023, 5, 16, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 16, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 32, true, 40, new DateTime(2023, 5, 16, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 16, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 33, true, 50, new DateTime(2023, 5, 16, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 16, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 34, true, 30, new DateTime(2023, 5, 17, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 17, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 35, true, 40, new DateTime(2023, 5, 17, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 17, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 36, true, 50, new DateTime(2023, 5, 17, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 17, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 37, true, 30, new DateTime(2023, 5, 18, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 18, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 38, true, 40, new DateTime(2023, 5, 18, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 18, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 39, true, 50, new DateTime(2023, 5, 18, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 18, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 40, true, 30, new DateTime(2023, 5, 19, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 19, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 41, true, 40, new DateTime(2023, 5, 19, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 19, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 42, true, 50, new DateTime(2023, 5, 19, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 19, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 43, true, 30, new DateTime(2023, 5, 20, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 20, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 44, true, 40, new DateTime(2023, 5, 20, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 20, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 45, true, 50, new DateTime(2023, 5, 20, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 20, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 46, true, 30, new DateTime(2023, 5, 21, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 21, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 47, true, 40, new DateTime(2023, 5, 21, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 21, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 48, true, 50, new DateTime(2023, 5, 21, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 21, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 49, true, 30, new DateTime(2023, 5, 22, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 22, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 50, true, 40, new DateTime(2023, 5, 22, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 22, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 51, true, 50, new DateTime(2023, 5, 22, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 22, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 52, true, 30, new DateTime(2023, 5, 23, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 23, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 53, true, 40, new DateTime(2023, 5, 23, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 23, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 54, true, 50, new DateTime(2023, 5, 23, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 23, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 55, true, 30, new DateTime(2023, 5, 24, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 24, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 56, true, 40, new DateTime(2023, 5, 24, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 24, 12, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Active", "Capacity", "EndTime", "Name", "RestaurantId", "SittingTypeId", "StartTime" },
                values: new object[,]
                {
                    { 57, true, 50, new DateTime(2023, 5, 24, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 24, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 58, true, 30, new DateTime(2023, 5, 25, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 25, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 59, true, 40, new DateTime(2023, 5, 25, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 25, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 60, true, 50, new DateTime(2023, 5, 25, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 25, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 61, true, 30, new DateTime(2023, 5, 26, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 26, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 62, true, 40, new DateTime(2023, 5, 26, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 26, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 63, true, 50, new DateTime(2023, 5, 26, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 26, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 64, true, 30, new DateTime(2023, 5, 27, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 27, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 65, true, 40, new DateTime(2023, 5, 27, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 27, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 66, true, 50, new DateTime(2023, 5, 27, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 27, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 67, true, 30, new DateTime(2023, 5, 28, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 28, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 68, true, 40, new DateTime(2023, 5, 28, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 28, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 69, true, 50, new DateTime(2023, 5, 28, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 28, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 70, true, 30, new DateTime(2023, 5, 29, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 29, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 71, true, 40, new DateTime(2023, 5, 29, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 29, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 72, true, 50, new DateTime(2023, 5, 29, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 29, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 73, true, 30, new DateTime(2023, 5, 30, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 30, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 74, true, 40, new DateTime(2023, 5, 30, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 30, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 75, true, 50, new DateTime(2023, 5, 30, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 30, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 76, true, 30, new DateTime(2023, 5, 31, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 31, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 77, true, 40, new DateTime(2023, 5, 31, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 31, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 78, true, 50, new DateTime(2023, 5, 31, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 31, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 79, true, 30, new DateTime(2023, 6, 1, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 6, 1, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 80, true, 40, new DateTime(2023, 6, 1, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 6, 1, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 81, true, 50, new DateTime(2023, 6, 1, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 6, 1, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 82, true, 30, new DateTime(2023, 6, 2, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 6, 2, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 83, true, 40, new DateTime(2023, 6, 2, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 6, 2, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 84, true, 50, new DateTime(2023, 6, 2, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 6, 2, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 85, true, 30, new DateTime(2023, 6, 3, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 6, 3, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 86, true, 40, new DateTime(2023, 6, 3, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 6, 3, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 87, true, 50, new DateTime(2023, 6, 3, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 6, 3, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 88, true, 30, new DateTime(2023, 6, 4, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 6, 4, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 89, true, 40, new DateTime(2023, 6, 4, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 6, 4, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 90, true, 50, new DateTime(2023, 6, 4, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 6, 4, 17, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_RestaurantId",
                table: "Areas",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationSourceId",
                table: "Reservations",
                column: "ReservationSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationStatusId",
                table: "Reservations",
                column: "ReservationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SittingId",
                table: "Reservations",
                column: "SittingId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTables_AreaId",
                table: "RestaurantTables",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sittings_RestaurantId",
                table: "Sittings",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sittings_SittingTypeId",
                table: "Sittings",
                column: "SittingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RestaurantTables");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ReservationSources");

            migrationBuilder.DropTable(
                name: "ReservationStatus");

            migrationBuilder.DropTable(
                name: "Sittings");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "SittingTypes");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
