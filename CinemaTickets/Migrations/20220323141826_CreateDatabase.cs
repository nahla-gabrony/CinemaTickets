using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTickets.Migrations
{
    public partial class CreateDatabase : Migration
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crews_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlideTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlideDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlideImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheaterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheaterDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheaterLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheaterImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrewBiography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrewImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrewDateofBirth = table.Column<DateTime>(type: "date", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    CrewRoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Crew_Crews_Roles_CrewRoleId",
                        column: x => x.CrewRoleId,
                        principalTable: "Crews_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieRunningTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Movies_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheaterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screens_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crew_Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew_Gallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_Gallery_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crew_Movies",
                columns: table => new
                {
                    CrewId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew_Movies", x => new { x.CrewId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Crew_Movies_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crew_Movies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genres_Movies",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres_Movies", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Genres_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Genres_Movies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie_Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Gallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Gallery_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShowEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Show_Times",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    TimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show_Times", x => new { x.ShowId, x.TimeId });
                    table.ForeignKey(
                        name: "FK_Show_Times_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Show_Times_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketPrice = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShowTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b176ab1c-055e-4a7f-99ce-9d16fd033d1f", "32a14ad2-29f0-4abd-a5aa-f6ddbe308999", "User", "USER" },
                    { "c0d45dad-ba1d-4efe-b1ab-601cc157b7cb", "beba8644-72bb-4d87-ac62-cfa300102bf5", "Admin", "ADMIN" },
                    { "f0d8ab38-d012-49f2-a94f-2f157e1d7c98", "1236f38e-5a52-40cb-98ec-000498ea12db", "Super Admin", "SUPER ADMIN" },
                    { "674c3f77-2c60-41e7-9b9c-625cbbf4fbe5", "de1b369e-cabe-4d4a-a8f0-9a210b374fef", "Advertising Admin", "ADVERTISING ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4f6d9d68-7eeb-4c3f-9234-1e3c9d8a85f3", 0, "599a156a-0e45-4fcc-9db5-66b28165d670", "superadmin@cinematickets.com", true, "Nahla", "Ahmed", false, null, "SUPERADMIN@CINEMATICKETS.COM", "SUPERADMIN@CINEMATICKETS.COM", "AQAAAAEAACcQAAAAEAq7ttMHsAHBT1ahTo8QuInVWkdAqrJJg7OnBZeDfRweL9OpUZlDuEN/ukrn8sjzKA==", null, false, "3483cb8e-aae4-4244-bb66-4080a6529567", false, "superadmin@cinematickets.com" },
                    { "94d81c07-9f25-4b5f-83c2-e7a623cc65dc", 0, "2f2465eb-2bdb-4811-9605-40afeee5f59f", "Ali_Mohamed@yahoo.com", true, "Ali", "Mohamed", false, null, "ALI_MOHAMED@YAHOO.COM", "ALI_MOHAMED@YAHOO.COM", "AQAAAAEAACcQAAAAEAdWFLYrNFOeQFNdab3rEWdEA9oH1aJtLMpJcBEY+ftokmW+wRmiHUI+KKM9jeJ1Zg==", null, false, "f4745873-8fce-4fa6-baaa-e392ee475edd", false, "Ali_Mohamed@yahoo.com" },
                    { "6e4f2ed9-a2e1-4151-b8aa-9888d39c7b65", 0, "df9dcc42-5d51-4583-97fb-cb1f4018ccaa", "advertising@cinematickets.com", true, "Hala", "Ali", false, null, "ADVERTISING@CINEMATICKETS.COM", "ADVERTISING@CINEMATICKETS.COM", "AQAAAAEAACcQAAAAEPGwXN4K9YtKf+83vwkgVIdpzC2bafiy7+Vtw4yRJJp9pVs//pT95nnJLEHKLegjZg==", null, false, "38226a54-79e6-4530-bfd0-9aad78301c87", false, "advertising@cinematickets.com" },
                    { "0bd0715e-6767-46a5-8300-7c99bb8198d6", 0, "0da541f9-158c-44e6-a6e5-a9111460f49f", "admin@cinematickets.com", true, "Mohamed", "Ahmed", false, null, "ADMIN@CINEMATICKETS.COM", "ADMIN@CINEMATICKETS.COM", "AQAAAAEAACcQAAAAEAAouZpIT/kW7aoQEsenpm2IYYliu3HyC+XCwY8BSd7xZtrwcSdrO2gdtAWVnjm8XQ==", null, false, "b1bcbd87-7635-4a1b-a443-378265abf1dc", false, "admin@cinematickets.com" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName" },
                values: new object[,]
                {
                    { 1, "Egypt" },
                    { 10, " Mexico" },
                    { 9, "Spain" },
                    { 2, "USA" },
                    { 7, "Turkey" },
                    { 6, "India" },
                    { 3, "UK" },
                    { 4, "Canada" },
                    { 5, "France" },
                    { 8, "Ireland" }
                });

            migrationBuilder.InsertData(
                table: "Crews_Roles",
                columns: new[] { "Id", "CrewRoleName" },
                values: new object[,]
                {
                    { 1, "Actor" },
                    { 2, "Writer" },
                    { 3, "Director" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 18, "Science Fiction" },
                    { 17, "Family" },
                    { 16, "Adventure" },
                    { 15, "Animation" },
                    { 14, "Crime" },
                    { 13, "Thriller" },
                    { 12, "Historical" },
                    { 11, "Adventure" },
                    { 9, "War" },
                    { 7, "Romance" },
                    { 6, "Mystery" },
                    { 5, "Horror" },
                    { 4, "Fantasy" },
                    { 3, "Drama" },
                    { 2, "Comedy" },
                    { 1, "Action" },
                    { 10, "Spy" },
                    { 8, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageName" },
                values: new object[,]
                {
                    { 1, "Arabic" },
                    { 2, "English" },
                    { 3, "French" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageName" },
                values: new object[,]
                {
                    { 4, "Turkish" },
                    { 5, "Hindi" }
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "IsActive", "MovieId", "SlideDetails", "SlideImageURL", "SlideTitle" },
                values: new object[,]
                {
                    { 5, true, 5, "As the 13-year-old girl Mei Lee deals with the chaos of adolescence, she finds herself facing a much bigger problem when she discovers that she turns into a giant red panda whenever she gets too excited.", "../images/slides/slide5.jpg", "Turning Red" },
                    { 3, true, 3, "The events revolve around Yahya, a soccer player, and his wife Misk, a gynecologist. The couple has been trying for many years to have a baby, but they are surprised when it happens at the wrong time, upon which they encounter many comic situations.", "../images/slides/slide3.jpg", "Hamel El Lakab" },
                    { 1, true, 0, "The website used by over 10 theatres in Egypt. website includes online ticketing systems, seat reservation software, display signage, Food and Beverages and more. Enjoy booking and watching best movies.", "../images/slides/slide1.jpg", "Cinema Tickets" },
                    { 2, true, 2, "The fortune hunter Nathan Drake embarks on a dangerous mission, as he joins forces with Victor Sullivan in order to find a priceless treasure and also tracking down Nathan’s long-lost brother.", "../images/slides/slide2.jpg", "Uncharted" },
                    { 4, true, 6, "As he spends his vacation aboard a cruise ship on the Nile in Egypt, Detective Hercule Poirot tries to find a murderer after a young heiress is found dead.", "../images/slides/slide4.jpg", "Death on the Nile" }
                });

            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "TheaterDetails", "TheaterImageURL", "TheaterLocation", "TheaterName" },
                values: new object[,]
                {
                    { 1, "* The IMAX screen is one of Americana Plaza theater's diverse screens./* For 3D films, the ticket price does not include the price of the 3D glasses. The 3D glasses are available for a rental price of EGP 10.", "../images/theaters/IMAX.jpg", "Americana Plaza Mall, Sheikh Zayed, 6th of October City", "IMAX, Americana Mall Cinema" },
                    { 10, "For 3D films, the ticket price does not include the price of the 3D glasses.", "../images/theaters/GrandHurghada.jpg", "city center Mall، Qesm Hurghada, Red Sea Governorate ", "Grand Hurghada Cinema" },
                    { 9, "", "../images/theaters/GrandHyatt.jpg", "inside the Grand Nile Tower Hotel, Corniche El Nil , Garden City", "Grand Hyatt Cinema" },
                    { 2, "* For 3D films, the ticket price does not include the price of the 3D glasses./* It is not allowed to take children under 4 years of age into the theater.", "../images/theaters/Point90.jpg", "90Street, Point90 Mall in front of AUC gate 5 , New Cairo", "Point 90 Cinema" },
                    { 7, "* For 3D films, the ticket price does not include the price of the 3D glasses./* There are two distinctive CineComfort screens in Americana Plaza theater, and each one hosts 66 luxury seats.", "../images/theaters/CineComfort.jpg", "Americana Plaza Mall, Sheikh Zayed , 6th of October City", "Plaza CineComfort Cinema" },
                    { 6, "* For 3D films, the ticket price does not include the price of the 3D glasses./* It is not allowed to take children under 12 years of age into the theater./* The theater has Dolby Atmos sound technology which fills the theater with audio from the sides, the back end and above head. The sound flows all around the audience in sync with the action on the screen. /* The theater has a limited number of luxurious, comfortable seats./* Please note that the seats are unmoving not movable", "../images/theaters/SunCity.jpg", "Behind Masaken Sheraton, Sun City Mall , Heliopolis", "Sun City Cinema" },
                    { 3, "For 3D films, the ticket price does not include the price of the 3D glasses.", "../images/theaters/PlazaCinemas.png", "Americana Plaza Mall, Sheikh Zayed , 6th of October City", "Plaza Cinemas, Americana Mall Cinema" },
                    { 4, "* For 3D films, the ticket price does not include the price of the 3D glasses./* It is not allowed to take children under 4 years of age into the theater.", "../images/theaters/ArkanCinema.png", "26th of July Corridor - Arkan Plaza Mall , 6th of October City", "Arkan Cinema" },
                    { 5, "For 3D films, the ticket price does not include the price of the 3D glasses.", "../images/theaters/GalaxyElMaadi.jpg", "Osman Towers, Corniche El Nil , Maadi", "Galaxy ElMaadi Cinema" },
                    { 8, "* For 3D films, the ticket price does not include the price of the 3D glasses./* This theater contains Balcony Level seats for a ticket price of EGP 150./* showing the Cairo International Film Festival", "../images/theaters/ZamalekCinema.jpg", "13Shagaret El Dor St., Zamalek - Cairo ", "Zamalek Cinema" }
                });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "MovieTime" },
                values: new object[,]
                {
                    { 19, new TimeSpan(0, 18, 0, 0, 0) },
                    { 20, new TimeSpan(0, 18, 30, 0, 0) },
                    { 21, new TimeSpan(0, 19, 0, 0, 0) },
                    { 22, new TimeSpan(0, 19, 30, 0, 0) },
                    { 23, new TimeSpan(0, 20, 0, 0, 0) },
                    { 25, new TimeSpan(0, 21, 0, 0, 0) },
                    { 26, new TimeSpan(0, 21, 30, 0, 0) },
                    { 27, new TimeSpan(0, 22, 0, 0, 0) },
                    { 28, new TimeSpan(0, 22, 30, 0, 0) },
                    { 29, new TimeSpan(0, 23, 0, 0, 0) },
                    { 30, new TimeSpan(0, 23, 30, 0, 0) },
                    { 24, new TimeSpan(0, 20, 30, 0, 0) },
                    { 18, new TimeSpan(0, 17, 30, 0, 0) },
                    { 16, new TimeSpan(0, 16, 30, 0, 0) },
                    { 15, new TimeSpan(0, 16, 0, 0, 0) },
                    { 14, new TimeSpan(0, 15, 30, 0, 0) },
                    { 13, new TimeSpan(0, 15, 0, 0, 0) },
                    { 11, new TimeSpan(0, 14, 0, 0, 0) },
                    { 10, new TimeSpan(0, 13, 30, 0, 0) },
                    { 9, new TimeSpan(0, 13, 0, 0, 0) },
                    { 8, new TimeSpan(0, 12, 30, 0, 0) },
                    { 7, new TimeSpan(0, 12, 0, 0, 0) },
                    { 6, new TimeSpan(0, 11, 30, 0, 0) },
                    { 5, new TimeSpan(0, 11, 0, 0, 0) },
                    { 4, new TimeSpan(0, 10, 30, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "MovieTime" },
                values: new object[,]
                {
                    { 3, new TimeSpan(0, 10, 0, 0, 0) },
                    { 2, new TimeSpan(0, 0, 30, 0, 0) },
                    { 1, new TimeSpan(0, 0, 0, 0, 0) },
                    { 17, new TimeSpan(0, 17, 0, 0, 0) },
                    { 12, new TimeSpan(0, 14, 30, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b176ab1c-055e-4a7f-99ce-9d16fd033d1f", "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { "c0d45dad-ba1d-4efe-b1ab-601cc157b7cb", "0bd0715e-6767-46a5-8300-7c99bb8198d6" },
                    { "f0d8ab38-d012-49f2-a94f-2f157e1d7c98", "4f6d9d68-7eeb-4c3f-9234-1e3c9d8a85f3" },
                    { "674c3f77-2c60-41e7-9b9c-625cbbf4fbe5", "6e4f2ed9-a2e1-4151-b8aa-9888d39c7b65" }
                });

            migrationBuilder.InsertData(
                table: "Crew",
                columns: new[] { "Id", "CrewBiography", "CrewDateofBirth", "CrewImageURL", "CrewName", "CrewRoleId", "NationalityId" },
                values: new object[,]
                {
                    { 9, "Joseph Aaron Carnahan is an American independent (filmmaker) and actor. He was born on the 9th of May, 1969 in the state of Delaware.Joseph grew up in Detroit Michigan and Fairfield, California. He came to public attention in 1998 when he received critical acclaim for “Blood, Guts, Bullets and Octane”. Thereafter he has worked on several films including “Narc” and, more recently, “The A-Team”.", new DateTime(1969, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/JoeCarnahan1.jpg", "Joe Carnahan", 2, 2 },
                    { 14, "Egyptian writer who has written several works including the film Ocean 14 (2015), starring the stars of Teatro Misr.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/IhabBlaibel1.jpg", "Ihab Blaibel", 2, 1 },
                    { 20, "J.P. Davis is an actor and writer, known for The Plane, Fighting Tommy Riley (2004) and The Contractor (2022).", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/Davis1.jpg", "J.P. Davis", 2, 2 },
                    { 24, "Sherif is an Egyptian director, screenwriter and producer. He graduated from the Higher Institute for Cinema in 1982 and he is the son of director Sa’ad ‘Arafa in addition to being an elder brother to director ‘Amr ‘Arafa. Sherif began his cinema career in 1987 when he directed the film The Dwarfs are Coming. He then directed the film The Second Degree starring Soa’ad Hosny and Ahmed Zakky. He was the first to notice the talents of many stars including: Mohamed Sa’ad, Ahmed Helmy, Mohamed Heneidy, Kareem ‘Abd Al ‘Azeez, Ahmed Makky. The director has worked with major stars from the outset of his career, like of Soa’ad Hosny, Ahmed Zakky and Adel Imam.  Sherif has also produced several films and television productions such as the film “Halim” and the TV series Tamer and Shawqqiyah, Critical Moments, and the program The People and Myself through his private production company Partner Pro. Moreover Sherif has also directed several TV commercials for well known products such as Pepsi and Chipsy.  Sherif Arafa has directed several films that were milestones in the history of Egyptian cinema, like The Birds of Darkness, The Principal and Mafia.", new DateTime(1960, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/SherifArafa1.jpg", "Sherif Arafa", 2, 1 },
                    { 28, "One of the most famous English writers of all time. She was born on September 15, 1890 in Torquay, England. She specialized in writing detective novels. She published her first novel in 1920, which was titled The Mysterious Affair at Styles. Many of her novels have been adapted into serials and films in many countries. She created many characters that she used in most of her works. Among her works are: And Then There Were None, Murder on the Orient Express and A Night of Terror. She died on January 12, 1976 in Oxfordshire.", new DateTime(1890, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/AgathaChristie1.jpg", "Agatha Christie", 2, 3 },
                    { 33, "Chris Fedak was born on August 20, 1975. He served as producer and writer on the series Chuck (2007-2012), Forever (2014-2015), and DC's Legends of Tomorrow (2016).", new DateTime(1975, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/ChrisFedak1.jpg", "Chris Fedak", 2, 2 },
                    { 10, "Ruben Fleischer is an American director who was born on October 31, 1974 in Washington, USA. Fleischer graduated from Wesleyan University, where he studied History before moving to San Francisco. Ruben is best known for his action-driven movies, and his work has varied between directing, wring and producing. In 2001, he wrote and the directed the short movie (The Girls Guitar Club).", new DateTime(1974, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/RubenFleischer1.jpg", "Ruben Fleischer", 3, 2 },
                    { 5, "Peter Craig is an American novelist and screenwriter, known for his dark comedy and exploitation of father-child relationships. He is best known for writing the action/crime film The Town, and also The Hunger Games: Mockingjay – Parts 1 and 2.", new DateTime(1969, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/PeterCraig1.jpg", "Peter Craig", 2, 2 },
                    { 15, "Egyptian director who directed programs ad series such as The Franks (2015) starring Hisham Maged, Chico, and Ahmed Fahmy ad the series Ending with Style and Repel Response. He also does works in editing and sound mixing.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/HeshamFathy1.jpg", "Hesham Fathy", 3, 1 },
                    { 19, "Egyptian director and writer born on January 28, 1972. He wrote and directed the movie The Nile Hilton Incident (2017).", new DateTime(1972, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/TarikSaleh1.jpg", "Tarik Saleh", 3, 2 },
                    { 25, "Sherif is an Egyptian director, screenwriter and producer. He graduated from the Higher Institute for Cinema in 1982 and he is the son of director Sa’ad ‘Arafa in addition to being an elder brother to director ‘Amr ‘Arafa. Sherif began his cinema career in 1987 when he directed the film The Dwarfs are Coming. He then directed the film The Second Degree starring Soa’ad Hosny and Ahmed Zakky. He was the first to notice the talents of many stars including: Mohamed Sa’ad, Ahmed Helmy, Mohamed Heneidy, Kareem ‘Abd Al ‘Azeez, Ahmed Makky. The director has worked with major stars from the outset of his career, like of Soa’ad Hosny, Ahmed Zakky and Adel Imam.  Sherif has also produced several films and television productions such as the film “Halim” and the TV series Tamer and Shawqqiyah, Critical Moments, and the program The People and Myself through his private production company Partner Pro. Moreover Sherif has also directed several TV commercials for well known products such as Pepsi and Chipsy.  Sherif Arafa has directed several films that were milestones in the history of Egyptian cinema, like The Birds of Darkness, The Principal and Mafia.", new DateTime(1960, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/SherifArafa1.jpg", "Sherif Arafa", 3, 1 },
                    { 29, "He is an actor, writer, director, and producer from Northern Ireland, born on December 10, 1960. He started his acting career in Chariots of Fire (1981). He's known for directing and starring in several film adaptations of William Shakespeare's plays, including Henry V, Much Ado About Nothing, and Hamlet. He was nominated for an Academy Award 5 times.", new DateTime(1960, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/KennethBranagh1.jpg", "Kenneth Branagh", 3, 3 },
                    { 32, "Michael Benjamin Bay is an American film director and producer. He got his start in the film industry as an intern on the location of George Lucas' 'Raiders of the Lost Ark,' where he used to file storyboards. Upon watching the film in the theater, he was so impressed by the experience that he decided to become a film director. After directing a series of highly successful music videos, Bay was picked by producer Jerry Bruckheimer to direct 'Bad Boys' (1994), which was his first feature film. .", new DateTime(1965, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/MichaelBay1.jpg", "Michael Bay", 3, 2 },
                    { 4, "Matthew George Reeves is an American director, screenwriter and producer born on 27 April 1966 in Rockville Center, New York. His passion for filmmaking began at the early age of 8.  His most notable works include Cloverfield (2008), and Dawn of the Planet of the Apes (2014).  He won a Fright Meter Award for Best Screenplay for Let Me In (2010).", new DateTime(1966, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/MattReeves1.jpg", "Matt Reeves", 3, 2 },
                    { 34, "Jake Gyllenhall’s father is the director Steven Gyllenhall. His mother, (Funir) is a producer and (screenwriter). His sister is the actress Maggie Gyllenhall. Jake Gyllenhall’s first acting experience occurred at the age of eleven where he acted in the 1991 film (“City Slickers”). Thereafter, Jake would assume roles in several (television and cinematic productions).However his work (in theater) has given him more experience and (exposure) especially since he has performed on Broadway.", new DateTime(1980, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/JakeGyllenhaal1.jpg", "Jake Gyllenhaal", 1, 2 },
                    { 1, "Robert Thomas Pattinson is an English actor, (filmmaker), model and musician. He was born on the 13th of May, 1986 in London, England. Pattinson’s mother, Clare, worked at a modeling agency while his father, Richard, imported vintage cars from the United States.", new DateTime(1986, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/RobertPattinson1.jpg", "Robert Pattinson", 1, 3 },
                    { 30, "The Mexican actress and singer was born on January 30th, 1990 in New Mexico. After the success of her show, True Love, in 2012, she decided to take her acting career to Hollywood, even if it means starting from scratch. Despite the rough start, her dreams started coming true in the US as she released several albums. She is best known for From Dusk Till Dawn: The Series (2014), Jem and the Holograms (2015), and Baby Driver (2017).", new DateTime(1990, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/EizaGonzález1.jpg", "Eiza González", 1, 10 },
                    { 31, "An American actor, born in New Orleans, Louisiana. He is best known for his work in the series The Get Down (2016), and the movies Sidney Hall (2017), Baywatch (2017), and Aquaman (2018).", new DateTime(1986, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/YahyaAbdulMateen1.jpg", "Yahya Abdul-Mateen", 1, 2 },
                    { 6, "He lives with his parents and his three younger brothers. Holland attended Donhead Prep School. After many years of training and being told he’s talented, he debuted in “Billy Elliot: The Musical” where he played Michael, Billy’s best friend. After the show, he got fantastic reviews on his acting and dancing skills. On the fifth anniversary of “Billy Elliot: The Musical” he and fellow crews who played in the musical were invited to meet the Prime Minister Gordon Brown. When Elton John watched one of his plays, he was amazed by his acting abilities and said that Holland is “astonishing”. On the 29th of May 2015 he finished playing in “Billy Elliot: The Musical” after many years of acting greatly in it.", new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/TomHolland1.jpg", "Tom Holland", 1, 3 },
                    { 3, "Colin Farrell is an Irish actor, born in 1976. He attended a school to learn acting but was expelled from it. Afterwards, he started his artistic career by playing several small roles in several TV series. In 2000, he got his first starring role in the movie Land of the Tiger. His most important roles are The Killing of a Sacred Deer movie [2017], The Epic movie [2013], The Winter's Tale movie [2014], and Saving Mr. Banks movie [2013].", new DateTime(1976, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/ColinFarrell1.jpg", "Colin Farrell", 1, 8 },
                    { 7, "Mark Wahlberg is an American actor, film and television producer, and former rapper. He was born in a poor, working-class neighborhood in Boston on June 5, 1971, one of nine children. He first rose to fame as the strapping and often shirtless Marky Mark, frontman of “Marky Mark and the Funky Bunch. He was named No. 1 on VH1's “40 Hottest Hotties of the 90s.” He has executive produced hit TV shows like HBO's “Entourage” (which is widely understood to be based on his own Hollywood story), “Boardwalk Empire” and “How to Make It in America.” As an actor, Wahlberg gained attention for his impressive performances in “Three Kings” (1999), “The Italian Job” (2003) and “I Heart Huckabees” (2004). His work in “The Departed” (2006) won him Oscar and Golden Globe nominations. He also won a National Society of Film Critics Award for Best Supporting Actor. ", new DateTime(1971, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/MarkWahlberg1.jpg", "Mark Wahlberg", 1, 2 },
                    { 8, "Antonio Banderas is a Spanish actor and director. He was born on 1960 in Malaga.His father worked as a police officer, while his mother was a teacher. During his childhood, Banderas dreamt of becoming a successful football player, but at the age of 14 he broke his leg, and started attending drama and acting classes. In the early 1980s he started acting on stage in small Spanish theaters. By the beginning of the 1990s Banderas moved to Hollywood, where he earned his breakthrough and rose to become one of Hollywood's most successful and highest grossing stars. His most famous films include: Assasins (1995), The Mask of Zorro (1998), The 13th Warrior (1999), Frida (2002), The Legend of Zorro (2005), and The Skin I Live In (2011). Banderas married twice: first he married actress Anna Lisa in 1987, and they filed for divorce in 1996. He then married actress Melanie Griffith. ", new DateTime(1960, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/AntonioBanderas1.jpg", "Antonio Banderas", 1, 9 },
                    { 11, "An actor and a script writer, graduated from School of Engineering Cairo University. During university, he created a production company with his friends called “Tamr Hendi” that produced movies that ridiculed famous Egyptian movies. Most famous was “Men who do not know the impossible” This work attracted the attention of Mohamed Hefzy who at the time was attempting production and he produced their first series “Afeesh wa Tashbeeh” which portrayed one of the Egyptian classics in a cynical way in each episode.Hefzy then produced for them the movie “Coded Paper” which was a big hit in the box office.Hesham acted and wrote the script for this movie which familiarized his face to the audience.He won the award of the “Best New Faces” for the year 2008, in participation with his mates Ahmed Sabry and Chico.", new DateTime(1980, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/HeshamMaged1.jpg", "Hesham Maged", 1, 1 },
                    { 12, "An Egyptian actress and TV presenter, born in Cairo in 1985. She studied at the Faculty of Mass Communication at October 6 University. After graduating, Dina joined acting workshops, and she also enrolled in enunciation workshops. Dina became famous through the program Windows that she presented on Dream Channel in 2006, and she also presented the program Prime Youth in 2011. Dina started acting when she entered a competition to choose new crews in order to participate in the series Special Screening, in which she appeared as herself. After that, she participated in the series Girls' Tales, Third Party and Underground. Dina made her film debut in The Party (2013).", new DateTime(1985, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/DinaElSherbiny1.jpg", "Dina El Sherbiny", 1, 1 },
                    { 13, "Mohamed Sallam is an Egyptian actor. He graduated from the faculty of commerce in Cairo, where he started acting on stage. His film debut was in the 2006 film 'El Rahina' (The Hostage). He then starred in the hit play 'Ahwa Sada' (Black Coffee) in 2009. He then went on to appear in numerous television series, including 'El Kebir Awy', and films including 'Captain Egypt'.", new DateTime(1983, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/MohamedSallam1.jpg", "Mohamed Sallam", 1, 1 },
                    { 2, "Zoë Kravitz is an American actress who was born on December 01, 1988 in Los Angeles, California to actress, Lisa Bonet, and Lenny Kravitz, a folk rock musician and actor. Zoë discovered her passion for acting at a young age and started taking acting classes while still at school. Kravitz participated in two movies during her high school studies, which are: (No Reservations) and (The Brave One) in 2007. She later on participated in (Mad Max: Fury Road) in 2015, (Big Little Lies) in 2017, and (Fantastic Beasts: The Crimes of Grindelwald) in 2018.", new DateTime(1988, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/ZoëKravitz1.jpg", "Zoë Kravitz", 1, 2 },
                    { 17, "An ​​American actor born on August 26, 1980 in Los Angeles, California. He holds a degree in English from the University of California, Berkeley, then studied acting at the University of Leeds in England. He made his film debut in The Princess Diaries 2: Royal Engagement (2004), after which he starred in many films, most notably Unstoppable (2010),  Wonder Woman (2017), and Star Trek reboot film series (2009–2016).", new DateTime(1980, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/ChrisPine1.jpg", "Chris Pine", 1, 2 },
                    { 27, "Armie Hammer was  born in Santa Monica, California. His mother is a former bank loan officer, his father owns several businesses, and his great-grandfather was oil tycoon and philanthropist Armand Hammer. He lived with his family for five years in the Cayman Islands when he was seven, and then settled back in Los Angeles to pursue acting. He began his acting career with small parts in TV series including: Veronica Mars and Gossip Girl. His first leading role was in Billy: The Early Years in 2008.  His breakthrough film role was in David Fincher's The Social Network in 2010.", new DateTime(1986, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/ArmieHammer1.jpg", "Armie Hammer", 1, 2 },
                    { 16, "She is an American actress, born on October 19, 1982 in Pittsburgh, Pennsylvania. She started acting on the local theaters of Pittsburgh, especially in Shakespearean plays, like A Midsummer Night's Dream.  She graduated from the Juilliard School in 2004, where she studied acting.  She's known for Walk of Shame (2014), The Box (2009) and the comedy series Community (2009-2015).", new DateTime(1982, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/GillianJacobs1.jpg", "Gillian Jacobs", 1, 2 },
                    { 23, "Maged El Kedwany is an Egyptian film and television actor. In 1967, he was born in Shubra in Cairo, but lived in Kuwait up until age 18. He began his professional career while studying design at the Faculty of Fine Arts. He began acting in a number of amateur plays, which led to him being cast in various TV shows like 'Qanfad' (Hedgehog) and 'Nahnu al Nazre el-Shook.' He's worked on dozens of films, among them are some of the most well-known films of the 1990s, like 'Afareet el-Asphalt' (Asphalt Ghosts) in 1996 and 'Saidi fe Gaea al-Amrikeya' (Saidi at the American University in Cairo) in 1998. His other films include 'Harameya Ki-Gi-To' (Ki-Gi-To Thieves), 'Harameya fe Thailand' (Thieves in Thailand), 'Al-Ragel al-Abyad al-Motawast' (Average White Guy), and 'Khaly min Kolesterol' (Cholesterol-Free). In 2012, he appeared in two high-profile movies, 'Hafla Montasif al-Leil' (Midnight Party) and 'Saaa we Nos' (Hour and a Half).", new DateTime(1976, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/MagedElKedwany1.jpg", "Maged El Kedwany", 1, 1 },
                    { 26, "Tom Bateman is an English actor, born in Oxford in a working-class family. He has a twin brother named Merlin. He studied drama at the London Academy of Music and Dramatic Art. He began his acting career in theatre joining Kenneth Branagh's company in The Winter's Tale. His starred in various TV series including: Da Vinci's Demons, Jekyll and Hyde and Beecham House.  His film roles include: Murder on the Orient Express (2017) and Cold Pursuit (2019). ", new DateTime(1989, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/TomBateman1.jpg", "Tom Bateman", 1, 3 },
                    { 18, "He is an American actor, born on December 21, 1966 in London, England. He got his first role in Max Dugan Returns (1983). He is best known for his role in the Canadian film, The Bay Boy (1984), which won him a Genie Award as best actor. He starred in Amazing Stories (1985) and Trapped in Silence (1986). ", new DateTime(1966, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/KieferSutherland1.jpg", "Kiefer Sutherland", 1, 2 },
                    { 21, "Ahmed Ezz was born on July 3, 1971. He began a career in modeling after graduating from the Faculty of Arts from the English division. Ezz began working as a model in the hopes that it would later give him access to acting jobs. However the venture was not successful. After some time, Ezz met director Enas Al Daghdaghy who gave him a minor role in the film “Kallam Al Layl” (Night Talk) in 1999. The director would later give him the lead role in “Muzikirat Murahiqa” (Memoirs of a Teenager) in 2001. ", new DateTime(1971, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/AhmadEzz1.jpg", "Ahmad Ezz", 1, 1 },
                    { 22, "Menna Shalaby is one of the brightest stars in the younger generation of Egyptian actors. She was born on July 24, 1981 in Cairo. She is the daughter of the famous dancer and performer Zizi Mustafa. Shalaby displayed a passion for performing from a very early age, no doubt due to the exposure to the industry her mother's fame provided. She would often sit in front of the mirror and pretend to be her famous mother, and also fake being sick to get out of going to school, which her mother declared was also acting. Menna made her film debut in 'Al Saher' (The Magician) as Nour in 2001. She next scored a leading role beside Layla Elwy in 'Baheb El Seema' (2004). ", new DateTime(1982, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "../images/crews/MennaShalaby1.jpg", "Menna Shalaby", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CountryId", "LanguageId", "MovieDescription", "MovieImageURL", "MovieName", "MovieRate", "MovieReleaseDate", "MovieRunningTime" },
                values: new object[,]
                {
                    { 3, 1, 1, "The events revolve around Yahya, a soccer player, and his wife Misk, a gynecologist. The couple has been trying for many years to have a baby, but they are surprised when it happens at the wrong time, upon which they encounter many comic situations.", "../images/movies/HamelElLakab1.jpg", "Hamel El Lakab", "+12", new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "120 minutes" },
                    { 16, 2, 2, "As a war veteran attempts to raise money for his wife's surgery, his adoptive brother talks him into pulling a heist with him, but when their plan miscarries, they end up stealing an ambulance and taking a fatally wounded officer and an EMT as hostages.", "../images/movies/Ambulance1.jpg", "Ambulance", "+12", new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), " 120 minutes" },
                    { 15, 2, 2, "While in Panama for an arms deal, the former marine  James Becker gets more than he bargained for as the US launches its invasion on Panama. As the political atmosphere turns turbulent, Becker finds his mission becoming much more complicated as his very survival hangs on the line.", "../images/movies/DoctorStrange1.jpg", "Doctor Strange 2", "+12", new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), " 120 minutes" },
                    { 14, 2, 2, "While in Panama for an arms deal, the former marine  James Becker gets more than he bargained for as the US launches its invasion on Panama. As the political atmosphere turns turbulent, Becker finds his mission becoming much more complicated as his very survival hangs on the line.", "../images/movies/Panama1.jpg", "Panama", "+16", new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), " 156 minutes" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CountryId", "LanguageId", "MovieDescription", "MovieImageURL", "MovieName", "MovieRate", "MovieReleaseDate", "MovieRunningTime" },
                values: new object[,]
                {
                    { 13, 3, 2, "After being tasked by Professor Albus Dumbledore with putting a halt to Gellert Grindelwald's evil plans, Newt Scamander sets out with a fearless band of wizards and witches on a mission fraught with danger to take on the evil Grindelwald.", "../images/movies/TheSecretsofDumbledore1.jpg", "The Secrets of Dumbledore", "+16", new DateTime(2023, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "192 minutes" },
                    { 12, 2, 2, "As Lex Luthor kidnaps the Justice League, Krypto, Superman's dog, sets out to save his buddy by bringing together a motley crew of shelter animals, each of whom gets a superpower, to take on the villain and set the superheroes free.", "../images/movies/SuperPets1.jpg", "DC League of Super-Pets", "All Ages", new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "102 minutes" },
                    { 7, 1, 1, "The story follows a simple family whose young son, Zeko, wins the opportunity to participate in a contest for Egypt's smartest child. As they set out to attend the contest, many paradoxes happen to them during the two-day trip", "../images/movies/MenAglZeko1.jpg", "Men Agl Zeko", "All Ages", new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "95 minutes" },
                    { 9, 2, 2, "As Spider-Man's identity is revealed and he is no longer able to keep Peter Parker's life out of that of Spider-Man, he turns to Doctor Strange for help, but things take a dangerous turn when he realizes what it takes to be who he is.", "../images/movies/SpiderMan1.jpg", "Spider-Man: No Way Home", "All Ages", new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "150 minutes" },
                    { 8, 1, 1, "When a violent criminal breaks out from a psychiatric hospital, the concerned authorities discover his connection to a number of prior crimes involving prominent figures.", "../images/movies/ElGareema1.jpg", "El Gareema", "+16", new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "125 minutes" },
                    { 11, 3, 2, "After leaving the service for some time ago, MI6 agent James Bond is thrust back into action after his old CIA friend Felix Leiter recruits him to find a missing scientist which will send him into a dangerous path against a mysterious villain armed with lethal new technology.", "../images/movies/NoTimetoDie1.jpg", "No Time to Die", "+12", new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "174 minutes" },
                    { 2, 2, 2, "The fortune hunter Nathan Drake embarks on a dangerous mission, as he joins forces with Victor Sullivan in order to find a priceless treasure and also tracking down Nathan’s long-lost brother.", "../images/movies/Uncharted1.jpg", "Uncharted", "+12", new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "116 minutes" },
                    { 1, 2, 2, "In his second year as the protector of Gotham City, Bruce Wayne, AKA Batman, finds himself facing off against the Penguin and the Riddler, in addition to other villains who plague Gotham.", "../images/movies/Batman1.jpg", "The Batman", "+12", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "175 minutes" },
                    { 4, 2, 2, "After being discharged from the United States Army Special Forces, James Harper  joins a private underground military organization, but as soon as his first mission goes wrong, he finds himself fighting for his life to avoid a perilous conspiracy.", "../images/movies/Contractor1.jpg", "The Contractor", "+16", new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "103 minutes" },
                    { 5, 2, 2, "As the 13-year-old girl Mei Lee deals with the chaos of adolescence, she finds herself facing a much bigger problem when she discovers that she turns into a giant red panda whenever she gets too excited.", "../images/movies/TurningRed1.jpg", "Turning Red", "All Ages", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "100 minutes" },
                    { 6, 3, 2, "As he spends his vacation aboard a cruise ship on the Nile in Egypt, Detective Hercule Poirot tries to find a murderer after a young heiress is found dead.", "../images/movies/DeathontheNile1.jpg", "Death on the Nile", "+12", new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "127 minutes" }
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "ScreenName", "TheaterId" },
                values: new object[,]
                {
                    { 34, "Screen 2", 6 },
                    { 35, "Screen 3", 6 },
                    { 36, "Screen 4", 6 },
                    { 37, "Screen 5", 6 },
                    { 38, "Screen 6", 6 },
                    { 39, "Screen 7", 6 },
                    { 40, "Screen 8", 6 },
                    { 41, "Screen 9", 6 },
                    { 42, "Screen 10", 6 },
                    { 43, "Screen 11", 6 },
                    { 44, "Screen 12", 6 },
                    { 33, "Screen 1", 6 },
                    { 52, "Screen 1", 10 },
                    { 46, "CineComfort 1", 7 },
                    { 47, "CineComfort 2", 7 },
                    { 48, "Screen 1", 8 },
                    { 49, "Screen 2", 8 },
                    { 50, "Screen 1", 9 },
                    { 51, "Screen 2", 9 },
                    { 53, "Screen 2", 10 },
                    { 54, "Screen 3", 10 },
                    { 55, "Screen 4", 10 },
                    { 56, "Screen 5", 10 },
                    { 32, "VIP", 5 },
                    { 45, "VIP 3", 6 },
                    { 31, "Dine in", 5 },
                    { 16, "MX4D", 3 },
                    { 29, "Screen 7", 5 },
                    { 1, "IMax", 1 },
                    { 2, "Screen 1", 2 },
                    { 3, "Screen 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "ScreenName", "TheaterId" },
                values: new object[,]
                {
                    { 4, "Screen 3", 2 },
                    { 5, "Screen 4", 2 },
                    { 7, "Screen 6", 2 },
                    { 8, "MX4D", 2 },
                    { 9, "Screen 1", 3 },
                    { 10, "Screen 2", 3 },
                    { 11, "Screen 4", 3 },
                    { 12, "Screen 8", 3 },
                    { 13, "Screen 9", 3 },
                    { 30, "Screen 8", 5 },
                    { 14, "Screen 10", 3 },
                    { 17, "CIMA 1", 4 },
                    { 18, "CIMA 2", 4 },
                    { 19, "CIMA 3", 4 },
                    { 20, "CIMA 4", 4 },
                    { 21, "CIMA 5", 4 },
                    { 22, "CIMA 6", 4 },
                    { 23, "CIMA Plus", 4 },
                    { 24, "MAX CIMA", 4 },
                    { 25, "Screen 1", 5 },
                    { 26, "Screen 3", 5 },
                    { 27, "Screen 4", 5 },
                    { 28, "Screen 5", 5 },
                    { 15, "Screen 11", 3 },
                    { 6, "Screen 5", 2 }
                });

            migrationBuilder.InsertData(
                table: "Crew_Gallery",
                columns: new[] { "Id", "CrewId", "ImageURL" },
                values: new object[,]
                {
                    { 1, 1, "../images/crews/RobertPattinson1.jpg" },
                    { 41, 9, "../images/crews/JoeCarnahan2.jpg" },
                    { 40, 9, "../images/crews/JoeCarnahan1.jpg" },
                    { 21, 5, "../images/crews/PeterCraig1.jpg" },
                    { 129, 34, "../images/crews/JakeGyllenhaal6.jpg" },
                    { 128, 34, "../images/crews/JakeGyllenhaal5.jpg" },
                    { 127, 34, "../images/crews/JakeGyllenhaal4.jpg" },
                    { 126, 34, "../images/crews/JakeGyllenhaal3.jpg" },
                    { 125, 34, "../images/crews/JakeGyllenhaal2.jpg" },
                    { 124, 34, "../images/crews/JakeGyllenhaal1.jpg" },
                    { 115, 31, "../images/crews/YahyaAbdulMateen2.jpg" },
                    { 114, 31, "../images/crews/YahyaAbdulMateen1.jpg" },
                    { 113, 30, "../images/crews/EizaGonzález4.jpg" },
                    { 112, 30, "../images/crews/EizaGonzález3.jpg" },
                    { 42, 9, "../images/crews/JoeCarnahan3.jpg" },
                    { 111, 30, "../images/crews/EizaGonzález2.jpg" },
                    { 104, 27, "../images/crews/ArmieHammer4.jpg" },
                    { 103, 27, "../images/crews/ArmieHammer3.jpg" },
                    { 102, 27, "../images/crews/ArmieHammer2.jpg" },
                    { 101, 27, "../images/crews/ArmieHammer1.jpg" },
                    { 100, 26, "../images/crews/TomBateman3.jpg" },
                    { 99, 26, "../images/crews/TomBateman2.jpg" },
                    { 98, 26, "../images/crews/TomBateman1.jpg" },
                    { 93, 23, "../images/crews/MagedElKedwany3.jpg" },
                    { 92, 23, "../images/crews/MagedElKedwany2.jpg" },
                    { 91, 23, "../images/crews/MagedElKedwany1.jpg" },
                    { 90, 22, "../images/crews/MennaShalaby4.jpg" },
                    { 89, 22, "../images/crews/MennaShalaby3.jpg" },
                    { 88, 22, "../images/crews/MennaShalaby2.jpg" },
                    { 110, 30, "../images/crews/EizaGonzález1.jpg" },
                    { 63, 14, "../images/crews/IhabBlaibel1.jpg" },
                    { 80, 20, "../images/crews/Davis1.jpg" },
                    { 81, 20, "../images/crews/Davis2.jpg" },
                    { 119, 32, "../images/crews/MichaelBay4.jpg" },
                    { 118, 32, "../images/crews/MichaelBay3.jpg" },
                    { 117, 32, "../images/crews/MichaelBay2.jpg" },
                    { 116, 32, "../images/crews/MichaelBay1.jpg" },
                    { 109, 29, "../images/crews/KennethBranagh4.jpg" },
                    { 108, 29, "../images/crews/KennethBranagh3.jpg" },
                    { 106, 29, "../images/crews/KennethBranagh1.jpg" },
                    { 97, 25, "../images/crews/SherifArafa2.jpg" },
                    { 96, 25, "../images/crews/SherifArafa1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Crew_Gallery",
                columns: new[] { "Id", "CrewId", "ImageURL" },
                values: new object[,]
                {
                    { 79, 19, "../images/crews/TarikSaleh1.jpg" },
                    { 65, 15, "../images/crews/HeshamFathy2.jpg" },
                    { 64, 15, "../images/crews/HeshamFathy1.jpg" },
                    { 47, 10, "../images/crews/RubenFleischer5.jpg" },
                    { 46, 10, "../images/crews/RubenFleischer4.jpg" },
                    { 45, 10, "../images/crews/RubenFleischer3.jpg" },
                    { 44, 10, "../images/crews/RubenFleischer2.jpg" },
                    { 43, 10, "../images/crews/RubenFleischer1.jpg" },
                    { 20, 4, "../images/crews/MattReeves4.jpg" },
                    { 19, 4, "../images/crews/MattReeves3.jpg" },
                    { 18, 4, "../images/crews/MattReeves2.jpg" },
                    { 17, 4, "../images/crews/MattReeves1.jpg" },
                    { 123, 33, "../images/crews/ChrisFedak4.jpg" },
                    { 122, 33, "../images/crews/ChrisFedak3.jpg" },
                    { 121, 33, "../images/crews/ChrisFedak2.jpg" },
                    { 120, 33, "../images/crews/ChrisFedak1.jpg" },
                    { 105, 28, "../images/crews/AgathaChristie1.jpg" },
                    { 95, 24, "../images/crews/SherifArafa2.jpg" },
                    { 94, 24, "../images/crews/SherifArafa1.jpg" },
                    { 82, 20, "../images/crews/Davis3.jpg" },
                    { 87, 22, "../images/crews/MennaShalaby1.jpg" },
                    { 86, 21, "../images/crews/AhmadEzz4.jpg" },
                    { 107, 29, "../images/crews/KennethBranagh2.jpg" },
                    { 84, 21, "../images/crews/AhmadEzz2.jpg" },
                    { 35, 8, "../images/crews/AntonioBanderas4.jpg" },
                    { 34, 8, "../images/crews/AntonioBanderas3.jpg" },
                    { 33, 8, "../images/crews/AntonioBanderas2.jpg" },
                    { 32, 8, "../images/crews/AntonioBanderas1.jpg" },
                    { 31, 7, "../images/crews/MarkWahlberg7.jpg" },
                    { 30, 7, "../images/crews/MarkWahlberg6.jpg" },
                    { 29, 7, "../images/crews/MarkWahlberg5.jpg" },
                    { 28, 7, "../images/crews/MarkWahlberg4.jpg" },
                    { 27, 7, "../images/crews/MarkWahlberg3.jpg" },
                    { 26, 7, "../images/crews/MarkWahlberg2.jpg" },
                    { 25, 7, "../images/crews/MarkWahlberg1.jpg" },
                    { 24, 6, "../images/crews/TomHolland3.jpg" },
                    { 23, 6, "../images/crews/TomHolland2.jpg" },
                    { 22, 6, "../images/crews/TomHolland1.jpg" },
                    { 16, 3, "../images/crews/ColinFarrel6.jpg" },
                    { 15, 3, "../images/crews/ColinFarrel5.jpg" },
                    { 14, 3, "../images/crews/ColinFarrel4.jpg" },
                    { 13, 3, "../images/crews/ColinFarrel3.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Crew_Gallery",
                columns: new[] { "Id", "CrewId", "ImageURL" },
                values: new object[,]
                {
                    { 12, 3, "../images/crews/ColinFarrel2.jpg" },
                    { 11, 3, "../images/crews/ColinFarrell.jpg" },
                    { 10, 2, "../images/crews/ZoëKravitz4.jpg" },
                    { 9, 2, "../images/crews/ZoëKravitz3.jpg" },
                    { 8, 2, "../images/crews/ZoëKravitz2.jpg" },
                    { 7, 2, "../images/crews/ZoëKravitz1.jpg" },
                    { 6, 1, "../images/crews/RobertPattinson6.jpg" },
                    { 5, 1, "../images/crews/RobertPattinson5.jpg" },
                    { 3, 1, "../images/crews/RobertPattinson3.jpg" },
                    { 2, 1, "../images/crews/RobertPattinson2.jpg" },
                    { 85, 21, "../images/crews/AhmadEzz3.jpg" },
                    { 36, 8, "../images/crews/AntonioBanderas5.jpg" },
                    { 37, 8, "../images/crews/AntonioBanderas6.jpg" },
                    { 4, 1, "../images/crews/RobertPattinson4.jpg" },
                    { 39, 8, "../images/crews/AntonioBanderas8.jpg" },
                    { 83, 21, "../images/crews/AhmadEzz1.jpg" },
                    { 78, 18, "../images/crews/KieferSutherland4.jpg" },
                    { 77, 18, "../images/crews/KieferSutherland3.jpg" },
                    { 38, 8, "../images/crews/AntonioBanderas7.jpg" },
                    { 76, 18, "../images/crews/KieferSutherland2.jpg" },
                    { 75, 18, "../images/crews/KieferSutherland1.jpg" },
                    { 74, 17, "../images/crews/ChrisPine4.jpg" },
                    { 73, 17, "../images/crews/ChrisPine4.jpg" },
                    { 72, 17, "../images/crews/ChrisPine3.jpg" },
                    { 71, 17, "../images/crews/ChrisPine2.jpg" },
                    { 70, 17, "../images/crews/ChrisPine1.jpg" },
                    { 69, 16, "../images/crews/GillianJacobs4.jpg" },
                    { 67, 16, "../images/crews/GillianJacobs2.jpg" },
                    { 66, 16, "../images/crews/GillianJacobs1.jpg" },
                    { 68, 16, "../images/crews/GillianJacobs3.jpg" },
                    { 61, 13, "../images/crews/MohamedSallam3.jpg" },
                    { 48, 11, "../images/crews/HeshamMaged1.jpg" },
                    { 49, 11, "../images/crews/HeshamMaged2.jpg" },
                    { 50, 11, "../images/crews/HeshamMaged3.jpg" },
                    { 51, 11, "../images/crews/HeshamMaged4.jpg" },
                    { 52, 11, "../images/crews/HeshamMaged5.jpg" },
                    { 62, 13, "../images/crews/MohamedSallam4.jpg" },
                    { 54, 12, "../images/crews/DinaElSherbiny2.jpg" },
                    { 53, 12, "../images/crews/DinaElSherbiny1.jpg" },
                    { 55, 12, "../images/crews/DinaElSherbiny3.jpg" },
                    { 56, 12, "../images/crews/DinaElSherbiny4.jpg" },
                    { 57, 12, "../images/crews/DinaElSherbiny5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Crew_Gallery",
                columns: new[] { "Id", "CrewId", "ImageURL" },
                values: new object[,]
                {
                    { 58, 12, "../images/crews/DinaElSherbiny6.jpg" },
                    { 59, 13, "../images/crews/MohamedSallam1.jpg" },
                    { 60, 13, "../images/crews/MohamedSallam2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Crew_Movies",
                columns: new[] { "CrewId", "MovieId" },
                values: new object[,]
                {
                    { 25, 6 },
                    { 24, 8 },
                    { 25, 8 },
                    { 27, 6 },
                    { 26, 6 },
                    { 23, 8 },
                    { 34, 16 },
                    { 5, 1 },
                    { 32, 16 },
                    { 31, 16 },
                    { 30, 16 },
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 22, 8 },
                    { 33, 16 },
                    { 21, 8 },
                    { 8, 2 },
                    { 29, 6 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 28, 6 },
                    { 7, 2 },
                    { 15, 3 },
                    { 16, 4 },
                    { 17, 4 },
                    { 18, 4 },
                    { 19, 4 },
                    { 20, 4 },
                    { 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Genres_Movies",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 2, 5 },
                    { 15, 5 },
                    { 16, 5 },
                    { 17, 5 }
                });

            migrationBuilder.InsertData(
                table: "Genres_Movies",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 13, 4 },
                    { 2, 13 },
                    { 3, 6 },
                    { 14, 13 },
                    { 16, 11 },
                    { 16, 9 },
                    { 1, 9 },
                    { 18, 9 },
                    { 3, 12 },
                    { 11, 12 },
                    { 17, 13 },
                    { 12, 12 },
                    { 14, 12 },
                    { 6, 6 },
                    { 14, 6 },
                    { 18, 12 },
                    { 2, 12 },
                    { 4, 12 },
                    { 17, 12 },
                    { 11, 2 },
                    { 14, 8 },
                    { 14, 16 },
                    { 13, 11 },
                    { 2, 3 },
                    { 2, 7 },
                    { 8, 16 },
                    { 1, 16 },
                    { 3, 16 },
                    { 1, 8 },
                    { 13, 8 },
                    { 1, 2 },
                    { 1, 1 },
                    { 14, 1 },
                    { 3, 1 },
                    { 6, 1 },
                    { 15, 15 },
                    { 1, 11 },
                    { 18, 15 },
                    { 12, 15 },
                    { 11, 15 },
                    { 14, 15 }
                });

            migrationBuilder.InsertData(
                table: "Genres_Movies",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 10, 14 },
                    { 11, 14 }
                });

            migrationBuilder.InsertData(
                table: "Movie_Gallery",
                columns: new[] { "Id", "ImageURL", "MovieId" },
                values: new object[,]
                {
                    { 78, "../images/movies/TheSecretsofDumbledore1.jpg", 13 },
                    { 75, "../images/movies/NoTimetoDie9.jpg", 11 },
                    { 74, "../images/movies/NoTimetoDie8.jpg", 11 },
                    { 73, "../images/movies/NoTimetoDie7.jpg", 11 },
                    { 98, "../images/movies/Ambulance7.jpg", 16 },
                    { 99, "../images/movies/Ambulance8.jpg", 16 },
                    { 72, "../images/movies/NoTimetoDie6.jpg", 11 },
                    { 97, "../images/movies/Ambulance6.jpg", 16 },
                    { 71, "../images/movies/NoTimetoDie5.jpg", 11 },
                    { 70, "../images/movies/NoTimetoDie4.jpg", 11 },
                    { 69, "../images/movies/NoTimetoDie3.jpg", 11 },
                    { 68, "../images/movies/NoTimetoDie2.jpg", 11 },
                    { 67, "../images/movies/NoTimetoDie1.jpg", 11 },
                    { 84, "../images/movies/TheSecretsofDumbledore7.jpg", 13 },
                    { 83, "../images/movies/TheSecretsofDumbledore6.jpg", 13 },
                    { 96, "../images/movies/Ambulance5.jpg", 16 },
                    { 94, "../images/movies/Ambulance3.jpg", 16 },
                    { 82, "../images/movies/TheSecretsofDumbledore5.jpg", 13 },
                    { 93, "../images/movies/Ambulance2.jpg", 16 },
                    { 92, "../images/movies/Ambulance1.jpg", 16 },
                    { 81, "../images/movies/TheSecretsofDumbledore4.jpg", 13 },
                    { 80, "../images/movies/TheSecretsofDumbledore3.jpg", 13 },
                    { 86, "../images/movies/Panama1.jpg", 14 },
                    { 87, "../images/movies/Panama2.jpg", 14 },
                    { 91, "../images/movies/DoctorStrange4.jpg", 15 },
                    { 90, "../images/movies/DoctorStrange3.jpg", 15 },
                    { 89, "../images/movies/DoctorStrange2.jpg", 15 },
                    { 76, "../images/movies/SuperPets1.jpg", 12 },
                    { 77, "../images/movies/SuperPets2.jpg", 12 },
                    { 79, "../images/movies/TheSecretsofDumbledore2.jpg", 13 },
                    { 88, "../images/movies/DoctorStrange1.jpg", 15 },
                    { 95, "../images/movies/Ambulance4.jpg", 16 },
                    { 85, "../images/movies/TheSecretsofDumbledore8.jpg", 13 },
                    { 12, "../images/movies/Uncharted2.jpg", 2 },
                    { 61, "../images/movies/SpiderMan7.jpg", 9 },
                    { 8, "../images/movies/Batman8.jpg", 1 },
                    { 7, "../images/movies/Batman7.jpg", 1 },
                    { 6, "../images/movies/Batman6.jpg", 1 },
                    { 5, "../images/movies/Batman5.jpg", 1 },
                    { 4, "../images/movies/Batman4.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "Movie_Gallery",
                columns: new[] { "Id", "ImageURL", "MovieId" },
                values: new object[,]
                {
                    { 3, "../images/movies/Batman3.jpg", 1 },
                    { 2, "../images/movies/Batman2.jpg", 1 },
                    { 1, "../images/movies/Batman1.jpg", 1 },
                    { 54, "../images/movies/ElGareema9.jpg", 8 },
                    { 53, "../images/movies/ElGareema8.jpg", 8 },
                    { 52, "../images/movies/ElGareema7.jpg", 8 },
                    { 51, "../images/movies/ElGareema6.jpg", 8 },
                    { 50, "../images/movies/ElGareema5.jpg", 8 },
                    { 9, "../images/movies/Batman9.jpg", 1 },
                    { 49, "../images/movies/ElGareema4.jpg", 8 },
                    { 46, "../images/movies/ElGareema1.jpg", 8 },
                    { 45, "../images/movies/MenAglZeko6.jpg", 7 },
                    { 44, "../images/movies/MenAglZeko5.jpg", 7 },
                    { 43, "../images/movies/MenAglZeko4.jpg", 7 },
                    { 42, "../images/movies/MenAglZeko3.jpg", 7 },
                    { 41, "../images/movies/MenAglZeko2.jpg", 7 },
                    { 40, "../images/movies/MenAglZeko1.jpg", 7 },
                    { 21, "../images/movies/HamelElLakab5.jpg", 3 },
                    { 20, "../images/movies/HamelElLakab4.jpg", 3 },
                    { 19, "../images/movies/HamelElLakab3.jpg", 3 },
                    { 18, "../images/movies/HamelElLakab2.jpg", 3 },
                    { 17, "../images/movies/HamelElLakab1.jpg", 3 },
                    { 62, "../images/movies/SpiderMan8.jpg", 9 },
                    { 48, "../images/movies/ElGareema3.jpg", 8 },
                    { 10, "../images/movies/Batman10.jpg", 1 },
                    { 47, "../images/movies/ElGareema2.jpg", 8 },
                    { 39, "../images/movies/DeathontheNile8.jpg", 6 },
                    { 11, "../images/movies/Uncharted1.jpg", 2 },
                    { 59, "../images/movies/SpiderMan5.jpg", 9 },
                    { 58, "../images/movies/SpiderMan4.jpg", 9 },
                    { 57, "../images/movies/SpiderMan3.jpg", 9 },
                    { 56, "../images/movies/SpiderMan2.jpg", 9 },
                    { 55, "../images/movies/SpiderMan1.jpg", 9 },
                    { 38, "../images/movies/DeathontheNile7.jpg", 6 },
                    { 37, "../images/movies/DeathontheNile6.jpg", 6 },
                    { 36, "../images/movies/DeathontheNile5.jpg", 6 },
                    { 35, "../images/movies/DeathontheNile4.jpg", 6 },
                    { 33, "../images/movies/DeathontheNile2.jpg", 6 },
                    { 32, "../images/movies/DeathontheNile1.jpg", 6 },
                    { 31, "../images/movies/TurningRed8.jpg", 5 },
                    { 34, "../images/movies/DeathontheNile3.jpg", 6 },
                    { 29, "../images/movies/TurningRed6.jpg", 5 }
                });

            migrationBuilder.InsertData(
                table: "Movie_Gallery",
                columns: new[] { "Id", "ImageURL", "MovieId" },
                values: new object[,]
                {
                    { 13, "../images/movies/Uncharted3.jpg", 2 },
                    { 14, "../images/movies/Uncharted4.jpg", 2 },
                    { 15, "../images/movies/Uncharted5.jpg", 2 },
                    { 16, "../images/movies/Uncharted6.jpg", 2 },
                    { 30, "../images/movies/TurningRed7.jpg", 5 },
                    { 23, "../images/movies/Contractor2.jpg", 4 },
                    { 22, "../images/movies/Contractor1.jpg", 4 },
                    { 25, "../images/movies/TurningRed2.jpg", 5 },
                    { 26, "../images/movies/TurningRed3.jpg", 5 },
                    { 27, "../images/movies/TurningRed4.jpg", 5 },
                    { 28, "../images/movies/TurningRed5.jpg", 5 },
                    { 24, "../images/movies/TurningRed1.jpg", 5 },
                    { 60, "../images/movies/SpiderMan6.jpg", 9 }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "MovieId", "ScreenId", "ShowEndDate", "ShowStartDate" },
                values: new object[,]
                {
                    { 64, 9, 41, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 3, 36, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 11, 40, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 4, 40, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, 39, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 7, 42, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 6, 38, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, 37, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 3, 55, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 2, 35, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 5, 33, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 32, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 4, 31, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 3, 30, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 15, 42, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 8, 29, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 3, 36, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 8, 44, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, 53, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 8, 46, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 7, 28, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 7, 54, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 5, 54, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 2, 53, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 8, 52, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, 51, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 14, 50, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 3, 50, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, 50, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "MovieId", "ScreenId", "ShowEndDate", "ShowStartDate" },
                values: new object[,]
                {
                    { 10, 1, 50, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 7, 49, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 8, 49, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 3, 49, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, 48, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 47, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, 45, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 5, 27, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 3, 4, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, 26, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 9, 10, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 6, 9, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, 8, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 8, 7, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 5, 7, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 4, 6, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, 5, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, 4, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 12, 2, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 6, 2, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 2, 2, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 16, 1, new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 11, 1, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, 1, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 4, 56, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 12, 10, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 5, 11, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 2, 12, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 3, 13, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 26, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, 25, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, 24, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, 23, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 4, 22, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, 21, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 13, 20, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 2, 27, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 6, 20, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 5, 18, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 14, 17, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 2, 17, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 15, 15, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "MovieId", "ScreenId", "ShowEndDate", "ShowStartDate" },
                values: new object[,]
                {
                    { 42, 4, 15, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 13, 14, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, 14, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 3, 19, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 8, 56, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Show_Times",
                columns: new[] { "ShowId", "TimeId" },
                values: new object[,]
                {
                    { 18, 3 },
                    { 47, 9 },
                    { 47, 3 },
                    { 3, 26 },
                    { 3, 19 },
                    { 3, 12 },
                    { 3, 5 },
                    { 3, 1 },
                    { 37, 27 },
                    { 37, 23 },
                    { 37, 19 },
                    { 37, 15 },
                    { 37, 11 },
                    { 37, 7 },
                    { 37, 3 },
                    { 37, 1 },
                    { 28, 27 },
                    { 28, 22 },
                    { 47, 15 },
                    { 47, 21 },
                    { 47, 25 },
                    { 26, 3 },
                    { 19, 27 },
                    { 19, 19 },
                    { 19, 11 },
                    { 19, 3 },
                    { 35, 27 },
                    { 35, 21 },
                    { 35, 15 },
                    { 35, 10 },
                    { 28, 17 },
                    { 35, 4 },
                    { 34, 21 },
                    { 34, 15 },
                    { 34, 10 },
                    { 34, 4 },
                    { 26, 27 },
                    { 26, 21 },
                    { 26, 15 },
                    { 26, 9 },
                    { 34, 27 },
                    { 28, 13 }
                });

            migrationBuilder.InsertData(
                table: "Show_Times",
                columns: new[] { "ShowId", "TimeId" },
                values: new object[,]
                {
                    { 28, 8 },
                    { 28, 3 },
                    { 22, 2 },
                    { 6, 24 },
                    { 6, 17 },
                    { 6, 10 },
                    { 6, 3 },
                    { 5, 25 },
                    { 5, 19 },
                    { 5, 11 },
                    { 22, 23 },
                    { 5, 4 },
                    { 4, 24 },
                    { 4, 18 },
                    { 54, 21 },
                    { 4, 3 },
                    { 4, 1 },
                    { 15, 28 },
                    { 15, 20 },
                    { 15, 12 },
                    { 5, 2 },
                    { 58, 3 },
                    { 22, 28 },
                    { 43, 7 },
                    { 28, 1 },
                    { 50, 25 },
                    { 50, 19 },
                    { 50, 14 },
                    { 50, 9 },
                    { 50, 3 },
                    { 50, 1 },
                    { 60, 27 },
                    { 43, 3 },
                    { 60, 23 },
                    { 60, 15 },
                    { 60, 11 },
                    { 60, 7 },
                    { 60, 3 },
                    { 60, 1 },
                    { 43, 19 },
                    { 43, 15 },
                    { 43, 11 }
                });

            migrationBuilder.InsertData(
                table: "Show_Times",
                columns: new[] { "ShowId", "TimeId" },
                values: new object[,]
                {
                    { 60, 19 },
                    { 15, 4 },
                    { 58, 9 },
                    { 58, 21 },
                    { 9, 19 },
                    { 9, 9 },
                    { 9, 3 },
                    { 30, 29 },
                    { 30, 13 },
                    { 16, 18 },
                    { 16, 11 },
                    { 16, 3 },
                    { 10, 25 },
                    { 10, 19 },
                    { 10, 15 },
                    { 10, 7 },
                    { 61, 9 },
                    { 53, 5 },
                    { 32, 15 },
                    { 13, 27 },
                    { 13, 21 },
                    { 9, 22 },
                    { 9, 29 },
                    { 51, 3 },
                    { 51, 26 },
                    { 40, 15 },
                    { 40, 9 },
                    { 40, 4 },
                    { 33, 27 },
                    { 33, 21 },
                    { 33, 15 },
                    { 33, 10 },
                    { 33, 4 },
                    { 13, 15 },
                    { 62, 25 },
                    { 46, 15 },
                    { 46, 9 },
                    { 46, 3 },
                    { 25, 15 },
                    { 25, 9 },
                    { 25, 4 },
                    { 17, 27 }
                });

            migrationBuilder.InsertData(
                table: "Show_Times",
                columns: new[] { "ShowId", "TimeId" },
                values: new object[,]
                {
                    { 17, 20 },
                    { 62, 21 },
                    { 13, 9 },
                    { 2, 28 },
                    { 2, 20 },
                    { 64, 15 },
                    { 64, 9 },
                    { 64, 3 },
                    { 67, 29 },
                    { 67, 23 },
                    { 67, 17 },
                    { 67, 15 },
                    { 67, 11 },
                    { 64, 21 },
                    { 67, 5 },
                    { 41, 21 },
                    { 41, 15 },
                    { 41, 9 },
                    { 41, 3 },
                    { 20, 23 },
                    { 20, 15 },
                    { 20, 9 },
                    { 58, 27 },
                    { 41, 27 },
                    { 58, 15 },
                    { 64, 25 },
                    { 63, 9 },
                    { 2, 13 },
                    { 2, 5 },
                    { 49, 21 },
                    { 49, 15 },
                    { 49, 10 },
                    { 49, 4 },
                    { 7, 27 },
                    { 7, 19 },
                    { 63, 3 },
                    { 7, 11 },
                    { 55, 27 },
                    { 55, 21 },
                    { 55, 15 },
                    { 55, 9 },
                    { 55, 3 }
                });

            migrationBuilder.InsertData(
                table: "Show_Times",
                columns: new[] { "ShowId", "TimeId" },
                values: new object[,]
                {
                    { 63, 25 },
                    { 63, 21 },
                    { 63, 15 },
                    { 7, 4 },
                    { 1, 24 },
                    { 4, 10 },
                    { 1, 10 },
                    { 52, 10 },
                    { 52, 5 },
                    { 52, 1 },
                    { 45, 21 },
                    { 45, 15 },
                    { 45, 10 },
                    { 45, 5 },
                    { 39, 26 },
                    { 39, 21 },
                    { 39, 15 },
                    { 39, 10 },
                    { 39, 5 },
                    { 39, 1 },
                    { 12, 30 },
                    { 12, 23 },
                    { 12, 18 },
                    { 12, 14 },
                    { 52, 15 },
                    { 52, 21 },
                    { 52, 25 },
                    { 14, 3 },
                    { 69, 9 },
                    { 69, 3 },
                    { 69, 1 },
                    { 65, 29 },
                    { 65, 23 },
                    { 1, 17 },
                    { 65, 15 },
                    { 65, 11 },
                    { 12, 6 },
                    { 65, 5 },
                    { 59, 21 },
                    { 59, 15 },
                    { 59, 9 },
                    { 59, 3 }
                });

            migrationBuilder.InsertData(
                table: "Show_Times",
                columns: new[] { "ShowId", "TimeId" },
                values: new object[,]
                {
                    { 59, 1 },
                    { 14, 24 },
                    { 14, 17 },
                    { 14, 10 },
                    { 59, 27 },
                    { 69, 15 },
                    { 31, 26 },
                    { 31, 15 },
                    { 24, 15 },
                    { 24, 10 },
                    { 24, 5 },
                    { 24, 1 },
                    { 76, 30 },
                    { 76, 15 },
                    { 76, 6 },
                    { 76, 1 },
                    { 66, 29 },
                    { 66, 23 },
                    { 66, 17 },
                    { 66, 15 },
                    { 66, 11 },
                    { 66, 5 },
                    { 18, 25 },
                    { 18, 18 },
                    { 18, 11 },
                    { 24, 21 },
                    { 24, 25 },
                    { 57, 1 },
                    { 57, 3 },
                    { 31, 10 },
                    { 31, 5 },
                    { 31, 1 },
                    { 11, 28 },
                    { 11, 21 },
                    { 11, 16 },
                    { 11, 12 },
                    { 11, 4 },
                    { 31, 21 },
                    { 68, 27 },
                    { 68, 15 },
                    { 68, 9 },
                    { 68, 3 }
                });

            migrationBuilder.InsertData(
                table: "Show_Times",
                columns: new[] { "ShowId", "TimeId" },
                values: new object[,]
                {
                    { 68, 1 },
                    { 57, 27 },
                    { 57, 21 },
                    { 57, 15 },
                    { 57, 9 },
                    { 68, 21 },
                    { 69, 21 },
                    { 65, 17 },
                    { 48, 3 },
                    { 29, 25 },
                    { 29, 21 },
                    { 29, 15 },
                    { 29, 10 },
                    { 29, 5 },
                    { 29, 1 },
                    { 44, 21 },
                    { 44, 17 },
                    { 44, 13 },
                    { 44, 9 },
                    { 44, 5 },
                    { 72, 27 },
                    { 72, 21 },
                    { 72, 9 },
                    { 72, 3 },
                    { 72, 1 },
                    { 69, 27 },
                    { 56, 1 },
                    { 56, 3 },
                    { 56, 9 },
                    { 56, 15 },
                    { 1, 3 },
                    { 38, 26 },
                    { 38, 21 },
                    { 38, 15 },
                    { 38, 10 },
                    { 38, 5 },
                    { 38, 1 },
                    { 8, 24 },
                    { 23, 25 },
                    { 8, 17 },
                    { 8, 3 },
                    { 71, 27 }
                });

            migrationBuilder.InsertData(
                table: "Show_Times",
                columns: new[] { "ShowId", "TimeId" },
                values: new object[,]
                {
                    { 71, 21 },
                    { 71, 9 },
                    { 71, 3 },
                    { 71, 1 },
                    { 56, 27 },
                    { 56, 21 },
                    { 8, 10 },
                    { 23, 21 },
                    { 54, 27 },
                    { 42, 9 },
                    { 42, 1 },
                    { 70, 27 },
                    { 70, 21 },
                    { 70, 15 },
                    { 70, 9 },
                    { 70, 3 },
                    { 42, 3 },
                    { 70, 1 },
                    { 21, 20 },
                    { 23, 15 },
                    { 36, 15 },
                    { 36, 21 },
                    { 36, 27 },
                    { 21, 5 },
                    { 21, 27 },
                    { 42, 15 },
                    { 21, 13 },
                    { 23, 1 },
                    { 42, 27 },
                    { 36, 10 },
                    { 36, 4 },
                    { 36, 1 },
                    { 27, 27 },
                    { 27, 21 },
                    { 27, 15 },
                    { 27, 9 },
                    { 42, 21 },
                    { 27, 3 },
                    { 27, 1 },
                    { 23, 5 },
                    { 48, 21 },
                    { 48, 15 }
                });

            migrationBuilder.InsertData(
                table: "Show_Times",
                columns: new[] { "ShowId", "TimeId" },
                values: new object[] { 48, 9 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "SeatNumber", "ShowDate", "ShowId", "ShowTime", "TicketPrice", "UserId" },
                values: new object[,]
                {
                    { 19, "D4", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 14, new TimeSpan(0, 13, 30, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 20, "D5", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 14, new TimeSpan(0, 13, 30, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 18, "E1", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 50, new TimeSpan(0, 13, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 8, "C12", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 24, new TimeSpan(0, 11, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 14, "A7", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 9, new TimeSpan(0, 13, 0, 0, 0), 100, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 17, "D6", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 50, new TimeSpan(0, 13, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 16, "D5", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 50, new TimeSpan(0, 13, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 15, "D4", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 50, new TimeSpan(0, 13, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 1, "B5", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 2, "B6", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 4, "B8", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 5, "B9", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 25, "F9", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 42, new TimeSpan(0, 22, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 6, "C10", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 24, new TimeSpan(0, 11, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 24, "F8", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 42, new TimeSpan(0, 22, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 22, "F6", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 42, new TimeSpan(0, 22, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 21, "F5", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 42, new TimeSpan(0, 22, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 7, "C11", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 24, new TimeSpan(0, 11, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 9, "A2", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 9, new TimeSpan(0, 18, 0, 0, 0), 100, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 10, "A3", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 9, new TimeSpan(0, 18, 0, 0, 0), 100, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 11, "A4", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 9, new TimeSpan(0, 18, 0, 0, 0), 100, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 12, "A5", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 9, new TimeSpan(0, 18, 0, 0, 0), 100, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 13, "A6", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 9, new TimeSpan(0, 18, 0, 0, 0), 100, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 23, "F7", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 42, new TimeSpan(0, 22, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" },
                    { 3, "B7", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 0, 0, 0), 60, "94d81c07-9f25-4b5f-83c2-e7a623cc65dc" }
                });

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
                name: "IX_Crew_CrewRoleId",
                table: "Crew",
                column: "CrewRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_NationalityId",
                table: "Crew",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_Gallery_CrewId",
                table: "Crew_Gallery",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_Movies_MovieId",
                table: "Crew_Movies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Movies_MovieId",
                table: "Genres_Movies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Gallery_MovieId",
                table: "Movie_Gallery",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CountryId",
                table: "Movies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_LanguageId",
                table: "Movies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_TheaterId",
                table: "Screens",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Show_Times_TimeId",
                table: "Show_Times",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ScreenId",
                table: "Shows",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowId",
                table: "Tickets",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
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
                name: "Crew_Gallery");

            migrationBuilder.DropTable(
                name: "Crew_Movies");

            migrationBuilder.DropTable(
                name: "Genres_Movies");

            migrationBuilder.DropTable(
                name: "Movie_Gallery");

            migrationBuilder.DropTable(
                name: "Show_Times");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Crews_Roles");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Theaters");
        }
    }
}
