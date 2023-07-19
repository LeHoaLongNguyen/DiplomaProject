using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneReservationSystem.Migrations
{
    public partial class Init : Migration
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
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "884f5956-9be5-4c4c-9096-00b8eff78299", "Manager", "MANAGER" },
                    { "60226d81-1906-41cb-8f00-44e34ee158cd", "bbabc7a0-e14d-4d6a-ba65-03ef55f74324", "Staff", "STAFF" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "c0300f0b-fa95-4b21-a10b-5b6871c57686", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e545865-a24d-4543-a6c6-9443d048cdb9", 0, "7039770a-c2bf-486e-9673-f867665e3c89", "Manager@test.com", true, false, null, "MANAGER@TEST.COM", "Manager@test.com", "AQAAAAEAACcQAAAAEGz0Cn+ZaHZfkNYWB5MIdHDx+7DnCxn21DbA+kiBYfho0Gz6keUwtiwkZH2LRhccXw==", null, false, "971f49e2-7e44-47e2-bb3a-41b4aca68d9c", false, "Manager@test.com" },
                    { "8e645865-a24d-4543-a6c6-9443d048cdb9", 0, "8c666625-739d-4c2e-a2a2-500b74e7a358", "Staff@test.com", true, false, null, "STAFF@TEST.COM", "Staff@test.com", "AQAAAAEAACcQAAAAEKOzKv0dsEltS83atOp7PWtuSig0OVPG+yppAQ92VER07lTUsJsQLyIvqK96ZLpKZQ==", null, false, "4e853eef-29e5-4872-b7d3-f713833d0824", false, "Staff@test.com" },
                    { "8l645865-a24d-4543-a6c6-9443d048cdb9", 0, "59152a59-b944-436e-9813-faddd2a73388", "a@a.com", true, false, null, "A@A.COM", "JOHN", "AQAAAAEAACcQAAAAEBs25GS2mvm61DzS1zoPfqCHpnoEvbqNs23A2OIZ0rAGZrVC73PnZyQVLsGqgJTRgQ==", null, false, "54464cd6-58f2-4172-b6f3-186cf461bd8d", false, "John" },
                    { "8l645865-b24d-4543-a6c6-9443d048cdb9", 0, "d70ff424-b18d-489b-857b-c4e31405684f", "b@b.com", true, false, null, "B@B.COM", "FRED", "AQAAAAEAACcQAAAAEI8kgAHptZlekVx+mRuBCNKzRB3EFITZcvAhpXKutbgCceJraUgYZAnUwrIXh2q6/g==", null, false, "bfdd0c67-3efe-453b-9a04-3d30d22ab9a5", false, "Fred" },
                    { "8l645865-c24d-4543-a6c6-9443d048cdb9", 0, "1019a078-6ea6-4069-9589-c73c30b96541", "c@c.com", true, false, null, "C@C.COM", "SARAH", "AQAAAAEAACcQAAAAEFyGigWzS+s8RnMSTkNsE5sEzSusQJZKA+O9QN6lruuCXuZghC1rKgV1XBTGe5tqfg==", null, false, "ed20d055-2baf-445a-9d08-3648c15f35e1", false, "Sarah" },
                    { "8l645865-d24d-4543-a6c6-9443d048cdb9", 0, "62ea0491-88c3-422e-af95-a71021f05fab", "d@d.com", true, false, null, "D@D.COM", "LOUSIE", "AQAAAAEAACcQAAAAEICEQOp4sJUZ50kN/fPpSfY4YV0DXM0ESfReqFla5mMUzZoNmnTLIjooiTPIXr1ZEg==", null, false, "425a7dda-f2c5-43e9-9bd0-a45b309ea155", false, "Lousie" },
                    { "8l645865-e24d-4543-a6c6-9443d048cdb9", 0, "01ddbbcb-2f10-4352-ba15-e658b4f61593", "e@e.com", true, false, null, "E@E.COM", "KATIE", "AQAAAAEAACcQAAAAEMSbcohNh0twoomU2fTE8JXN4b+ciwoLBUN/SK7Drd8CtgOT1KuiCBlallC4iETVHg==", null, false, "b641dcf4-af98-452b-ae3c-58ac5bf900ac", false, "Katie" },
                    { "8l645865-f24d-4543-a6c6-9443d048cdb9", 0, "30c8aa29-744a-46f7-9ab2-d89ad55b9fd5", "f@f.com", true, false, null, "F@F.COM", "BEN", "AQAAAAEAACcQAAAAEGwDRyjGHBVZ407//jB6rZPqEsTwYvoeDPkTlWBocoAJ/KzbbY6zdpbWtBROkge7zA==", null, false, "b39a64b9-8275-4c74-8703-78aff2f702f5", false, "Ben" },
                    { "8l645865-g24d-4543-a6c6-9443d048cdb9", 0, "4974c779-2a12-4d7b-85d8-6ecd20b0baba", "g@g.com", true, false, null, "G@G.COM", "LUCAS", "AQAAAAEAACcQAAAAENpNoAtktTEEk0kCmGU1NS3rUYhxRoFxL1euTOdpYERLrPzCCiAX1VI72CEWQClYFw==", null, false, "8ed80b78-b37a-4452-b857-286eb6411ff3", false, "Lucas" },
                    { "8l645865-h24d-4543-a6c6-9443d048cdb9", 0, "f43d5d0b-fd4e-4464-acce-3703fb192dea", "h@h.com", true, false, null, "H@H.COM", "LIAM", "AQAAAAEAACcQAAAAEKPxz/K7olUaRaWUAaOJA3XVlU2zG4SpN2/WDbt1fCKH4vim/bkJJnfpLYlRXnNrZQ==", null, false, "1ed789ab-674b-4f04-aeea-ad67e49bbcaf", false, "Liam" },
                    { "8l645865-i24d-4543-a6c6-9443d048cdb9", 0, "0b90b0eb-42e4-4583-9e4a-c84e4414bf53", "i@i.com", true, false, null, "I@I.COM", "EMMA", "AQAAAAEAACcQAAAAEH/DZypiu0Wmqrv4OPZiHlJzSI3fvRhPpC2wqAPD4+D5t9BE3DSHi9I6bi9emgc8Dw==", null, false, "22d0cb42-b10d-44a9-aaf0-6da6ac58f42e", false, "Emma" },
                    { "8l645865-j24d-4543-a6c6-9443d048cdb9", 0, "8986861b-7d9e-4805-8b9d-532b9e6d2914", "j@j.com", true, false, null, "J@J.COM", "KAYLA", "AQAAAAEAACcQAAAAEGyToaOz81IFY85iLEkGWjbNlI32cbZZNeYpPRURq9tj0m3xVleZElzfYp2Zt0iVIA==", null, false, "97f06428-158c-40d1-8d6b-b5a9ffd72376", false, "Kayla" },
                    { "8l645865-k24d-4543-a6c6-9443d048cdb9", 0, "38f3f507-ee82-4e02-bd80-5014be80f676", "k@k.com", true, false, null, "K@K.COM", "LEVI", "AQAAAAEAACcQAAAAELcx+6G2cg2XqPXhw7aJ5OPHEeBQof28f5QysOLK7HTaeZXaiPxoqNm+u3ABN4hB/g==", null, false, "76f53e1b-111e-4d05-8a9e-b97a93b8b184", false, "Levi" },
                    { "8l645865-l24d-4543-a6c6-9443d048cdb9", 0, "f5ace922-0378-4fd8-872c-3bd9913a8abd", "l@l.com", true, false, null, "L@L.COM", "NOAH", "AQAAAAEAACcQAAAAEB3OxbzXGZYxtAxGOnwcRrzZSt3Z30nOe4xSDD7Tzk9dyqCsuVxhEEKgEUl1ICikcQ==", null, false, "07e493c2-4baf-4e2f-ac65-9e8be89b95e9", false, "Noah" },
                    { "8l645865-m24d-4543-a6c6-9443d048cdb9", 0, "69c4bd6e-330f-497b-af1e-f673eec74ac1", "m@m.com", true, false, null, "M@M.COM", "OLIVER", "AQAAAAEAACcQAAAAEH/cIOm9oDtUGBVEvyeqVM5agYxqDh6TYn7sM7mq7wk9vm+T/FeGLRIVANADo3ciQA==", null, false, "dbcaf758-39cc-4d65-be7a-10a55012a1c2", false, "Oliver" },
                    { "8l645865-n24d-4543-a6c6-9443d048cdb9", 0, "7c0a096d-7c38-4f20-a695-0565dfec1a03", "n@n.com", true, false, null, "N@N.COM", "LEO", "AQAAAAEAACcQAAAAEGrwPgZVwhxGTdgyat8ANnrhSK19yOStuKrIIYD7+tLNz15bhMvpVQ+oIP9dJbjEjg==", null, false, "8e75cea1-b06c-405f-b664-b3e73a353361", false, "Leo" },
                    { "8l645865-o24d-4543-a6c6-9443d048cdb9", 0, "e4ace7d3-a0f6-492c-9641-948addbcdbb3", "o@o.com", true, false, null, "O@O.COM", "WYATT", "AQAAAAEAACcQAAAAEPcz1dMWC7e1+FN9wRlpGj4R9Ja4f4mf8KZntOZgcWDPITV2OGkSimlSO0u8fvWe3A==", null, false, "afd5965a-9a0d-458b-9ade-f3d7028c7d39", false, "Wyatt" },
                    { "8l645865-p24d-4543-a6c6-9443d048cdb9", 0, "cc5da087-9fc8-4c5a-9df4-a3412859abe0", "p@p.com", true, false, null, "P@P.COM", "SCARLETT", "AQAAAAEAACcQAAAAEP4SnABII6bytdrEcCKRpdG07QTOf0zZEjW6ejgF5QlIY8Vl9DrCQX35G6VB1Ylssg==", null, false, "89a9e003-3a09-43c6-a52e-53cc114fa18d", false, "Scarlett" },
                    { "8l645865-q24d-4543-a6c6-9443d048cdb9", 0, "63726e67-32bb-4547-8558-45c6162a3514", "q@q.com", true, false, null, "Q@Q.COM", "ELLA", "AQAAAAEAACcQAAAAEHmOGe3j0etqP03ytYDCiK3UHLdnCo1++b9Zl4j/Q6UjrOIaLHnia8qZsbTX22jrag==", null, false, "117b7ab8-54bf-4758-9e40-c6ea210a027f", false, "Ella" },
                    { "8l645865-r24d-4543-a6c6-9443d048cdb9", 0, "34ed53e2-8a99-4b29-8bf9-59cbde536a80", "r@r.com", true, false, null, "R@R.COM", "ELLIE", "AQAAAAEAACcQAAAAEJWnXVjr/S79AkvR5ip6oBCkQ3rLEyC8L4OD4sYrA9VlVBdhN4BVINd5eckGbssy7A==", null, false, "7064089b-9e62-4480-ba03-923eb0cf4646", false, "Ellie" },
                    { "8l645865-s24d-4543-a6c6-9443d048cdb9", 0, "b142a528-eb80-416b-aaaf-989bb0f5fb59", "s@s.com", true, false, null, "S@S.COM", "SOFIA", "AQAAAAEAACcQAAAAEI7udQlSwFmWcF7WhQf2Gw/3hxHKwjB3P6GfMk/BKGLbo8DzFZoeyw9kdoVzSuEDSQ==", null, false, "dcb84c9a-9201-4719-bece-e9bf12afb04b", false, "Sofia" },
                    { "8l645865-t24d-4543-a6c6-9443d048cdb9", 0, "f17b425b-5e9f-4096-9f52-4e289525ee76", "t@t.com", true, false, null, "T@T.COM", "SEBASTIAN", "AQAAAAEAACcQAAAAECT5/PCL5nrIbzAo970ek2jH4WlzURHsS/sIAhMq1uPbDYe/IP2wpUlFisIYohWHmQ==", null, false, "6d258f9e-85b1-4a50-a6dd-4d0363e8e1d9", false, "Sebastian" },
                    { "8l645865-u24d-4543-a6c6-9443d048cdb9", 0, "5e35a75f-242c-4fdd-b19f-276413281b1b", "u@u.com", true, false, null, "U@U.COM", "VIOLET", "AQAAAAEAACcQAAAAEBnaAeP0Hzm2gQ1WegiMD1dHGrIPH7P2a+XBJU1bdBFhTFSJNevBK2FU14HoFPDRyg==", null, false, "9588c252-c2e8-409e-852c-a89face97833", false, "Violet" },
                    { "8l645865-v24d-4543-a6c6-9443d048cdb9", 0, "117508e6-d876-4c8e-a1e1-55097d6d590a", "v@v.com", true, false, null, "V@V.COM", "JACK", "AQAAAAEAACcQAAAAEJKR6nvZtZbugrA5E4tGBNMBFWaxId7qS04CEnVC9+yEfQ4hmyJgJ/tpx1a9f91s1Q==", null, false, "0e9e7527-5332-4c38-a3f4-1c55e7dd725a", false, "Jack" },
                    { "8l645865-w24d-4543-a6c6-9443d048cdb9", 0, "dc66016f-0209-4d3d-bfc3-36c3cf0637dc", "w@w.com", true, false, null, "W@W.COM", "OWEN", "AQAAAAEAACcQAAAAEOAOk27JshlBsoUHCoseHqgoLtg1AtnA7NFwOMAJ6RzGL+sqmxdASKHV3dOVbsVI7A==", null, false, "e367fdba-b480-4449-a30f-7698eb95b966", false, "Owen" },
                    { "8l645865-x24d-4543-a6c6-9443d048cdb9", 0, "07d4c749-7227-441a-a11b-6e89141dffd6", "x@x.com", true, false, null, "X@X.COM", "DANIEL", "AQAAAAEAACcQAAAAEJ383xUiOn0ECa98/uPOSDeaqYEzE8/2jGiBIprUjGCs40k4pRJoiapiL86oXY7mhw==", null, false, "90d2692e-82e0-49a9-b310-f9f3b186d6cd", false, "Daniel" },
                    { "8l645865-y24d-4543-a6c6-9443d048cdb9", 0, "6418bb71-8f9e-4447-85a7-eba2fc71e796", "y@y.com", true, false, null, "Y@Y.COM", "LAYLA", "AQAAAAEAACcQAAAAEDmF8kn4q+PGhWiafBEN9iFvPe1WVrzTi08CVm6ce68zNCFIOrE/NnwH0LkomZr35g==", null, false, "b06186fa-410a-40fb-a2cf-f5e3061dee25", false, "Layla" },
                    { "8l645865-z24d-4543-a6c6-9443d048cdb9", 0, "8b60ae4c-d37d-4948-bd6c-f9e33b5b87fd", "z@z.com", true, false, null, "Z@Z.COM", "CAMILA", "AQAAAAEAACcQAAAAEPzp6G3ZXJoZjdOFF3o99bjXHF4hxR2Eo+fpRBFk7egPjcOBYZ7HYz+NTj4GwrkoVA==", null, false, "34a65cf2-3ddf-46b3-b59b-6692f6c3b889", false, "Camila" }
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
