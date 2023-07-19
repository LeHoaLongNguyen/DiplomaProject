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
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "c62c075c-a036-4fb4-b234-3f03ae67182d", "Manager", "MANAGER" },
                    { "60226d81-1906-41cb-8f00-44e34ee158cd", "8e7c6927-8c08-47f5-bf72-cbfced578fdc", "Staff", "STAFF" },
                    { "e07d60fb-e2bd-4443-9759-8edc2c65ba17", "c3c05626-8ad8-4719-b4c0-32a615728c03", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e545865-a24d-4543-a6c6-9443d048cdb9", 0, "acbf05d8-58e1-4abe-b40e-3660a9e94512", "Manager@test.com", true, false, null, "MANAGER@TEST.COM", "Manager@test.com", "AQAAAAEAACcQAAAAEOWw+SyK5wsChfcw7sPpzli9ma+HmGFouj7rLdtox3KIxUzZHONEBLltOW6GxfJpzg==", null, false, "4cb4a235-b8de-4f8c-b87f-124a0ed11989", false, "Manager@test.com" },
                    { "8e645865-a24d-4543-a6c6-9443d048cdb9", 0, "4c61e58f-a66e-4b65-849f-24af84c8473c", "Staff@test.com", true, false, null, "STAFF@TEST.COM", "Staff@test.com", "AQAAAAEAACcQAAAAENeYoVkOPWkCegpnPQWFfEBSn4L9c13guLfNIMbhvxW/0IH6mHI6Jfy8w44Nplz+Mg==", null, false, "7263dbaa-27d7-41e9-afe5-c3aac7f4779a", false, "Staff@test.com" },
                    { "8l645865-a24d-4543-a6c6-9443d048cdb9", 0, "be1c7840-e337-4075-afb8-f6a217315acf", "a@a.com", true, false, null, "a@a.com", "a", "AQAAAAEAACcQAAAAEGinb6qcBok/wRB6TBk29lMUVvAvjC/Yq8F9yyWxaTCwwwCdM2PT1k2YgwVQDchZ8g==", null, false, "4fc8ad6c-a7dd-478d-a758-15abb446c10d", false, "John" },
                    { "8l645865-b24d-4543-a6c6-9443d048cdb9", 0, "c510a19d-b7f6-4f6a-922d-3b67416fb63a", "b@b.com", true, false, null, "b@b.com", "b", "AQAAAAEAACcQAAAAEEWrVj8I/gySqZYcwssoqUn1KO7U8S46QZt/uiWpGjDySCj4/UPOgNCKE3/C2cBopQ==", null, false, "ba3a97f2-324d-45da-a22f-ed8514d2e187", false, "Fred" },
                    { "8l645865-c24d-4543-a6c6-9443d048cdb9", 0, "9146253a-0f3a-4bb1-b8da-d90827db396f", "c@c.com", true, false, null, "c@c.com", "c", "AQAAAAEAACcQAAAAELLCqjkiCi/KlbU8rasdhDHroUK+A++JfGUK9KOMHUSjfFphzTynhdhI2Uj/7JFG5g==", null, false, "aec19621-efab-4910-92b9-47f20b4a7e02", false, "Sarah" },
                    { "8l645865-d24d-4543-a6c6-9443d048cdb9", 0, "5c98a673-dac6-449d-a09a-37f433e327a7", "d@d.com", true, false, null, "d@d.com", "d", "AQAAAAEAACcQAAAAEIt7rwAcyvOGwCsJX/trUaMgqqRSclHWy5NwjI5WcMes52S2oBSgXPpsTurkcPcoRg==", null, false, "7ba2bb0e-21a3-4361-b665-e7bb10d777c9", false, "Lousie" },
                    { "8l645865-e24d-4543-a6c6-9443d048cdb9", 0, "8e690357-0f7c-48c3-b394-6f0119fd08ec", "e@e.com", true, false, null, "e@e.com", "e", "AQAAAAEAACcQAAAAEPVUK7WoWg+NMYhMTWX9HLpwfufkHXhwdyZ+fPyxgP80vGJ3/ROY4F0qImnTLWCr/g==", null, false, "77df9dee-3edf-4bef-a627-c8635d32d7ad", false, "Katie" },
                    { "8l645865-f24d-4543-a6c6-9443d048cdb9", 0, "bff2af8c-c5b4-4e48-b44b-2bf73bdea6fe", "f@f.com", true, false, null, "f@f.com", "f", "AQAAAAEAACcQAAAAENLUdfZoqyQGV1hfvIyQ8ZcJqq9Wf7i4a+eJRqvIRwJz7ITBzAsVptt8ZmH/1q5FMA==", null, false, "609e117d-2e3d-4063-9d68-b53c5a1b013e", false, "Ben" },
                    { "8l645865-g24d-4543-a6c6-9443d048cdb9", 0, "764e603f-6e13-458b-9b12-b2abc3302cc9", "g@g.com", true, false, null, "g@g.com", "g", "AQAAAAEAACcQAAAAEIj5IWZye8m8YKqvF0tNv9LriHhR4VKc3i8AsRTWSno9/xTsJaEwAorgcX93GRJXvQ==", null, false, "c5c226d5-b0c0-4742-b542-596cb652f616", false, "Lucas" },
                    { "8l645865-h24d-4543-a6c6-9443d048cdb9", 0, "d36192c7-dbee-419a-b49b-d245ab42dd55", "h@h.com", true, false, null, "h@h.com", "h", "AQAAAAEAACcQAAAAEKiu64XeCvmvhZcvwnLrhhSYPLF3m3VKT09q6N1IAu4rjfQXKCtaueY9dlRrY5aV3g==", null, false, "77116f72-efc3-4b27-a16e-17969613d49c", false, "Liam" },
                    { "8l645865-i24d-4543-a6c6-9443d048cdb9", 0, "fd26b55a-030a-4a83-a775-74c350351840", "i@i.com", true, false, null, "i@i.com", "i", "AQAAAAEAACcQAAAAEC6lBN4qDrIxzp/RHr/1vSyjINpeR1ynuBaZOLizdGCWf8xa3cQlw9RhCGUGok8oXQ==", null, false, "68c98b68-b0dd-4c9b-8925-f660ed1886c9", false, "Emma" },
                    { "8l645865-j24d-4543-a6c6-9443d048cdb9", 0, "a9b1ed31-8535-4890-8c75-83ddd5051ba9", "j@j.com", true, false, null, "j@j.com", "j", "AQAAAAEAACcQAAAAEDFYwsYjIPU+46tW4ZszJTWUw3MuFWn4z+xRrZ8dkUp1NssFX4MiOAro16y7xo4aDA==", null, false, "805fd986-0a3d-43bf-bcf6-ee9e7a1ea50d", false, "Kayla" },
                    { "8l645865-k24d-4543-a6c6-9443d048cdb9", 0, "bdea119e-4954-4071-87e6-5e06b3b4499e", "k@k.com", true, false, null, "k@k.com", "k", "AQAAAAEAACcQAAAAEOjhddTL/rI+iZaC4u9qh/3pqYkj83MO+h+o+BZveRamcB0vBGIeUWN0HFcUEYlPnw==", null, false, "9d4382a0-eb2d-4752-aefb-7540948e4af5", false, "Levi" },
                    { "8l645865-l24d-4543-a6c6-9443d048cdb9", 0, "c11a29ed-394f-498f-975f-2a14824e0d7e", "l@l.com", true, false, null, "l@l.com", "l", "AQAAAAEAACcQAAAAELPG9ldb0oAKTyNHFSulUhn/uxP056vWoMxKVV3ODEhjQAyV9dWz820sVp/ixzwRKQ==", null, false, "d8b0d429-540e-41ba-8f41-82d20d777034", false, "Noah" },
                    { "8l645865-m24d-4543-a6c6-9443d048cdb9", 0, "44ec292b-cfb4-4725-a7c5-ddb21244ce66", "m@m.com", true, false, null, "m@m.com", "m", "AQAAAAEAACcQAAAAEDkXwyzHxB5PK3axACQVND/IIqco+anq02p9nqoRpAnEaqY9NLWVixDk9NmEOUTdAg==", null, false, "c70173cc-106d-4282-9a78-d23b3714e96c", false, "Oliver" },
                    { "8l645865-n24d-4543-a6c6-9443d048cdb9", 0, "2cc72091-49b9-4471-9035-e8ecfcb16ccc", "n@n.com", true, false, null, "n@n.com", "n", "AQAAAAEAACcQAAAAEC/6dSMR4vQk4p3Uk5DCk+v9CNklhifdcEG9jfZ4wrO4x9dL5u1Dxc0eAFqHikXUjA==", null, false, "ed1c2cc5-4823-4769-8359-d0121f3b244e", false, "Leo" },
                    { "8l645865-o24d-4543-a6c6-9443d048cdb9", 0, "2db4a0ba-e020-4cc2-929b-d1fdd8049f5a", "o@o.com", true, false, null, "o@o.com", "o", "AQAAAAEAACcQAAAAEHSI/vCDRXIXHPR9vGgVYrJEiJXQZLl0v5AxUo1FAZyfiD1KqQ4YysHHMdCA3KNVyA==", null, false, "9f38021d-7e54-40f6-b5ff-ea125bd615c2", false, "Wyatt" },
                    { "8l645865-p24d-4543-a6c6-9443d048cdb9", 0, "b68f20b2-3dc2-4353-9567-b9a48cc5a7e0", "p@p.com", true, false, null, "p@p.com", "p", "AQAAAAEAACcQAAAAELR5fDN/Ys6GwOypMHI7WWvdQkTaE8gcNowfW07aDSvAqyc5ERx6yPLlqGsJwKXqYQ==", null, false, "2c05fa5e-681c-4cba-99b9-736a459bc240", false, "Scarlett" },
                    { "8l645865-q24d-4543-a6c6-9443d048cdb9", 0, "6e6c2856-31d5-4e45-bd9c-5b37f85a71fa", "q@q.com", true, false, null, "q@q.com", "q", "AQAAAAEAACcQAAAAEGvJrsRgE7bH9z0d5e4Qgvw9bXFBJFNurSWni8Uz6na3/U5t2b/DYmIUVauNUJp+EQ==", null, false, "f741d6ef-84e3-4203-ab60-36f0ed0f51af", false, "Ella" },
                    { "8l645865-r24d-4543-a6c6-9443d048cdb9", 0, "8152f4e7-ae4a-4c27-bc7a-0ba999ed6e4a", "r@r.com", true, false, null, "r@r.com", "r", "AQAAAAEAACcQAAAAECWfhU/MYBmto3fbItKEftTa1AT/7jh0YQB4hdXzR/iNI1zUpIRt1wOtRjH7aTYjpg==", null, false, "4f0754bc-3f3c-46d5-a26a-a076a814ad38", false, "Ellie" },
                    { "8l645865-s24d-4543-a6c6-9443d048cdb9", 0, "ed9e6e59-80e9-40bc-9ead-8c9efad23f10", "s@s.com", true, false, null, "s@s.com", "s", "AQAAAAEAACcQAAAAECBz8z5r2bBZ/pABPo87VAgiCSgp63GeHASxbqlfHdOlSvrVb7RaDZddWaKc6HPd1Q==", null, false, "fccbbce2-6387-4822-9144-be23198ab753", false, "Sofia" },
                    { "8l645865-t24d-4543-a6c6-9443d048cdb9", 0, "61131849-e2f0-46ed-8b44-bd3ee62475f5", "t@t.com", true, false, null, "t@t.com", "t", "AQAAAAEAACcQAAAAEM6tLDYRDIZPWjy5snYXLVR5T3rsAxvIERLy2XItmvUC7xWTz/Z1QXiiO3rvBix44w==", null, false, "d0ecae2b-717c-4895-a884-577101f6ff08", false, "Sebastian" },
                    { "8l645865-u24d-4543-a6c6-9443d048cdb9", 0, "92fe4458-4a89-4e3f-8d0a-823dcff50d3a", "u@u.com", true, false, null, "u@u.com", "u", "AQAAAAEAACcQAAAAEIRp/9Pp1qSjfVYH0ymMuLGN62JJo+luNlTbOcOAB0PB8aQFqNJPdJ3h/fsDQiK6kg==", null, false, "eccf79b8-4ebf-4441-83d7-1484c4f4d367", false, "Violet" },
                    { "8l645865-v24d-4543-a6c6-9443d048cdb9", 0, "78963ea0-b98d-4b0f-be8d-4a2a81ff29d3", "v@v.com", true, false, null, "v@v.com", "v", "AQAAAAEAACcQAAAAEE6aq3XmvfKJpIHXnS5krcmMUC0Lk8Mpyj5w1Cf8iyDkmt/ZUOHMM/HuJ5dOlkWkuQ==", null, false, "78d71b4c-20e8-4e83-a443-f8ce610f1e91", false, "Jack" },
                    { "8l645865-w24d-4543-a6c6-9443d048cdb9", 0, "a822a190-dffb-45f5-9ac6-54c460af331d", "w@w.com", true, false, null, "w@w.com", "w", "AQAAAAEAACcQAAAAEJbxHIJFXJw4+rZJyscEItr4/77g5MM2VMeEwV2KLa02M3eqFErshtBlzRGLkEM1ag==", null, false, "45980560-76c6-4d09-aa2a-ba78c048f2c9", false, "Owen" },
                    { "8l645865-x24d-4543-a6c6-9443d048cdb9", 0, "fe8ed5d6-1a93-45a1-9acd-2d5ae8274fa3", "x@x.com", true, false, null, "x@x.com", "x", "AQAAAAEAACcQAAAAEPd6F0F2xZJZ2QL99fyHiZvEXFWsCu90kuSMAbgBUI1odx7i3/7KungXeUczs+T0oQ==", null, false, "299b5b7a-6d01-4d97-90fb-6f3cc0b7aca9", false, "Daniel" },
                    { "8l645865-y24d-4543-a6c6-9443d048cdb9", 0, "ee18b6a8-3843-45f5-9366-37705fdf3e45", "y@y.com", true, false, null, "y@y.com", "y", "AQAAAAEAACcQAAAAEHlNYU90MWSx2CvexrTvvkuQxJSmOBsfvfmrA7IrSNZ2HDeb4hpINWHRcRe6ixcPtg==", null, false, "d67c9759-ca72-421c-9349-953877465cce", false, "Layla" },
                    { "8l645865-z24d-4543-a6c6-9443d048cdb9", 0, "8066cbae-850e-4347-8a3e-a5e782d67a95", "z@z.com", true, false, null, "z@z.com", "z", "AQAAAAEAACcQAAAAEG/0ChmTVDCIVa2EMIQ7FrQgarLYANBAvNj+Y+B7qmNWx9nQZ/T6CIoR8Q7AEw0rvQ==", null, false, "0095243f-82ce-4998-8571-53916cfc5a2b", false, "Camila" }
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
