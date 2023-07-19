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
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "92e1e396-6b2a-4cf2-92c2-9957d329fd04", "Manager", "MANAGER" },
                    { "60226d81-1906-41cb-8f00-44e34ee158cd", "680d754a-56a7-40db-951a-fd5d58da509b", "Staff", "STAFF" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "9ebad651-296d-4a30-b38f-85eecd7b6663", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "9cdcce16-c12e-45ee-8f2f-22a7105eb2e3", "Manager@test.com", true, false, null, "MANAGER@TEST.COM", "Manager@test.com", "AQAAAAEAACcQAAAAEHl/6IaGE7KvA5XrYBWeKE4MFbpYTS9bVJm/WmD4yCmT1kS78eWZQDwswy3aWHymDw==", null, false, "62ebaafa-159c-4a41-8c56-9f493455df44", false, "Manager@test.com" });

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
                    { 4, "Completed" },
                    { 5, "Cancelled" }
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
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Active", "Capacity", "EndTime", "Name", "RestaurantId", "SittingTypeId", "StartTime" },
                values: new object[,]
                {
                    { 1, true, 30, new DateTime(2023, 5, 5, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 5, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 2, true, 40, new DateTime(2023, 5, 5, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 5, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 3, true, 50, new DateTime(2023, 5, 5, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 5, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 4, true, 30, new DateTime(2023, 5, 6, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 6, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 5, true, 40, new DateTime(2023, 5, 6, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 6, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 6, true, 50, new DateTime(2023, 5, 6, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 6, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 7, true, 30, new DateTime(2023, 5, 7, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 7, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 8, true, 40, new DateTime(2023, 5, 7, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 7, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 9, true, 50, new DateTime(2023, 5, 7, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 7, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 10, true, 30, new DateTime(2023, 5, 8, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 8, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 11, true, 40, new DateTime(2023, 5, 8, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 8, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 12, true, 50, new DateTime(2023, 5, 8, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 8, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 13, true, 30, new DateTime(2023, 5, 9, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 9, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 14, true, 40, new DateTime(2023, 5, 9, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 9, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 15, true, 50, new DateTime(2023, 5, 9, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 9, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 16, true, 30, new DateTime(2023, 5, 10, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 10, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 17, true, 40, new DateTime(2023, 5, 10, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 10, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 18, true, 50, new DateTime(2023, 5, 10, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 10, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 19, true, 30, new DateTime(2023, 5, 11, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 11, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 20, true, 40, new DateTime(2023, 5, 11, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 11, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 21, true, 50, new DateTime(2023, 5, 11, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 11, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 22, true, 30, new DateTime(2023, 5, 12, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 12, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 23, true, 40, new DateTime(2023, 5, 12, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 12, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 24, true, 50, new DateTime(2023, 5, 12, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 12, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 25, true, 30, new DateTime(2023, 5, 13, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 13, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 26, true, 40, new DateTime(2023, 5, 13, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 13, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 27, true, 50, new DateTime(2023, 5, 13, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 13, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 28, true, 30, new DateTime(2023, 5, 14, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 14, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 29, true, 40, new DateTime(2023, 5, 14, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 14, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 30, true, 50, new DateTime(2023, 5, 14, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 14, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 31, true, 30, new DateTime(2023, 5, 15, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 15, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 32, true, 40, new DateTime(2023, 5, 15, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 15, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 33, true, 50, new DateTime(2023, 5, 15, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 15, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 34, true, 30, new DateTime(2023, 5, 16, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 16, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 35, true, 40, new DateTime(2023, 5, 16, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 16, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 36, true, 50, new DateTime(2023, 5, 16, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 16, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 37, true, 30, new DateTime(2023, 5, 17, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 17, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 38, true, 40, new DateTime(2023, 5, 17, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 17, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 39, true, 50, new DateTime(2023, 5, 17, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 17, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 40, true, 30, new DateTime(2023, 5, 18, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 18, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 41, true, 40, new DateTime(2023, 5, 18, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 18, 12, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Active", "Capacity", "EndTime", "Name", "RestaurantId", "SittingTypeId", "StartTime" },
                values: new object[,]
                {
                    { 42, true, 50, new DateTime(2023, 5, 18, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 18, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 43, true, 30, new DateTime(2023, 5, 19, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 19, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 44, true, 40, new DateTime(2023, 5, 19, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 19, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 45, true, 50, new DateTime(2023, 5, 19, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 19, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 46, true, 30, new DateTime(2023, 5, 20, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 20, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 47, true, 40, new DateTime(2023, 5, 20, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 20, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 48, true, 50, new DateTime(2023, 5, 20, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 20, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 49, true, 30, new DateTime(2023, 5, 21, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 21, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 50, true, 40, new DateTime(2023, 5, 21, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 21, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 51, true, 50, new DateTime(2023, 5, 21, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 21, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 52, true, 30, new DateTime(2023, 5, 22, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 22, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 53, true, 40, new DateTime(2023, 5, 22, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 22, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 54, true, 50, new DateTime(2023, 5, 22, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 22, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 55, true, 30, new DateTime(2023, 5, 23, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 23, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 56, true, 40, new DateTime(2023, 5, 23, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 23, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 57, true, 50, new DateTime(2023, 5, 23, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 23, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 58, true, 30, new DateTime(2023, 5, 24, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 24, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 59, true, 40, new DateTime(2023, 5, 24, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 24, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 60, true, 50, new DateTime(2023, 5, 24, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 24, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 61, true, 30, new DateTime(2023, 5, 25, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 25, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 62, true, 40, new DateTime(2023, 5, 25, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 25, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 63, true, 50, new DateTime(2023, 5, 25, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 25, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 64, true, 30, new DateTime(2023, 5, 26, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 26, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 65, true, 40, new DateTime(2023, 5, 26, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 26, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 66, true, 50, new DateTime(2023, 5, 26, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 26, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 67, true, 30, new DateTime(2023, 5, 27, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 27, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 68, true, 40, new DateTime(2023, 5, 27, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 27, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 69, true, 50, new DateTime(2023, 5, 27, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 27, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 70, true, 30, new DateTime(2023, 5, 28, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 28, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 71, true, 40, new DateTime(2023, 5, 28, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 28, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 72, true, 50, new DateTime(2023, 5, 28, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 28, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 73, true, 30, new DateTime(2023, 5, 29, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 29, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 74, true, 40, new DateTime(2023, 5, 29, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 29, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 75, true, 50, new DateTime(2023, 5, 29, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 29, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 76, true, 30, new DateTime(2023, 5, 30, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 30, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 77, true, 40, new DateTime(2023, 5, 30, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 30, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 78, true, 50, new DateTime(2023, 5, 30, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 30, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 79, true, 30, new DateTime(2023, 5, 31, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 5, 31, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 80, true, 40, new DateTime(2023, 5, 31, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 5, 31, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 81, true, 50, new DateTime(2023, 5, 31, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 5, 31, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 82, true, 30, new DateTime(2023, 6, 1, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 6, 1, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 83, true, 40, new DateTime(2023, 6, 1, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 6, 1, 12, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "Active", "Capacity", "EndTime", "Name", "RestaurantId", "SittingTypeId", "StartTime" },
                values: new object[,]
                {
                    { 84, true, 50, new DateTime(2023, 6, 1, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 6, 1, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 85, true, 30, new DateTime(2023, 6, 2, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 6, 2, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 86, true, 40, new DateTime(2023, 6, 2, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 6, 2, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 87, true, 50, new DateTime(2023, 6, 2, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 6, 2, 17, 0, 0, 0, DateTimeKind.Local) },
                    { 88, true, 30, new DateTime(2023, 6, 3, 11, 0, 0, 0, DateTimeKind.Local), "Breakfast", 1, 1, new DateTime(2023, 6, 3, 7, 0, 0, 0, DateTimeKind.Local) },
                    { 89, true, 40, new DateTime(2023, 6, 3, 16, 0, 0, 0, DateTimeKind.Local), "Lunch", 1, 2, new DateTime(2023, 6, 3, 12, 0, 0, 0, DateTimeKind.Local) },
                    { 90, true, 50, new DateTime(2023, 6, 3, 21, 0, 0, 0, DateTimeKind.Local), "Dinner", 1, 3, new DateTime(2023, 6, 3, 17, 0, 0, 0, DateTimeKind.Local) }
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
