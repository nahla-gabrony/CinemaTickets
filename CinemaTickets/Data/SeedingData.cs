using CinemaTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CinemaTickets.Data
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Role
            var Roles = new List<IdentityRole>()
                {
                    new IdentityRole()
                    {
                        Name = "Super Admin", NormalizedName = "SUPER ADMIN"
                    },
                    new IdentityRole()
                    {
                        Name = "Admin", NormalizedName = "ADMIN"
                    },
                    new IdentityRole()
                    {
                        Name = "Advertising Admin", NormalizedName = "ADVERTISING ADMIN"
                    },
                    new IdentityRole()
                    {
                        Name = "User", NormalizedName = "USER"
                    },
                        
                };
            modelBuilder.Entity<IdentityRole>().HasData(Roles);
            // Users
            var Users = new List<ApplicationUser>()
                {
                    new ApplicationUser()
                    {
                        FirstName = "Nahla",
                        LastName = "Ahmed",
                        Email = "superadmin@cinematickets.com",
                        NormalizedEmail = "SUPERADMIN@CINEMATICKETS.COM",
                        UserName = "superadmin@cinematickets.com",
                        NormalizedUserName = "SUPERADMIN@CINEMATICKETS.COM",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    },
                    new ApplicationUser()
                        {
                            FirstName = "Mohamed",
                            LastName = "Ahmed",
                            Email = "admin@cinematickets.com",
                            NormalizedEmail = "ADMIN@CINEMATICKETS.COM",
                            UserName = "admin@cinematickets.com",
                            NormalizedUserName = "ADMIN@CINEMATICKETS.COM",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                    new ApplicationUser()
                        {
                            FirstName = "Hala",
                            LastName = "Ali",
                            Email = "advertising@cinematickets.com",
                            NormalizedEmail = "ADVERTISING@CINEMATICKETS.COM",
                            UserName = "advertising@cinematickets.com",
                            NormalizedUserName = "ADVERTISING@CINEMATICKETS.COM",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                    new ApplicationUser()
                        {
                            FirstName = "Ali",
                            LastName = "Mohamed",
                            Email = "Ali_Mohamed@yahoo.com",
                            NormalizedEmail = "ALI_MOHAMED@YAHOO.COM",
                            UserName = "Ali_Mohamed@yahoo.com",
                            NormalizedUserName = "ALI_MOHAMED@YAHOO.COM",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                };
            var password = new PasswordHasher<ApplicationUser>();
            Users[0].PasswordHash = password.HashPassword(Users[0], "Admin123$");
            Users[1].PasswordHash = password.HashPassword(Users[1], "Admin123$");
            Users[2].PasswordHash = password.HashPassword(Users[2], "Admin123$");
            Users[3].PasswordHash = password.HashPassword(Users[3], "@li_Mohamed80");
            modelBuilder.Entity<ApplicationUser>().HasData(Users);
            // User - Role
            var UserRole = new List<IdentityUserRole<string>> ()
                {
                    new IdentityUserRole<string> (){
                        RoleId = Roles[0].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[1].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[2].Id,
                        UserId = Users[2].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[3].Id,
                        UserId = Users[3].Id
                    },

                };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(UserRole);

            // Slides
            var Slides = new List<Slide>()
                {
                  new Slide()
                        {
                         Id = 1,
                            SlideTitle = "Cinema Tickets" ,
                            SlideDetails = "The website used by over 10 theatres in Egypt. website includes online ticketing systems, seat reservation software, display signage, Food and Beverages and more. Enjoy booking and watching best movies." ,
                            SlideImageURL = "../images/slides/slide1.jpg" ,
                            IsActive = true,
                        },
                        new Slide()
                        {
                          Id = 2,
                            SlideTitle = "Uncharted" ,
                            SlideDetails ="The fortune hunter Nathan Drake embarks on a dangerous mission, as he joins forces with Victor Sullivan in order to find a priceless treasure and also tracking down Nathan’s long-lost brother.",
                            SlideImageURL = "../images/slides/slide2.jpg" ,
                            MovieId = 2,
                            IsActive = true,
                        },
                        new Slide()
                        {
                          Id = 3,
                            SlideTitle = "Hamel El Lakab" ,
                            SlideDetails = "The events revolve around Yahya, a soccer player, and his wife Misk, a gynecologist. The couple has been trying for many years to have a baby, but they are surprised when it happens at the wrong time, upon which they encounter many comic situations." ,
                            SlideImageURL = "../images/slides/slide3.jpg" ,
                            MovieId = 3,
                            IsActive = true,
                        },
                        new Slide()
                        {
                          Id = 4,
                            SlideTitle = "Death on the Nile" ,
                            SlideDetails = "As he spends his vacation aboard a cruise ship on the Nile in Egypt, Detective Hercule Poirot tries to find a murderer after a young heiress is found dead." ,
                            SlideImageURL = "../images/slides/slide4.jpg" ,
                            MovieId = 6,
                            IsActive = true,
                        },
                        new Slide()
                        {
                          Id = 5,
                            SlideTitle = "Turning Red" ,
                            SlideDetails = "As the 13-year-old girl Mei Lee deals with the chaos of adolescence, she finds herself facing a much bigger problem when she discovers that she turns into a giant red panda whenever she gets too excited." ,
                            SlideImageURL = "../images/slides/slide5.jpg" ,
                            MovieId = 5,
                            IsActive = true,
                        },

                };
            modelBuilder.Entity<Slide>().HasData(Slides);
            // Country
            var Countries = new List<Country>()
                {
                    new Country()
                    {
                     Id =1,
                        CountryName = "Egypt"
                    },
                    new Country()
                    {
                     Id = 2,
                        CountryName = "USA"
                    },
                    new Country()
                    {
                     Id = 3,
                        CountryName = "UK"
                    },
                    new Country()
                    {
                     Id = 4,
                        CountryName = "Canada"
                    },
                    new Country()
                    {
                     Id = 5,
                        CountryName = "France"
                    },
                    new Country()
                    {
                     Id = 6,
                        CountryName = "India"
                    },
                    new Country()
                    {
                        Id = 7,
                        CountryName = "Turkey"
                    },
                    new Country()
                    {
                        Id = 8,
                        CountryName = "Ireland"
                    },
                    new Country()
                    {
                        Id = 9,
                        CountryName = "Spain"
                    },
                    new Country()
                    {
                        Id = 10,
                        CountryName = " Mexico"
                    }
                };
            modelBuilder.Entity<Country>().HasData(Countries);
            // Time
            var Times = new List<Time>()
                {
                     new Time()
                   {
                    Id = 1,
                       MovieTime = new TimeSpan(0, 0, 0)
                   },
                    new Time()
                    {
                     Id = 2,
                        MovieTime = new TimeSpan(0, 30, 0)
                    },
                    new Time()
                    {
                     Id = 3,
                        MovieTime = new TimeSpan(10, 0, 0)
                    },
                    new Time()
                    {
                     Id = 4,
                        MovieTime = new TimeSpan(10, 30, 0)
                    },
                    new Time()
                    {
                     Id = 5,
                        MovieTime = new TimeSpan(11, 0, 0)
                    },
                    new Time()
                    {
                     Id = 6,
                        MovieTime = new TimeSpan(11, 30, 0)
                    },
                    new Time()
                    {
                     Id = 7,
                        MovieTime = new TimeSpan(12, 0, 0)
                    },
                    new Time()
                    {
                     Id = 8,
                        MovieTime = new TimeSpan(12, 30, 0)
                    },
                    new Time()
                    {
                     Id = 9,
                        MovieTime = new TimeSpan(13, 0, 0)
                    },
                    new Time()
                    {
                     Id = 10,
                        MovieTime = new TimeSpan(13, 30, 0)
                    },
                    new Time()
                    {
                     Id = 11,
                        MovieTime = new TimeSpan(14, 0, 0)
                    },
                    new Time()
                    {
                     Id = 12,
                        MovieTime = new TimeSpan(14, 30, 0)
                    },
                    new Time()
                    {
                     Id = 13,
                        MovieTime = new TimeSpan(15, 0, 0)
                    },
                    new Time()
                    {
                     Id = 14,
                        MovieTime = new TimeSpan(15, 30, 0)
                    },
                    new Time()
                    {
                     Id = 15,
                        MovieTime = new TimeSpan(16, 0, 0)
                    },
                    new Time()
                    {
                     Id = 16,
                        MovieTime = new TimeSpan(16, 30, 0)
                    },
                    new Time()
                    {
                     Id = 17,
                        MovieTime = new TimeSpan(17, 0, 0)
                    },
                    new Time()
                    {
                     Id = 18,
                        MovieTime = new TimeSpan(17, 30, 0)
                    },
                    new Time()
                    {
                     Id = 19,
                        MovieTime = new TimeSpan(18, 0, 0)
                    },
                    new Time()
                    {
                     Id = 20,
                        MovieTime = new TimeSpan(18, 30, 0)
                    },
                    new Time()
                    {
                     Id = 21,
                        MovieTime = new TimeSpan(19, 0, 0)
                    },
                    new Time()
                    {
                     Id = 22,
                        MovieTime = new TimeSpan(19, 30, 0)
                    },
                    new Time()
                    {
                     Id = 23,
                        MovieTime = new TimeSpan(20, 0, 0)
                    },
                    new Time()
                    {
                     Id = 24,
                        MovieTime = new TimeSpan(20, 30, 0)
                    },
                    new Time()
                    {
                     Id = 25,
                        MovieTime = new TimeSpan(21, 0, 0)
                    },
                    new Time()
                    {
                     Id = 26,
                        MovieTime = new TimeSpan(21, 30, 0)
                    },
                    new Time()
                    {
                     Id = 27,
                        MovieTime = new TimeSpan(22, 0, 0)
                    },
                    new Time()
                    {
                     Id = 28,
                        MovieTime = new TimeSpan(22, 30, 0)
                    },
                    new Time()
                    {
                     Id = 29,
                        MovieTime = new TimeSpan(23, 0, 0)
                    },
                    new Time()
                    {
                     Id = 30,
                        MovieTime = new TimeSpan(23, 30, 0)
                    }
                };
            modelBuilder.Entity<Time>().HasData(Times);
            // Language
            var Languages = new List<Language>()
                {
                     new Language()
                        {
                         Id = 1,
                           LanguageName = "Arabic"
                        },
                        new Language()
                        {
                         Id = 2,
                           LanguageName = "English"
                        },
                        new Language()
                        {
                         Id = 3,
                           LanguageName = "French"
                        },
                        new Language()
                        {
                         Id = 4,
                           LanguageName = "Turkish"
                        },
                        new Language()
                        {
                         Id = 5,
                           LanguageName = "Hindi"
                        }
                };
            modelBuilder.Entity<Language>().HasData(Languages);
            // Crew Types
            var CrewTypes = new List<Crew_Role>()
                {
                       new Crew_Role()
                        {
                           Id = 1,
                           CrewRoleName ="Actor"
                        },
                        new Crew_Role()
                        {
                             Id = 2,
                            CrewRoleName = "Writer"
                        },
                        new Crew_Role()
                        {
                            Id = 3,
                            CrewRoleName = "Director"
                        },
                };
            modelBuilder.Entity<Crew_Role>().HasData(CrewTypes);

            // Genre
            var Genres = new List<Genre>()
                {
                      new Genre()
                        {
                         Id = 1,
                            GenreName = "Action",
                        },
                        new Genre()
                        {
                         Id = 2,
                            GenreName = "Comedy",
                        },
                        new Genre()
                        {
                         Id = 3,
                            GenreName = "Drama",
                        },
                        new Genre()
                        {
                         Id = 4,
                            GenreName = "Fantasy",
                        },
                        new Genre()
                        {
                         Id = 5,
                            GenreName = "Horror",
                        },
                        new Genre()
                        {
                         Id = 6,
                            GenreName = "Mystery",
                        },
                        new Genre()
                        {
                         Id = 7,
                            GenreName = "Romance",
                        },
                        new Genre()
                        {
                         Id = 8,
                            GenreName = "Thriller",
                        },
                        new Genre()
                        {
                         Id = 9,
                            GenreName = "War",
                        },
                        new Genre()
                        {
                         Id = 10,
                            GenreName = "Spy",
                        },
                        new Genre()
                        {
                         Id = 11,
                            GenreName = "Adventure",
                        },
                        new Genre()
                        {
                         Id = 12,
                            GenreName = "Historical",
                        },
                        new Genre()
                        {
                         Id = 13,
                            GenreName = "Thriller",
                        },
                        new Genre()
                        {
                         Id = 14,
                            GenreName = "Crime",
                        },
                        new Genre()
                        {
                         Id = 15,
                            GenreName = "Animation",
                        },
                        new Genre()
                        {
                         Id = 16,
                            GenreName = "Adventure",
                        },
                        new Genre()
                        {
                         Id = 17,
                            GenreName = "Family",
                        },
                        new Genre()
                        {
                         Id = 18,
                            GenreName = "Science Fiction",
                        },
                };
            modelBuilder.Entity<Genre>().HasData(Genres);
            // Movies
            var Movies = new List<Movie>()
                {
                        new Movie()
                        {
                         Id = 1,
                            MovieName ="The Batman",
                            MovieDescription ="In his second year as the protector of Gotham City, Bruce Wayne, AKA Batman, finds himself facing off against the Penguin and the Riddler, in addition to other villains who plague Gotham." ,
                            MovieImageURL ="../images/movies/Batman1.jpg",
                            MovieRate ="+12",
                            MovieRunningTime ="175 minutes" ,
                            MovieReleaseDate = new DateTime(2022, 3, 2) ,
                            LanguageId = 2 ,
                            CountryId = 2,
                        },
                        new Movie()
                        {
                          Id = 2,
                            MovieName ="Uncharted",
                            MovieDescription ="The fortune hunter Nathan Drake embarks on a dangerous mission, as he joins forces with Victor Sullivan in order to find a priceless treasure and also tracking down Nathan’s long-lost brother." ,
                            MovieImageURL ="../images/movies/Uncharted1.jpg",
                            MovieRate ="+12",
                            MovieRunningTime ="116 minutes" ,
                            MovieReleaseDate = new DateTime(2022, 2, 10) ,
                            LanguageId = 2 ,
                            CountryId = 2,
                        },
                        new Movie()
                        {
                          Id = 3,
                            MovieName ="Hamel El Lakab",
                            MovieDescription ="The events revolve around Yahya, a soccer player, and his wife Misk, a gynecologist. The couple has been trying for many years to have a baby, but they are surprised when it happens at the wrong time, upon which they encounter many comic situations." ,
                            MovieImageURL ="../images/movies/HamelElLakab1.jpg",
                            MovieRate = "+12",
                            MovieRunningTime ="120 minutes" ,
                            MovieReleaseDate = new DateTime(2022, 2, 2) ,
                            LanguageId = 1 ,
                            CountryId = 1,
                        },
                        new Movie()
                        {
                          Id = 4,
                            MovieName ="The Contractor",
                            MovieDescription ="After being discharged from the United States Army Special Forces, James Harper  joins a private underground military organization, but as soon as his first mission goes wrong, he finds himself fighting for his life to avoid a perilous conspiracy." ,
                            MovieImageURL ="../images/movies/Contractor1.jpg",
                            MovieRate ="+16",
                            MovieRunningTime ="103 minutes" ,
                            MovieReleaseDate = new DateTime(2022, 3, 9) ,
                            LanguageId =2 ,
                            CountryId =2,
                        },
                        new Movie()
                        {
                          Id = 5,
                            MovieName ="Turning Red",
                            MovieDescription ="As the 13-year-old girl Mei Lee deals with the chaos of adolescence, she finds herself facing a much bigger problem when she discovers that she turns into a giant red panda whenever she gets too excited." ,
                            MovieImageURL ="../images/movies/TurningRed1.jpg",
                            MovieRate ="All Ages",
                            MovieRunningTime ="100 minutes" ,
                            MovieReleaseDate = new DateTime(2022, 3, 10) ,
                            LanguageId =2 ,
                            CountryId =2,
                        },
                        new Movie()
                        {
                          Id = 6,
                            MovieName ="Death on the Nile",
                            MovieDescription ="As he spends his vacation aboard a cruise ship on the Nile in Egypt, Detective Hercule Poirot tries to find a murderer after a young heiress is found dead." ,
                            MovieImageURL ="../images/movies/DeathontheNile1.jpg",
                            MovieRate ="+12",
                            MovieRunningTime ="127 minutes" ,
                            MovieReleaseDate = new DateTime(2022, 2, 9) ,
                            LanguageId = 2 ,
                            CountryId = 3,
                        },
                        new Movie()
                        {
                          Id = 7,
                            MovieName ="Men Agl Zeko",
                            MovieDescription ="The story follows a simple family whose young son, Zeko, wins the opportunity to participate in a contest for Egypt's smartest child. As they set out to attend the contest, many paradoxes happen to them during the two-day trip" ,
                            MovieImageURL ="../images/movies/MenAglZeko1.jpg",
                            MovieRate ="All Ages",
                            MovieRunningTime ="95 minutes" ,
                            MovieReleaseDate = new DateTime(2022, 1, 5) ,
                            LanguageId = 1 ,
                            CountryId = 1,
                        },
                        new Movie()
                        {
                          Id = 8,
                            MovieName ="El Gareema",
                            MovieDescription ="When a violent criminal breaks out from a psychiatric hospital, the concerned authorities discover his connection to a number of prior crimes involving prominent figures." ,
                            MovieImageURL ="../images/movies/ElGareema1.jpg",
                            MovieRate ="+16",
                            MovieRunningTime ="125 minutes" ,
                            MovieReleaseDate = new DateTime(2022, 1, 5) ,
                            LanguageId = 1 ,
                            CountryId = 1,
                        },
                        new Movie()
                        {
                          Id = 9,
                            MovieName ="Spider-Man: No Way Home",
                            MovieDescription ="As Spider-Man's identity is revealed and he is no longer able to keep Peter Parker's life out of that of Spider-Man, he turns to Doctor Strange for help, but things take a dangerous turn when he realizes what it takes to be who he is." ,
                            MovieImageURL ="../images/movies/SpiderMan1.jpg",
                            MovieRate ="All Ages",
                            MovieRunningTime ="150 minutes" ,
                            MovieReleaseDate = new DateTime(2021, 12, 15) ,
                            LanguageId =2 ,
                            CountryId =2,
                        },
                        new Movie()
                        {
                          Id = 11,
                            MovieName ="No Time to Die",
                            MovieDescription ="After leaving the service for some time ago, MI6 agent James Bond is thrust back into action after his old CIA friend Felix Leiter recruits him to find a missing scientist which will send him into a dangerous path against a mysterious villain armed with lethal new technology." ,
                            MovieImageURL ="../images/movies/NoTimetoDie1.jpg",
                            MovieRate ="+12",
                            MovieRunningTime ="174 minutes" ,
                            MovieReleaseDate = new DateTime(2021, 12, 30) ,
                            LanguageId =2 ,
                            CountryId =3,
                        },
                        new Movie()
                        {
                          Id = 12,
                            MovieName ="DC League of Super-Pets",
                            MovieDescription ="As Lex Luthor kidnaps the Justice League, Krypto, Superman's dog, sets out to save his buddy by bringing together a motley crew of shelter animals, each of whom gets a superpower, to take on the villain and set the superheroes free." ,
                            MovieImageURL ="../images/movies/SuperPets1.jpg",
                            MovieRate ="All Ages",
                            MovieRunningTime ="102 minutes" ,
                            MovieReleaseDate = new DateTime(2023, 5, 18) ,
                            LanguageId =2 ,
                            CountryId =2,
                        },
                        new Movie()
                        {
                          Id = 13,
                            MovieName ="The Secrets of Dumbledore",
                            MovieDescription ="After being tasked by Professor Albus Dumbledore with putting a halt to Gellert Grindelwald's evil plans, Newt Scamander sets out with a fearless band of wizards and witches on a mission fraught with danger to take on the evil Grindelwald." ,
                            MovieImageURL ="../images/movies/TheSecretsofDumbledore1.jpg",
                            MovieRate ="+16",
                            MovieRunningTime ="192 minutes" ,
                            MovieReleaseDate = new DateTime(2023, 4, 7) ,
                            LanguageId =2,
                            CountryId =3,
                        },
                        new Movie()
                        {
                          Id = 14,
                            MovieName ="Panama",
                            MovieDescription ="While in Panama for an arms deal, the former marine  James Becker gets more than he bargained for as the US launches its invasion on Panama. As the political atmosphere turns turbulent, Becker finds his mission becoming much more complicated as his very survival hangs on the line." ,
                            MovieImageURL ="../images/movies/Panama1.jpg",
                            MovieRate ="+16",
                            MovieRunningTime =" 156 minutes" ,
                            MovieReleaseDate = new DateTime(2023, 6, 2) ,
                            LanguageId =2 ,
                            CountryId =2,
                        },
                        new Movie()
                        {
                          Id = 15,
                            MovieName ="Doctor Strange 2",
                            MovieDescription ="While in Panama for an arms deal, the former marine  James Becker gets more than he bargained for as the US launches its invasion on Panama. As the political atmosphere turns turbulent, Becker finds his mission becoming much more complicated as his very survival hangs on the line." ,
                            MovieImageURL ="../images/movies/DoctorStrange1.jpg",
                            MovieRate ="+12",
                            MovieRunningTime =" 120 minutes" ,
                            MovieReleaseDate = new DateTime(2023, 5, 4) ,
                            LanguageId =2 ,
                            CountryId =2,
                        },
                        new Movie()
                        {
                          Id = 16,
                            MovieName ="Ambulance",
                            MovieDescription ="As a war veteran attempts to raise money for his wife's surgery, his adoptive brother talks him into pulling a heist with him, but when their plan miscarries, they end up stealing an ambulance and taking a fatally wounded officer and an EMT as hostages." ,
                            MovieImageURL ="../images/movies/Ambulance1.jpg",
                            MovieRate ="+12",
                            MovieRunningTime =" 120 minutes" ,
                            MovieReleaseDate = new DateTime(2023, 5, 4) ,
                            LanguageId =2 ,
                            CountryId =2,
                        },
                };
            modelBuilder.Entity<Movie>().HasData(Movies);
            //  Movie - Gallary
            var MoviesGallary = new List<Movie_Gallery>()
                {
                     new Movie_Gallery()
                        {
                            Id = 1 ,
                            ImageURL="../images/movies/Batman1.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        { 
                            Id = 2 , 
                            ImageURL="../images/movies/Batman2.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        { 
                            Id = 3 , 
                            ImageURL="../images/movies/Batman3.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        {
                            Id = 4 , 
                            ImageURL="../images/movies/Batman4.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        { 
                            Id = 5 , 
                            ImageURL="../images/movies/Batman5.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        {
                            Id = 6 ,
                            ImageURL="../images/movies/Batman6.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        {
                            Id = 7 ,
                            ImageURL="../images/movies/Batman7.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        { 
                            Id = 8 ,
                            ImageURL="../images/movies/Batman8.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        {
                            Id = 9 ,
                            ImageURL="../images/movies/Batman9.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        { 
                            Id = 10 ,
                            ImageURL="../images/movies/Batman10.jpg" ,
                            MovieId = 1
                        },
                        new Movie_Gallery()
                        {
                            Id = 11 , 
                            ImageURL="../images/movies/Uncharted1.jpg" ,
                            MovieId = 2
                        },
                        new Movie_Gallery()
                        { 
                            Id = 12 , 
                            ImageURL="../images/movies/Uncharted2.jpg" ,
                            MovieId = 2
                        },
                        new Movie_Gallery()
                        {
                            Id = 13 , 
                            ImageURL="../images/movies/Uncharted3.jpg" ,
                            MovieId = 2
                        },
                        new Movie_Gallery()
                        {
                            Id = 14 , 
                            ImageURL="../images/movies/Uncharted4.jpg" ,
                            MovieId = 2
                        },
                        new Movie_Gallery()
                        {
                            Id = 15 , 
                            ImageURL="../images/movies/Uncharted5.jpg" ,
                            MovieId = 2
                        },
                        new Movie_Gallery()
                        { 
                            Id = 16 ,
                            ImageURL="../images/movies/Uncharted6.jpg" ,
                            MovieId = 2
                        },
                        new Movie_Gallery()
                        {
                            Id = 17 ,
                            ImageURL="../images/movies/HamelElLakab1.jpg" ,
                            MovieId = 3
                        },
                        new Movie_Gallery()
                        {
                            Id = 18 ,
                            ImageURL="../images/movies/HamelElLakab2.jpg" ,
                            MovieId = 3
                        },
                        new Movie_Gallery()
                        {
                            Id = 19 , 
                            ImageURL="../images/movies/HamelElLakab3.jpg" ,
                            MovieId = 3
                        },
                        new Movie_Gallery()
                        {
                            Id = 20 , 
                            ImageURL="../images/movies/HamelElLakab4.jpg" ,
                            MovieId = 3
                        },
                        new Movie_Gallery()
                        {
                            Id = 21 , 
                            ImageURL="../images/movies/HamelElLakab5.jpg" ,
                            MovieId = 3
                        },
                        new Movie_Gallery()
                        {
                            Id = 22 , 
                            ImageURL="../images/movies/Contractor1.jpg" ,
                            MovieId = 4
                        },
                        new Movie_Gallery()
                        {
                            Id = 23 , 
                            ImageURL="../images/movies/Contractor2.jpg" ,
                            MovieId = 4
                        },
                        new Movie_Gallery()
                        { 
                            Id = 24 ,
                            ImageURL="../images/movies/TurningRed1.jpg" ,
                            MovieId = 5
                        },
                        new Movie_Gallery()
                        {
                            Id = 25 , 
                            ImageURL="../images/movies/TurningRed2.jpg" ,
                            MovieId = 5
                        },
                        new Movie_Gallery()
                        {
                            Id = 26 ,
                            ImageURL="../images/movies/TurningRed3.jpg" ,
                            MovieId = 5
                        },
                        new Movie_Gallery()
                        {
                            Id = 27 ,
                            ImageURL="../images/movies/TurningRed4.jpg" ,
                            MovieId = 5
                        },
                        new Movie_Gallery()
                        { 
                            Id = 28 ,
                            ImageURL="../images/movies/TurningRed5.jpg" ,
                            MovieId = 5
                        },
                        new Movie_Gallery()
                        {
                            Id = 29 ,
                            ImageURL="../images/movies/TurningRed6.jpg" ,
                            MovieId = 5
                        },
                        new Movie_Gallery()
                        {
                            Id = 30 ,
                            ImageURL="../images/movies/TurningRed7.jpg" ,
                            MovieId = 5
                        },
                        new Movie_Gallery()
                        {
                            Id = 31 ,
                            ImageURL="../images/movies/TurningRed8.jpg" ,
                            MovieId = 5
                        },
                        new Movie_Gallery()
                        { 
                            Id = 32 ,
                            ImageURL="../images/movies/DeathontheNile1.jpg" ,
                            MovieId = 6
                        },
                        new Movie_Gallery()
                        {
                            Id = 33 ,
                            ImageURL="../images/movies/DeathontheNile2.jpg" ,
                            MovieId = 6
                        },
                        new Movie_Gallery()
                        {
                            Id = 34 ,
                            ImageURL="../images/movies/DeathontheNile3.jpg" ,
                            MovieId = 6
                        },
                        new Movie_Gallery()
                        {
                            Id = 35 , 
                            ImageURL="../images/movies/DeathontheNile4.jpg" ,
                            MovieId = 6
                        },
                        new Movie_Gallery()
                        {
                            Id = 36 ,
                            ImageURL="../images/movies/DeathontheNile5.jpg" ,
                            MovieId = 6
                        },
                        new Movie_Gallery()
                        {
                            Id = 37 ,
                            ImageURL="../images/movies/DeathontheNile6.jpg" ,
                            MovieId = 6
                        },
                        new Movie_Gallery()
                        { 
                            Id = 38 ,
                            ImageURL="../images/movies/DeathontheNile7.jpg" ,
                            MovieId = 6
                        },
                        new Movie_Gallery()
                        {
                            Id = 39 ,
                            ImageURL="../images/movies/DeathontheNile8.jpg" ,
                            MovieId = 6
                        },
                        new Movie_Gallery()
                        {
                            Id = 40 ,
                            ImageURL="../images/movies/MenAglZeko1.jpg" ,
                            MovieId = 7
                        },
                        new Movie_Gallery()
                        {
                            Id = 41 ,
                            ImageURL="../images/movies/MenAglZeko2.jpg" ,
                            MovieId = 7
                        },
                        new Movie_Gallery()
                        {
                            Id = 42 ,
                            ImageURL="../images/movies/MenAglZeko3.jpg" ,
                            MovieId = 7
                        },
                        new Movie_Gallery()
                        {
                            Id = 43 ,
                            ImageURL="../images/movies/MenAglZeko4.jpg" ,
                            MovieId = 7
                        },
                        new Movie_Gallery()
                        {
                            Id = 44,
                            ImageURL="../images/movies/MenAglZeko5.jpg" ,
                            MovieId = 7
                        },
                        new Movie_Gallery()
                        {
                            Id = 45 ,
                            ImageURL="../images/movies/MenAglZeko6.jpg" ,
                            MovieId = 7
                        },
                        new Movie_Gallery()
                        {
                            Id = 46 ,
                            ImageURL="../images/movies/ElGareema1.jpg" ,
                            MovieId = 8
                        },
                        new Movie_Gallery()
                        {
                            Id = 47 ,
                            ImageURL="../images/movies/ElGareema2.jpg" ,
                            MovieId = 8
                        },
                        new Movie_Gallery()
                        {
                            Id = 48 ,
                            ImageURL="../images/movies/ElGareema3.jpg" ,
                            MovieId = 8
                        },
                        new Movie_Gallery()
                        {
                            Id = 49 ,
                            ImageURL="../images/movies/ElGareema4.jpg" ,
                            MovieId = 8
                        },
                        new Movie_Gallery()
                        {
                            Id = 50 ,
                            ImageURL="../images/movies/ElGareema5.jpg" ,
                            MovieId = 8
                        },
                        new Movie_Gallery()
                        {
                            Id = 51 ,
                            ImageURL="../images/movies/ElGareema6.jpg" ,
                            MovieId = 8
                        },
                        new Movie_Gallery()
                        {
                            Id = 52 ,
                            ImageURL="../images/movies/ElGareema7.jpg" ,
                            MovieId = 8
                        },
                        new Movie_Gallery()
                        {
                            Id = 53 ,
                            ImageURL="../images/movies/ElGareema8.jpg" ,
                            MovieId = 8
                        },
                        new Movie_Gallery()
                        {
                            Id = 54 ,
                            ImageURL="../images/movies/ElGareema9.jpg" ,
                            MovieId = 8
                        },
                        new Movie_Gallery()
                        {
                            Id = 55 ,
                            ImageURL="../images/movies/SpiderMan1.jpg" ,
                            MovieId = 9
                        },
                        new Movie_Gallery()
                        {
                            Id = 56, 
                            ImageURL="../images/movies/SpiderMan2.jpg" ,
                            MovieId = 9
                        },
                        new Movie_Gallery()
                        {
                            Id = 57 ,
                            ImageURL="../images/movies/SpiderMan3.jpg" ,
                            MovieId = 9
                        },
                        new Movie_Gallery()
                        {
                            Id = 58 ,
                            ImageURL="../images/movies/SpiderMan4.jpg" ,
                            MovieId = 9
                        },
                        new Movie_Gallery()
                        {
                            Id = 59 ,
                            ImageURL="../images/movies/SpiderMan5.jpg" ,
                            MovieId = 9
                        },
                        new Movie_Gallery()
                        {
                            Id = 60 ,
                            ImageURL="../images/movies/SpiderMan6.jpg" ,
                            MovieId = 9
                        },
                        new Movie_Gallery()
                        {
                            Id = 61 ,
                            ImageURL="../images/movies/SpiderMan7.jpg" ,
                            MovieId = 9
                        },
                        new Movie_Gallery()
                        {
                            Id = 62 ,
                            ImageURL="../images/movies/SpiderMan8.jpg" ,
                            MovieId = 9
                        },
                        new Movie_Gallery()
                        {
                            Id = 67 , 
                            ImageURL="../images/movies/NoTimetoDie1.jpg" ,
                            MovieId = 11
                        },
                        new Movie_Gallery()
                        {
                            Id = 68 ,
                            ImageURL="../images/movies/NoTimetoDie2.jpg" ,
                            MovieId = 11
                        },
                        new Movie_Gallery()
                        {
                            Id = 69 , 
                            ImageURL="../images/movies/NoTimetoDie3.jpg" ,
                            MovieId = 11
                        },
                        new Movie_Gallery()
                        {
                            Id = 70 , 
                            ImageURL="../images/movies/NoTimetoDie4.jpg" ,
                            MovieId = 11
                        },
                        new Movie_Gallery()
                        {
                            Id = 71 , 
                            ImageURL="../images/movies/NoTimetoDie5.jpg" ,
                            MovieId = 11
                        },
                        new Movie_Gallery()
                        {
                            Id = 72 , 
                            ImageURL="../images/movies/NoTimetoDie6.jpg" ,
                            MovieId = 11
                        },
                        new Movie_Gallery()
                        {
                            Id = 73 , 
                            ImageURL="../images/movies/NoTimetoDie7.jpg" ,
                            MovieId = 11
                        },
                        new Movie_Gallery()
                        {
                            Id = 74 , 
                            ImageURL="../images/movies/NoTimetoDie8.jpg" ,
                            MovieId = 11
                        },
                        new Movie_Gallery()
                        {
                            Id = 75 , 
                            ImageURL="../images/movies/NoTimetoDie9.jpg" ,
                            MovieId = 11
                        },
                        new Movie_Gallery()
                        {
                            Id = 76 , 
                            ImageURL="../images/movies/SuperPets1.jpg" ,
                            MovieId = 12
                        },
                        new Movie_Gallery()
                        {
                            Id = 77 , 
                            ImageURL="../images/movies/SuperPets2.jpg" ,
                            MovieId = 12
                        },
                        new Movie_Gallery()
                        {
                            Id = 78, 
                            ImageURL="../images/movies/TheSecretsofDumbledore1.jpg" ,
                            MovieId = 13
                        },
                        new Movie_Gallery()
                        {
                            Id = 79 ,
                            ImageURL="../images/movies/TheSecretsofDumbledore2.jpg" ,
                            MovieId = 13
                        },
                        new Movie_Gallery()
                        {
                            Id = 80, 
                            ImageURL="../images/movies/TheSecretsofDumbledore3.jpg" ,
                            MovieId = 13
                        },
                        new Movie_Gallery()
                        {
                            Id = 81 , 
                            ImageURL="../images/movies/TheSecretsofDumbledore4.jpg" ,
                            MovieId = 13
                        },
                        new Movie_Gallery()
                        {
                            Id = 82 , 
                            ImageURL="../images/movies/TheSecretsofDumbledore5.jpg" ,
                            MovieId = 13
                        },
                        new Movie_Gallery()
                        {
                            Id = 83 ,
                            ImageURL="../images/movies/TheSecretsofDumbledore6.jpg" ,
                            MovieId = 13
                        },
                        new Movie_Gallery()
                        {
                            Id = 84 ,
                            ImageURL="../images/movies/TheSecretsofDumbledore7.jpg" ,
                            MovieId = 13
                        },
                        new Movie_Gallery()
                        {
                            Id = 85 , 
                            ImageURL="../images/movies/TheSecretsofDumbledore8.jpg" ,
                            MovieId = 13
                        },
                        new Movie_Gallery()
                        {
                            Id = 86 ,
                            ImageURL="../images/movies/Panama1.jpg" ,
                            MovieId = 14
                        },
                        new Movie_Gallery()
                        {
                            Id = 87 , 
                            ImageURL="../images/movies/Panama2.jpg" ,
                            MovieId = 14
                        },
                        new Movie_Gallery()
                        {
                            Id = 88,
                            ImageURL="../images/movies/DoctorStrange1.jpg" ,
                            MovieId = 15
                        },
                        new Movie_Gallery()
                        {
                            Id = 89 , 
                            ImageURL="../images/movies/DoctorStrange2.jpg" ,
                            MovieId = 15
                        },
                        new Movie_Gallery()
                        {
                            Id = 90 , 
                            ImageURL="../images/movies/DoctorStrange3.jpg" ,
                            MovieId = 15
                        },
                        new Movie_Gallery()
                        {
                            Id = 91 , 
                            ImageURL="../images/movies/DoctorStrange4.jpg" ,
                            MovieId = 15
                        },
                        new Movie_Gallery()
                        {
                            Id = 92 , 
                            ImageURL="../images/movies/Ambulance1.jpg" ,
                            MovieId = 16
                        },
                        new Movie_Gallery()
                        {
                            Id = 93 , 
                            ImageURL="../images/movies/Ambulance2.jpg" ,
                            MovieId = 16
                        },
                        new Movie_Gallery()
                        {
                            Id = 94 , 
                            ImageURL="../images/movies/Ambulance3.jpg" ,
                            MovieId = 16
                        },
                        new Movie_Gallery()
                        {
                            Id = 95 , 
                            ImageURL="../images/movies/Ambulance4.jpg" ,
                            MovieId = 16
                        },
                        new Movie_Gallery()
                        {
                            Id = 96 , 
                            ImageURL="../images/movies/Ambulance5.jpg" ,
                            MovieId = 16
                        },
                        new Movie_Gallery()
                        {
                            Id = 97 , 
                            ImageURL="../images/movies/Ambulance6.jpg" ,
                            MovieId = 16
                        },
                        new Movie_Gallery()
                        {
                            Id = 98 , 
                            ImageURL="../images/movies/Ambulance7.jpg" ,
                            MovieId = 16
                        },
                        new Movie_Gallery()
                        {
                            Id = 99 , 
                            ImageURL="../images/movies/Ambulance8.jpg" ,
                            MovieId = 16
                        },
                };
            modelBuilder.Entity<Movie_Gallery>().HasData(MoviesGallary);
            // Genres - Movie
            var GenresMovie = new List<Genre_Movie>()
                {
                        new Genre_Movie()
                        {
                            GenreId = 1,
                            MovieId = 1
                        },
                        new Genre_Movie()
                        {
                            GenreId = 14,
                            MovieId = 1
                        },
                        new Genre_Movie()
                        {
                            GenreId = 3,
                            MovieId = 1
                        },
                        new Genre_Movie()
                        {
                            GenreId =6,
                            MovieId =1
                        },
                        new Genre_Movie()
                        {
                            GenreId =1,
                            MovieId =2
                        },
                        new Genre_Movie()
                        {
                            GenreId =11,
                            MovieId =2
                        },
                        new Genre_Movie()
                        {
                            GenreId =2,
                            MovieId =3
                        },
                        new Genre_Movie()
                        {
                            GenreId =1,
                            MovieId =4
                        },
                        new Genre_Movie()
                        {
                            GenreId =13,
                            MovieId =4
                        },
                        new Genre_Movie()
                        {
                            GenreId =15,
                            MovieId =5
                        },
                        new Genre_Movie()
                        {
                            GenreId =16,
                            MovieId =5
                        },
                        new Genre_Movie()
                        {
                            GenreId =17,
                            MovieId =5
                        },
                        new Genre_Movie()
                        {
                            GenreId =2,
                            MovieId =5
                        },
                        new Genre_Movie()
                        {
                            GenreId =14,
                            MovieId =6
                        },
                        new Genre_Movie()
                        {
                            GenreId =3,
                            MovieId =6
                        },
                        new Genre_Movie()
                        {
                            GenreId =6,
                            MovieId =6
                        },
                        new Genre_Movie()
                        {
                            GenreId =2,
                            MovieId =7
                        },
                        new Genre_Movie()
                        {
                            GenreId =1,
                            MovieId =8
                        },
                        new Genre_Movie()
                        {
                            GenreId =13,
                            MovieId =8
                        },
                        new Genre_Movie()
                        {
                            GenreId =14,
                            MovieId =8
                        },
                        new Genre_Movie()
                        {
                            GenreId =18,
                            MovieId =9
                        },
                        new Genre_Movie()
                        {
                            GenreId =1,
                            MovieId =9
                        },
                        new Genre_Movie()
                        {
                            GenreId =16,
                            MovieId =9
                        },
                        new Genre_Movie()
                        {
                            GenreId =1,
                            MovieId =11
                        },
                        new Genre_Movie()
                        {
                            GenreId =13,
                            MovieId =11
                        },
                        new Genre_Movie()
                        {
                            GenreId =16,
                            MovieId =11
                        },
                        new Genre_Movie()
                        {
                            GenreId =3,
                            MovieId =12
                        },
                        new Genre_Movie()
                        {
                            GenreId =11,
                            MovieId =12
                        },
                        new Genre_Movie()
                        {
                            GenreId =12,
                            MovieId =12
                        },
                        new Genre_Movie()
                        {
                            GenreId =17,
                            MovieId =12
                        },
                        new Genre_Movie()
                        {
                            GenreId =14,
                            MovieId =12
                        },
                        new Genre_Movie()
                        {
                            GenreId =18,
                            MovieId =12
                        },
                        new Genre_Movie()
                        {
                            GenreId =2,
                            MovieId =12
                        },
                        new Genre_Movie()
                        {
                            GenreId =4,
                            MovieId =12
                        },
                        new Genre_Movie()
                        {
                            GenreId =14,
                            MovieId =13
                        },
                        new Genre_Movie()
                        {
                            GenreId =17,
                            MovieId =13
                        },
                        new Genre_Movie()
                        {
                            GenreId =2,
                            MovieId =13
                        },
                        new Genre_Movie()
                        {
                            GenreId =10,
                            MovieId =14
                        },
                        new Genre_Movie()
                        {
                            GenreId =11,
                            MovieId =14
                        },
                        new Genre_Movie()
                        {
                            GenreId =14,
                            MovieId =15
                        },
                        new Genre_Movie()
                        {
                            GenreId =11,
                            MovieId =15
                        },
                        new Genre_Movie()
                        {
                            GenreId =12,
                            MovieId =15
                        },
                        new Genre_Movie()
                        {
                            GenreId =18,
                            MovieId =15
                        },
                        new Genre_Movie()
                        {
                            GenreId =15,
                            MovieId =15
                        },
                        new Genre_Movie()
                        {
                            GenreId =14,
                            MovieId =16
                        },
                        new Genre_Movie()
                        {
                            GenreId =3,
                            MovieId =16
                        },
                        new Genre_Movie()
                        {
                            GenreId =1,
                            MovieId =16
                        },
                        new Genre_Movie()
                        {
                            GenreId =8,
                            MovieId =16
                        },
                };
            modelBuilder.Entity<Genre_Movie>().HasData(GenresMovie);

            // Theaters
            var Theaters = new List<Theater>()
                {
                        new Theater()
                        {
                         Id=1,
                            TheaterName ="IMAX, Americana Mall Cinema" ,
                            TheaterDetails ="* The IMAX screen is one of Americana Plaza theater's diverse screens./* For 3D films, the ticket price does not include the price of the 3D glasses. The 3D glasses are available for a rental price of EGP 10.",
                            TheaterLocation ="Americana Plaza Mall, Sheikh Zayed, 6th of October City",
                            TheaterImageURL ="../images/theaters/IMAX.jpg"
                        },
                        new Theater()
                        {
                         Id=2,
                            TheaterName ="Point 90 Cinema" ,
                            TheaterDetails ="* For 3D films, the ticket price does not include the price of the 3D glasses./* It is not allowed to take children under 4 years of age into the theater.",
                            TheaterLocation ="90Street, Point90 Mall in front of AUC gate 5 , New Cairo",
                            TheaterImageURL ="../images/theaters/Point90.jpg"
                        },
                        new Theater()
                        {
                         Id=3,
                            TheaterName ="Plaza Cinemas, Americana Mall Cinema" ,
                            TheaterDetails ="For 3D films, the ticket price does not include the price of the 3D glasses.",
                            TheaterLocation ="Americana Plaza Mall, Sheikh Zayed , 6th of October City",
                            TheaterImageURL ="../images/theaters/PlazaCinemas.png"
                        },
                        new Theater()
                        {
                         Id=4,
                            TheaterName ="Arkan Cinema" ,
                            TheaterDetails ="* For 3D films, the ticket price does not include the price of the 3D glasses./* It is not allowed to take children under 4 years of age into the theater.",
                            TheaterLocation ="26th of July Corridor - Arkan Plaza Mall , 6th of October City",
                            TheaterImageURL ="../images/theaters/ArkanCinema.png"
                        },
                        new Theater()
                        {
                         Id=5,
                            TheaterName ="Galaxy ElMaadi Cinema" ,
                            TheaterDetails ="For 3D films, the ticket price does not include the price of the 3D glasses.",
                            TheaterLocation ="Osman Towers, Corniche El Nil , Maadi",
                            TheaterImageURL ="../images/theaters/GalaxyElMaadi.jpg"
                        },
                        new Theater()
                        {
                         Id=6,
                            TheaterName ="Sun City Cinema" ,
                            TheaterDetails ="* For 3D films, the ticket price does not include the price of the 3D glasses./* It is not allowed to take children under 12 years of age into the theater./* The theater has Dolby Atmos sound technology which fills the theater with audio from the sides, the back end and above head. The sound flows all around the audience in sync with the action on the screen. /* The theater has a limited number of luxurious, comfortable seats./* Please note that the seats are unmoving not movable",
                            TheaterLocation ="Behind Masaken Sheraton, Sun City Mall , Heliopolis",
                            TheaterImageURL ="../images/theaters/SunCity.jpg"
                        },
                        new Theater()
                        {
                         Id=7,
                            TheaterName ="Plaza CineComfort Cinema" ,
                            TheaterDetails ="* For 3D films, the ticket price does not include the price of the 3D glasses./* There are two distinctive CineComfort screens in Americana Plaza theater, and each one hosts 66 luxury seats.",
                            TheaterLocation ="Americana Plaza Mall, Sheikh Zayed , 6th of October City",
                            TheaterImageURL ="../images/theaters/CineComfort.jpg"
                        },
                        new Theater()
                        {
                         Id=8,
                            TheaterName ="Zamalek Cinema" ,
                            TheaterDetails ="* For 3D films, the ticket price does not include the price of the 3D glasses./* This theater contains Balcony Level seats for a ticket price of EGP 150./* showing the Cairo International Film Festival",
                            TheaterLocation ="13Shagaret El Dor St., Zamalek - Cairo ",
                            TheaterImageURL ="../images/theaters/ZamalekCinema.jpg"
                        },
                        new Theater()
                        {
                         Id=9,
                            TheaterName ="Grand Hyatt Cinema" ,
                            TheaterDetails ="",
                            TheaterLocation ="inside the Grand Nile Tower Hotel, Corniche El Nil , Garden City",
                            TheaterImageURL ="../images/theaters/GrandHyatt.jpg"
                        },
                        new Theater()
                        {
                         Id=10,
                            TheaterName ="Grand Hurghada Cinema" ,
                            TheaterDetails ="For 3D films, the ticket price does not include the price of the 3D glasses.",
                            TheaterLocation ="city center Mall، Qesm Hurghada, Red Sea Governorate ",
                            TheaterImageURL ="../images/theaters/GrandHurghada.jpg"
                        },
                };
            modelBuilder.Entity<Theater>().HasData(Theaters);
            // Screens
            var Screens = new List<Screen>()
                {
                      new Screen()
                        {
                            Id = 1,
                            ScreenName = "IMax",
                            TheaterId = 1
                        },
                        new Screen()
                        {
                            Id = 2,
                            ScreenName ="Screen 1",
                            TheaterId = 2
                        },
                        new Screen()
                        {
                            Id =  3,
                            ScreenName ="Screen 2",
                            TheaterId = 2
                        },
                        new Screen()
                        {
                            Id = 4,
                            ScreenName ="Screen 3",
                            TheaterId = 2
                        },
                        new Screen()
                        {
                            Id = 5,
                            ScreenName ="Screen 4",
                            TheaterId = 2
                        },
                        new Screen()
                        {
                            Id = 6,
                            ScreenName ="Screen 5",
                            TheaterId = 2
                        },
                        new Screen()
                        {
                            Id = 7,
                            ScreenName ="Screen 6",
                            TheaterId = 2
                        },
                        new Screen()
                        {
                            Id = 8,
                            ScreenName ="MX4D",
                            TheaterId = 2
                        },
                        new Screen()
                        {
                            Id = 9,
                            ScreenName ="Screen 1",
                            TheaterId = 3
                        },
                        new Screen()
                        {
                            Id = 10,
                            ScreenName ="Screen 2",
                            TheaterId = 3
                        },
                        new Screen()
                        {
                            Id = 11,
                            ScreenName ="Screen 4",
                            TheaterId = 3
                        },
                        new Screen()
                        {
                            Id = 12,
                            ScreenName ="Screen 8",
                            TheaterId = 3
                        },
                        new Screen()
                        {
                            Id = 13,
                            ScreenName ="Screen 9",
                            TheaterId = 3
                        },
                        new Screen()
                        {
                           Id = 14,
                            ScreenName ="Screen 10",
                            TheaterId = 3
                        },
                        new Screen()
                        {
                            Id = 15,
                            ScreenName ="Screen 11",
                            TheaterId = 3
                        },
                        new Screen()
                        {
                            Id = 16,
                            ScreenName ="MX4D",
                            TheaterId = 3
                        },
                        new Screen()
                        {
                            Id = 17,
                            ScreenName ="CIMA 1",
                            TheaterId = 4
                        },
                        new Screen()
                        {
                            Id = 18,
                            ScreenName ="CIMA 2",
                            TheaterId = 4
                        },
                        new Screen()
                        {
                            Id = 19,
                            ScreenName ="CIMA 3",
                            TheaterId = 4
                        },
                        new Screen()
                        {
                            Id = 20,
                            ScreenName ="CIMA 4",
                            TheaterId = 4
                        },
                        new Screen()
                        {
                            Id = 21,
                            ScreenName ="CIMA 5",
                            TheaterId = 4
                        },
                        new Screen()
                        {
                            Id =22,
                            ScreenName ="CIMA 6",
                            TheaterId = 4
                        },
                        new Screen()
                        {
                            Id = 23,
                            ScreenName ="CIMA Plus",
                            TheaterId = 4
                        },
                        new Screen()
                        {
                            Id = 24,
                            ScreenName ="MAX CIMA",
                            TheaterId = 4
                        },
                        new Screen()
                        {
                            Id = 25,
                            ScreenName ="Screen 1",
                            TheaterId = 5
                        },
                        new Screen()
                        {
                            Id = 26,
                            ScreenName = "Screen 3",
                            TheaterId = 5
                        },
                        new Screen()
                        {
                            Id = 27,
                            ScreenName = "Screen 4",
                            TheaterId = 5
                        },
                        new Screen()
                        {
                            Id = 28,
                            ScreenName ="Screen 5",
                            TheaterId = 5
                        },
                        new Screen()
                        {
                            Id = 29,
                            ScreenName ="Screen 7",
                            TheaterId = 5
                        },
                        new Screen()
                        {
                            Id = 30,
                            ScreenName = "Screen 8",
                            TheaterId  = 5
                        },
                        new Screen()
                        {
                            Id =31,
                            ScreenName ="Dine in",
                            TheaterId = 5
                        },
                        new Screen()
                        {
                            Id = 32,
                            ScreenName ="VIP",
                            TheaterId = 5
                        },
                        new Screen()
                        {
                            Id = 33,
                            ScreenName ="Screen 1",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 34,
                            ScreenName ="Screen 2",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 35,
                            ScreenName ="Screen 3",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 36,
                            ScreenName ="Screen 4",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 37,
                            ScreenName ="Screen 5",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 38,
                            ScreenName ="Screen 6",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 39,
                            ScreenName ="Screen 7",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 40,
                            ScreenName ="Screen 8",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 41,
                            ScreenName ="Screen 9",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 42,
                            ScreenName ="Screen 10",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 43,
                            ScreenName ="Screen 11",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 44,
                            ScreenName ="Screen 12",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 45,
                            ScreenName ="VIP 3",
                            TheaterId = 6
                        },
                        new Screen()
                        {
                            Id = 46,
                            ScreenName ="CineComfort 1",
                            TheaterId = 7
                        },
                        new Screen()
                        {
                            Id = 47,
                            ScreenName ="CineComfort 2",
                            TheaterId = 7
                        },
                        new Screen()
                        {
                            Id = 48,
                            ScreenName ="Screen 1",
                            TheaterId = 8
                        },
                        new Screen()
                        {
                            Id = 49,
                            ScreenName ="Screen 2",
                            TheaterId = 8
                        },
                        new Screen()
                        {
                            Id = 50,
                            ScreenName ="Screen 1",
                            TheaterId = 9
                        },
                        new Screen()
                        {
                            Id = 51, 
                            ScreenName ="Screen 2",
                            TheaterId = 9
                        },
                        new Screen()
                        {
                            Id = 52,
                            ScreenName ="Screen 1",
                            TheaterId = 10
                        },
                        new Screen()
                        {
                            Id = 53,
                            ScreenName ="Screen 2",
                            TheaterId = 10
                        },
                        new Screen()
                        {
                            Id = 54,
                            ScreenName ="Screen 3",
                            TheaterId = 10
                        },
                        new Screen()
                        {
                            Id = 55,
                            ScreenName ="Screen 4",
                            TheaterId = 10
                        },
                        new Screen()
                        {
                            Id = 56, ScreenName ="Screen 5",
                            TheaterId = 10
                        },
                };
            modelBuilder.Entity<Screen>().HasData(Screens);
            // Show
            var Shows = new List<Show>()
                {
                    new Show()
                    {
                        Id = 1,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 23
                    },
                    new Show()
                    {
                        Id = 2,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 47
                    },
                    new Show()
                    {
                        Id = 3,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 32
                    },
                    new Show()
                    {
                        Id = 4,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 25

                    },
                    new Show()
                    {
                        Id = 5,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 26

                    },
                    new Show()
                    {
                        Id = 6,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 26

                    },
                    new Show()
                    {
                        Id = 7,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 45
                    },
                    new Show()
                    {
                        Id = 8,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 21

                    },
                    new Show()
                    {
                        Id = 9,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 51

                    },
                    new Show()
                    {
                        Id = 10,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 50
                    },
                    new Show()
                    {
                        Id = 11,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId = 4

                    },
                    new Show()
                    {
                        Id = 12,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId = 5

                    },
                    new Show()
                    {
                        Id = 13,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId = 48

                    },
                    new Show()
                    {
                        Id = 14,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 8

                    },
                    new Show()
                    {
                        Id = 15,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 24

                    },
                    new Show()
                    {
                        Id = 16,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 50

                    },
                    new Show()
                    {
                        Id = 17,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 53

                    },
                    new Show()
                    {
                        Id = 18,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 1

                    },
                    new Show()
                    {
                        Id = 19,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 37

                    },
                    new Show()
                    {
                        Id = 20,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 39

                    },
                    new Show()
                    {
                        Id = 21,
                        ShowStartDate = new DateTime(2022, 3, 2) ,
                        ShowEndDate= new DateTime(2024, 3, 2) ,
                        MovieId = 1,
                        ScreenId= 14
                    },
                    new Show()
                    {
                        Id = 22,
                        ShowStartDate = new DateTime(2022,2, 10) ,
                        ShowEndDate= new DateTime(2024, 2, 10) ,
                        MovieId = 2,
                        ScreenId= 27

                    },
                    new Show()
                    {
                        Id = 23,
                        ShowStartDate = new DateTime(2022,2, 10) ,
                        ShowEndDate= new DateTime(2024, 2, 10) ,
                        MovieId = 2,
                        ScreenId= 17

                    },
                    new Show()
                    {
                        Id = 24,
                        ShowStartDate = new DateTime(2022,2, 10) ,
                        ShowEndDate= new DateTime(2024, 2, 10) ,
                        MovieId = 2,
                        ScreenId= 2

                    },
                    new Show()
                    {
                        Id = 25,
                        ShowStartDate = new DateTime(2022,2, 10) ,
                        ShowEndDate= new DateTime(2024, 2, 10) ,
                        MovieId = 2,
                        ScreenId= 53

                    },
                    new Show()
                    {
                        Id = 26,
                        ShowStartDate = new DateTime(2022,2, 10) ,
                        ShowEndDate= new DateTime(2024, 2, 10) ,
                        MovieId = 2,
                        ScreenId= 35

                    },
                    new Show()
                    {
                        Id = 27,
                        ShowStartDate = new DateTime(2022,2, 10) ,
                        ShowEndDate= new DateTime(2024, 2, 10) ,
                        MovieId = 2,
                        ScreenId= 12
                    },
                    new Show()
                    {
                        Id = 28,
                        ShowStartDate = new DateTime(2022,2, 2) ,
                        ShowEndDate= new DateTime(2024, 2, 2) ,
                        MovieId = 3,
                        ScreenId= 30

                    },
                    new Show()
                    {
                        Id = 29,
                        ShowStartDate = new DateTime(2022,2, 2) ,
                        ShowEndDate= new DateTime(2024, 2, 2) ,
                        MovieId = 3,
                        ScreenId= 19

                    },
                    new Show()
                    {
                        Id = 30,
                        ShowStartDate = new DateTime(2022,2, 2) ,
                        ShowEndDate= new DateTime(2024, 2, 2) ,
                        MovieId = 3,
                        ScreenId= 50
                    },
                    new Show()
                    {
                        Id = 31,
                        ShowStartDate = new DateTime(2022,2, 2) ,
                        ShowEndDate= new DateTime(2024, 2, 2) ,
                        MovieId = 3,
                        ScreenId= 4

                    },
                    new Show()
                    {
                        Id = 32,
                        ShowStartDate = new DateTime(2022,2, 2) ,
                        ShowEndDate= new DateTime(2024, 2, 2) ,
                        MovieId = 3,
                        ScreenId= 49

                    },
                    new Show()
                    {
                        Id = 33,
                        ShowStartDate = new DateTime(2022,2, 2) ,
                        ShowEndDate= new DateTime(2024, 2, 2) ,
                        MovieId = 3,
                        ScreenId= 55

                    },
                    new Show()
                    {
                        Id = 34,
                        ShowStartDate = new DateTime(2022,2, 2) ,
                        ShowEndDate= new DateTime(2024, 2, 2) ,
                        MovieId = 3,
                        ScreenId= 36

                    },
                    new Show()
                    {
                        Id = 35,
                        ShowStartDate = new DateTime(2022,2, 2) ,
                        ShowEndDate= new DateTime(2024, 2, 2) ,
                        MovieId = 3,
                        ScreenId= 36

                    },
                    new Show()
                    {
                        Id = 36,
                        ShowStartDate = new DateTime(2022,2, 2) ,
                        ShowEndDate= new DateTime(2024, 2, 2) ,
                        MovieId = 3,
                        ScreenId= 13
                    },
                    new Show()
                    {
                        Id = 37,
                        ShowStartDate = new DateTime(2022,3, 9) ,
                        ShowEndDate= new DateTime(2024, 3, 9) ,
                        MovieId = 4,
                        ScreenId= 31

                    },
                    new Show()
                    {
                        Id = 38,
                        ShowStartDate = new DateTime(2022,3, 9) ,
                        ShowEndDate= new DateTime(2024, 3, 9) ,
                        MovieId = 4,
                        ScreenId= 22

                    },
                    new Show()
                    {
                        Id = 39,
                        ShowStartDate = new DateTime(2022,3, 9) ,
                        ShowEndDate= new DateTime(2024, 3, 9) ,
                        MovieId = 4,
                        ScreenId= 6

                    },
                    new Show()
                    {
                        Id = 40,
                        ShowStartDate = new DateTime(2022,3, 9) ,
                        ShowEndDate= new DateTime(2024, 3, 9) ,
                        MovieId = 4,
                        ScreenId= 56

                    },
                    new Show()
                    {
                        Id = 41,
                        ShowStartDate = new DateTime(2022,3, 9) ,
                        ShowEndDate= new DateTime(2024, 3, 9) ,
                        MovieId = 4,
                        ScreenId= 40

                    },
                    new Show()
                    {
                        Id = 42,
                        ShowStartDate = new DateTime(2022,3, 9) ,
                        ShowEndDate= new DateTime(2024, 3, 9) ,
                        MovieId = 4,
                        ScreenId= 15
                    },
                    new Show()
                    {
                        Id = 43,
                        ShowStartDate = new DateTime(2022,3, 10) ,
                        ShowEndDate= new DateTime(2024, 3, 10) ,
                        MovieId = 5,
                        ScreenId= 27

                    },
                    new Show()
                    {
                        Id = 44,
                        ShowStartDate = new DateTime(2022,3, 10) ,
                        ShowEndDate= new DateTime(2024, 3, 10) ,
                        MovieId = 5,
                        ScreenId= 18

                    },
                    new Show()
                    {
                        Id = 45,
                        ShowStartDate = new DateTime(2022,3, 10) ,
                        ShowEndDate= new DateTime(2024, 3, 10) ,
                        MovieId = 5,
                        ScreenId= 7

                    },
                    new Show()
                    {
                        Id = 46,
                        ShowStartDate = new DateTime(2022,3, 10) ,
                        ShowEndDate= new DateTime(2024, 3, 10) ,
                        MovieId = 5,
                        ScreenId= 54

                    },
                    new Show()
                    {
                        Id = 47,
                        ShowStartDate = new DateTime(2022,3, 10) ,
                        ShowEndDate= new DateTime(2024, 3, 10) ,
                        MovieId = 5,
                        ScreenId= 33

                    },
                    new Show()
                    {
                        Id = 48,
                        ShowStartDate = new DateTime(2022,3, 10) ,
                        ShowEndDate= new DateTime(2024, 3, 10) ,
                        MovieId = 5,
                        ScreenId= 11
                    },
                    new Show()
                    {
                        Id = 49,
                        ShowStartDate = new DateTime(2022,1, 5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 8,
                        ScreenId= 46

                    },
                    new Show()
                    {
                        Id = 50,
                        ShowStartDate = new DateTime(2022,1, 5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 8,
                        ScreenId= 29

                    },
                    new Show()
                    {
                        Id = 51,
                        ShowStartDate = new DateTime(2022,1, 5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 8,
                        ScreenId= 52

                    },
                    new Show()
                    {
                        Id = 52,
                        ShowStartDate = new DateTime(2022,1, 5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 8,
                        ScreenId= 7

                    },
                    new Show()
                    {
                        Id = 53,
                        ShowStartDate = new DateTime(2022,1, 5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 8,
                        ScreenId= 49

                    },
                    new Show()
                    {
                        Id = 54,
                        ShowStartDate = new DateTime(2022,1, 5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 8,
                        ScreenId= 56

                    },
                    new Show()
                    {
                        Id = 55,
                        ShowStartDate = new DateTime(2022,1, 5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 8,
                        ScreenId= 44
                    },
                    new Show()
                    {
                        Id = 56,
                        ShowStartDate = new DateTime(2022,2,9) ,
                        ShowEndDate= new DateTime(2024, 2, 9) ,
                        MovieId = 6,
                        ScreenId= 20

                    },
                    new Show()
                    {
                        Id = 57,
                        ShowStartDate = new DateTime(2022,2,9) ,
                        ShowEndDate= new DateTime(2024, 2, 9) ,
                        MovieId = 6,
                        ScreenId= 2

                    },
                    new Show()
                    {
                        Id = 58,
                        ShowStartDate = new DateTime(2022,2,9) ,
                        ShowEndDate= new DateTime(2024, 2, 9) ,
                        MovieId = 6,
                        ScreenId= 38

                    },
                    new Show()
                    {
                        Id = 59,
                        ShowStartDate = new DateTime(2022,2,9) ,
                        ShowEndDate= new DateTime(2024, 2, 9) ,
                        MovieId = 6,
                        ScreenId= 9
                    },
                    new Show()
                    {
                        Id = 60,
                        ShowStartDate = new DateTime(2022,1,5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 7,
                        ScreenId= 28
                    },
                    new Show()
                    {
                        Id = 61,
                        ShowStartDate = new DateTime(2022,1,5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 7,
                        ScreenId= 49

                    },
                    new Show()
                    {
                        Id = 62,
                        ShowStartDate = new DateTime(2022,1,5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 7,
                        ScreenId= 54

                    },
                    new Show()
                    {
                        Id = 63,
                        ShowStartDate = new DateTime(2022,1,5) ,
                        ShowEndDate= new DateTime(2024, 1, 5) ,
                        MovieId = 7,
                        ScreenId= 42
                    },
                    new Show()
                    {
                        Id = 64,
                        ShowStartDate = new DateTime(2021,2,15) ,
                        ShowEndDate= new DateTime(2022, 2, 15) ,
                        MovieId = 9,
                        ScreenId= 41
                    },
                    new Show()
                    {
                        Id = 65,
                        ShowStartDate = new DateTime(2021,2,15) ,
                        ShowEndDate= new DateTime(2022, 2, 15) ,
                        MovieId = 9,
                        ScreenId= 10
                    },
                    new Show()
                    {
                        Id = 66,
                        ShowStartDate = new DateTime(2021,1,5) ,
                        ShowEndDate= new DateTime(2022, 1, 5) ,
                        MovieId = 11,
                        ScreenId= 1
                    },
                    new Show()
                    {
                        Id = 67,
                        ShowStartDate = new DateTime(2021,1,5) ,
                        ShowEndDate= new DateTime(2022, 1, 5) ,
                        MovieId = 11,
                        ScreenId= 40
                    },
                    new Show()
                    {
                        Id = 68,
                        ShowStartDate = new DateTime(2024,3,15) ,
                        ShowEndDate= new DateTime(2024, 4, 15) ,
                        MovieId = 12,
                        ScreenId= 2
                    },
                    new Show()
                    {
                        Id = 69,
                        ShowStartDate = new DateTime(2024,3,15) ,
                        ShowEndDate= new DateTime(2024, 4, 15) ,
                        MovieId = 12,
                        ScreenId= 10
                    },
                    new Show()
                    {
                        Id = 70,
                        ShowStartDate = new DateTime(2024,3,15) ,
                        ShowEndDate= new DateTime(2024, 4, 15) ,
                        MovieId = 13,
                        ScreenId= 14
                    },
                    new Show()
                    {
                        Id = 71,
                        ShowStartDate = new DateTime(2024,3,15) ,
                        ShowEndDate= new DateTime(2024, 4, 15) ,
                        MovieId = 13,
                        ScreenId= 20
                    },
                    new Show()
                    {
                        Id = 72,
                        ShowStartDate = new DateTime(2024,3,15) ,
                        ShowEndDate= new DateTime(2024, 4, 15) ,
                        MovieId = 14,
                        ScreenId= 17
                    },
                    new Show()
                    {
                        Id = 73,
                        ShowStartDate = new DateTime(2024,3,15) ,
                        ShowEndDate= new DateTime(2024, 4, 15) ,
                        MovieId = 14,
                        ScreenId= 50
                    },
                    new Show()
                    {
                        Id = 74,
                        ShowStartDate = new DateTime(2024,3,15) ,
                        ShowEndDate= new DateTime(2024, 4, 15) ,
                        MovieId = 15,
                        ScreenId= 42
                    },
                    new Show()
                    {
                        Id = 75,
                        ShowStartDate = new DateTime(2024,3,15) ,
                        ShowEndDate= new DateTime(2024, 4, 15) ,
                        MovieId = 15,
                        ScreenId= 15
                    },
                    new Show()
                    {
                        Id = 76,
                        ShowStartDate = new DateTime(2022,3,18) ,
                        ShowEndDate= new DateTime(2024, 5, 18) ,
                        MovieId = 16,
                        ScreenId= 1
                    },
                };
            modelBuilder.Entity<Show>().HasData(Shows);
            // Show - time 
            var ShowTimes = new List<Show_Time>()
                {
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 3 
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 4
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 23
               },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 24
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 27
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId =28
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 29
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 31
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 36
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 37
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 38
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 39
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 42
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 50
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 52
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 56
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 57
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 59
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 60
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 68
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 69
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 70
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 71
                   },
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 72
                   },
                   // ADD
                   new Show_Time()
                   {
                       TimeId = 1,
                       ShowId = 76
                   },
                   new Show_Time()
                   {
                       TimeId = 2,
                       ShowId = 5
                   },
                   new Show_Time()
                   {
                       TimeId = 2,
                       ShowId = 22
                   },
                   //
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 1

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 4

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 6

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 8

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 9

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 14

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 16

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 18

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 19

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 26

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 27

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 28

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 37

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 41

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 42

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 43

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 46

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 47

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 48

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 50

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 51

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 55

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 56

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 57

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 58

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 59

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 60

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 63

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 64

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 68

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 69

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 70

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 71

                   },
                   new Show_Time()
                   {
                       TimeId = 3,
                       ShowId = 72
                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 5

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 7

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 11

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 15

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 25

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 33

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 34

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 35

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 36

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 40

                   },
                   new Show_Time()
                   {
                       TimeId = 4,
                       ShowId = 49
                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 2

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 3

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 21

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 23

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 24

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 29

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId =31

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 38

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 39

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 44

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 45

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 52

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 53
                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 65

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 66

                   },
                   new Show_Time()
                   {
                       TimeId = 5,
                       ShowId = 67
                   },
                   new Show_Time()
                   {
                       TimeId = 6,
                       ShowId = 12
                   },
                   //Add
                   new Show_Time()
                   {
                       TimeId = 6,
                       ShowId = 76
                   },
                   new Show_Time()
                   {
                       TimeId = 7,
                       ShowId = 10

                   },
                   new Show_Time()
                   {
                       TimeId = 7,
                       ShowId = 37

                   },
                   new Show_Time()
                   {
                       TimeId = 7,
                       ShowId = 43

                   },
                   new Show_Time()
                   {
                       TimeId = 7,
                       ShowId = 60
                   },
                   new Show_Time()
                   {
                       TimeId = 8,
                       ShowId = 28
                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 9

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 13

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 20

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 25

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 26

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 27

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 40

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 41

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 42

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 44

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 46

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 47

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 48

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 50

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 55

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 56

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 57

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 58

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 59

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 61

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 63

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId =64

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 68
                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 69

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 70

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 71

                   },
                   new Show_Time()
                   {
                       TimeId = 9,
                       ShowId = 72
                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 1

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 4

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 6

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 8

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 14

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 24

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 29

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 31

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 33

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 34

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 35

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 36

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 38
                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 39

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 45

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 49

                   },
                   new Show_Time()
                   {
                       TimeId = 10,
                       ShowId = 52
                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId = 5

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId = 7

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId =16

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId = 18

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId = 19

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId = 37

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId =43

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId = 60

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId = 65

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId = 66

                   },
                   new Show_Time()
                   {
                       TimeId = 11,
                       ShowId = 67
                   },
                   new Show_Time()
                   {
                       TimeId = 12,
                       ShowId = 3

                   },
                   new Show_Time()
                   {
                       TimeId = 12,
                       ShowId =11

                   },
                   new Show_Time()
                   {
                       TimeId = 12,
                       ShowId = 15
                   },
                   new Show_Time()
                   {
                       TimeId = 13,
                       ShowId = 2

                   },
                   new Show_Time()
                   {
                       TimeId = 13,
                       ShowId = 21

                   },
                   new Show_Time()
                   {
                       TimeId = 13,
                       ShowId = 28

                   },
                   new Show_Time()
                   {
                       TimeId = 13,
                       ShowId = 30

                   },
                   new Show_Time()
                   {
                       TimeId = 13,
                       ShowId = 44
                   },
                   new Show_Time()
                   {
                       TimeId = 14,
                       ShowId = 12
                   },
                   new Show_Time()
                   {
                       TimeId = 14,
                       ShowId = 50
                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 10
                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 13

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 20

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 23

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 24

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 25

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 26

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 27

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId =29

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 31

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 32

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 33

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 34

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 35

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 36

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 37

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 38

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 39

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 40

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 41

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 42

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 43

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 45

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 46

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 47

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId =48

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 49

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 52

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 55

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 56

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 57
                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 58

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 59

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 60

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 63

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 64

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 65

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 66

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 67

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 68

                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 69
                   },
                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 70
                   },

                   new Show_Time()
                   {
                       TimeId = 15,
                       ShowId = 76
                   },
                   new Show_Time()
                   {
                       TimeId = 16,
                       ShowId = 11
                   },
                   new Show_Time()
                   {
                       TimeId = 17,
                       ShowId = 1

                   },
                   new Show_Time()
                   {
                       TimeId = 17,
                       ShowId = 6

                   },
                   new Show_Time()
                   {
                       TimeId = 17,
                       ShowId = 8

                   },
                   new Show_Time()
                   {
                       TimeId = 17,
                       ShowId = 14

                   },
                   new Show_Time()
                   {
                       TimeId = 17,
                       ShowId = 28

                   },
                   new Show_Time()
                   {
                       TimeId = 17,
                       ShowId = 44

                   },
                   new Show_Time()
                   {
                       TimeId = 17,
                       ShowId = 65

                   },
                   new Show_Time()
                   {
                       TimeId = 17,
                       ShowId =66

                   },
                   new Show_Time()
                   {
                       TimeId = 17,
                       ShowId = 67
                   },
                   new Show_Time()
                   {
                       TimeId = 18,
                       ShowId = 4

                   },
                   new Show_Time()
                   {
                       TimeId = 18,
                       ShowId = 12

                   },
                   new Show_Time()
                   {
                       TimeId = 18,
                       ShowId = 16
                   },
                   new Show_Time()
                   {
                       TimeId = 18,
                       ShowId = 18
                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 3

                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 5

                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 7

                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 9

                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 10

                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 19

                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 37

                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 43

                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 50

                   },
                   new Show_Time()
                   {
                       TimeId = 19,
                       ShowId = 60
                   },
                   new Show_Time()
                   {
                       TimeId = 20,
                       ShowId = 2

                   },
                   new Show_Time()
                   {
                       TimeId = 20,
                       ShowId = 15

                   },
                   new Show_Time()
                   {
                       TimeId = 20,
                       ShowId = 17

                   },
                   new Show_Time()
                   {
                       TimeId = 20,
                       ShowId = 21
                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 11

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 13

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 23

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 24

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 26

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 27

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 29

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 31

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 33

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 34

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 35

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 36

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 38

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 39

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 41

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 42

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 44

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 45

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 47

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 48

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 49

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 52

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 54

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 55

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 56

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 57

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 58

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 59

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 62
                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 63

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 64

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 68

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 69

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 70

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 71

                   },
                   new Show_Time()
                   {
                       TimeId = 21,
                       ShowId = 72
                   },
                   new Show_Time()
                   {
                       TimeId = 22,
                       ShowId = 9
                   },
                   new Show_Time()
                   {
                       TimeId = 22,
                       ShowId = 28
                   },
                   new Show_Time()
                   {
                       TimeId = 23,
                       ShowId = 12

                   },
                   new Show_Time()
                   {
                       TimeId = 23,
                       ShowId = 20

                   },
                   new Show_Time()
                   {
                       TimeId = 23,
                       ShowId = 22

                   },
                   new Show_Time()
                   {
                       TimeId = 23,
                       ShowId = 37

                   },
                   new Show_Time()
                   {
                       TimeId = 23,
                       ShowId = 60

                   },
                   new Show_Time()
                   {
                       TimeId = 23,
                       ShowId = 65

                   },
                   new Show_Time()
                   {
                       TimeId = 23,
                       ShowId = 66

                   },
                   new Show_Time()
                   {
                       TimeId = 23,
                       ShowId = 67
                   },
                   new Show_Time()
                   {
                       TimeId = 24,
                       ShowId = 1

                   },
                   new Show_Time()
                   {
                       TimeId = 24,
                       ShowId = 4

                   },
                   new Show_Time()
                   {
                       TimeId = 24,
                       ShowId = 6

                   },
                   new Show_Time()
                   {
                       TimeId = 24,
                       ShowId = 8

                   },
                   new Show_Time()
                   {
                       TimeId = 24,
                       ShowId = 14
                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 5

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId =10

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 18

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 23

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 24

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 29

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 47

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 50

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 52

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 62
                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId =63

                   },
                   new Show_Time()
                   {
                       TimeId = 25,
                       ShowId = 64
                   },
                   new Show_Time()
                   {
                       TimeId = 26,
                       ShowId = 3

                   },
                   new Show_Time()
                   {
                       TimeId = 26,
                       ShowId =31

                   },
                   new Show_Time()
                   {
                       TimeId = 26,
                       ShowId = 38

                   },
                   new Show_Time()
                   {
                       TimeId = 26,
                       ShowId = 39

                   },
                   new Show_Time()
                   {
                       TimeId = 26,
                       ShowId = 51
                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 7

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 13

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 17

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 19

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 21

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 26

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 27

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 28

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 33

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 34

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 35

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 36

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 37

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 41

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 42

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 54

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 55

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 56

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 57

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 58

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 59

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 60

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 68

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 69

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId =70

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 71

                   },
                   new Show_Time()
                   {
                       TimeId = 27,
                       ShowId = 72
                   },
                   new Show_Time()
                   {
                       TimeId = 28,
                       ShowId = 2

                   },
                   new Show_Time()
                   {
                       TimeId = 28,
                       ShowId = 11

                   },
                   new Show_Time()
                   {
                       TimeId = 28,
                       ShowId = 15

                   },
                   new Show_Time()
                   {
                       TimeId = 28,
                       ShowId = 22
                   },
                   new Show_Time()
                   {
                       TimeId = 29,
                       ShowId = 9

                   },
                   new Show_Time()
                   {
                       TimeId = 29,
                       ShowId = 30

                   },
                   new Show_Time()
                   {
                       TimeId = 29,
                       ShowId = 65

                   },
                   new Show_Time()
                   {
                       TimeId = 29,
                       ShowId = 66

                   },
                   new Show_Time()
                   {
                       TimeId = 29,
                       ShowId = 67
                   },
                   new Show_Time()
                   {
                       TimeId = 30,
                       ShowId = 12
                   },
                   new Show_Time()
                   {
                       TimeId = 30,
                       ShowId = 76
                   },
                };
            modelBuilder.Entity<Show_Time>().HasData(ShowTimes);
            // Tickets
            var Tickets = new List<Ticket>()
                {
                    new Ticket()
                    {
                        Id = 1,
                        ShowId = 2,
                        TicketPrice = 60,
                        SeatNumber = "B5",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(11,00,00),
                    },
                    new Ticket()
                    {
                        Id = 2,
                        ShowId = 2,
                        TicketPrice = 60,
                        SeatNumber = "B6",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(11,00,00),
                    }, new Ticket()
                    {
                        Id = 3,
                        ShowId = 2,
                        TicketPrice = 60,
                        SeatNumber = "B7",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(11,00,00),
                    }, new Ticket()
                    {
                        Id = 4,
                        ShowId = 2,
                        TicketPrice = 60,
                        SeatNumber = "B8",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(11,00,00),
                    }, new Ticket()
                    {
                        Id = 5,
                        ShowId = 2,
                        TicketPrice = 60,
                        SeatNumber = "B9",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(11,00,00),
                    }, new Ticket()
                    {
                        Id = 6,
                        ShowId = 24,
                        TicketPrice = 60,
                        SeatNumber = "C10",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(11,00,00),
                    }, new Ticket()
                    {
                        Id = 7,
                        ShowId = 24,
                        TicketPrice = 60,
                        SeatNumber = "C11",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(11,00,00),
                    }, new Ticket()
                    {
                        Id = 8,
                        ShowId = 24,
                        TicketPrice = 60,
                        SeatNumber = "C12",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(11,00,00),
                    }, 
                    new Ticket()
                    {
                        Id = 9,
                        ShowId = 9,
                        TicketPrice = 100,
                        SeatNumber = "A2",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(18,00,00),
                    }, 
                    new Ticket()
                    {
                        Id = 10,
                        ShowId = 9,
                        TicketPrice = 100,
                        SeatNumber = "A3",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(18,00,00),
                    }, 
                    new Ticket()
                    {
                        Id = 11,
                        ShowId = 9,
                        TicketPrice = 100,
                        SeatNumber = "A4",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(18,00,00),
                    },
                    new Ticket()
                    {
                        Id = 12,
                        ShowId = 9,
                         TicketPrice = 100,
                        SeatNumber = "A5",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(18,00,00),
                    }, 
                    new Ticket()
                    {
                        Id = 13,
                        ShowId = 9,
                        TicketPrice = 100,
                        SeatNumber = "A6",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(18,00,00),
                    },
                    new Ticket()
                    {
                        Id = 14,
                        ShowId = 9,
                        TicketPrice = 100,
                        SeatNumber = "A7",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date.AddDays(-1),
                        ShowTime = new TimeSpan(13,00,00),
                    },
                    new Ticket()
                    {
                        Id = 15,
                        ShowId = 50,
                        TicketPrice = 60,
                        SeatNumber = "D4",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(13,00,00),
                    },
                    new Ticket()
                    {
                        Id = 16,
                        ShowId = 50,
                        TicketPrice = 60,
                        SeatNumber = "D5",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(13,00,00),
                    },
                    new Ticket()
                    {
                        Id = 17,
                        ShowId = 50,
                        TicketPrice = 60,
                        SeatNumber = "D6",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(13,00,00),
                    },
                    new Ticket()
                    {
                        Id = 18,
                        ShowId = 50,
                        TicketPrice = 60,
                        SeatNumber = "E1",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(13,00,00),
                    },
                    new Ticket()
                    {
                        Id = 19,
                        ShowId = 14,
                        TicketPrice = 60,
                        SeatNumber = "D4",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(13,30,00),
                    },
                    new Ticket()
                    {
                        Id = 20,
                        ShowId = 14,
                        TicketPrice = 60,
                        SeatNumber = "D5",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(13,30,00),
                    },
                    new Ticket()
                    {
                        Id = 21,
                        ShowId = 42,
                        TicketPrice = 60,
                        SeatNumber = "F5",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(22,00,00),
                    },
                    new Ticket()
                    {
                        Id = 22,
                        ShowId = 42,
                        TicketPrice = 60,
                        SeatNumber = "F6",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(22,00,00),
                    },
                    new Ticket()
                    {
                        Id = 23,
                        ShowId = 42,
                        TicketPrice = 60,
                        SeatNumber = "F7",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(22,00,00),
                    },
                    new Ticket()
                    {
                        Id = 24,
                        ShowId = 42,
                        TicketPrice = 60,
                        SeatNumber = "F8",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(22,00,00),
                    },
                    new Ticket()
                    {
                        Id = 25,
                        ShowId = 42,
                        TicketPrice = 60,
                        SeatNumber = "F9",
                        UserId= Users[3].Id,
                        ShowDate = DateTime.Today.Date,
                        ShowTime = new TimeSpan(22,00,00),
                    },
                };
            modelBuilder.Entity<Ticket>().HasData(Tickets);
            // Crew 
            var Crews = new List<Crew>()
                {
                    new Crew()
                    {
                        Id = 1,
                        CrewName="Robert Pattinson",
                        CrewBiography="Robert Thomas Pattinson is an English actor, (filmmaker), model and musician. He was born on the 13th of May, 1986 in London, England. Pattinson’s mother, Clare, worked at a modeling agency while his father, Richard, imported vintage cars from the United States.",
                        CrewDateofBirth =new DateTime(1986,5, 13) ,
                        CrewImageURL ="../images/crews/RobertPattinson1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 3,
                    },
                    new Crew()
                    {
                        Id = 2,
                        CrewName="Zoë Kravitz",
                        CrewBiography="Zoë Kravitz is an American actress who was born on December 01, 1988 in Los Angeles, California to actress, Lisa Bonet, and Lenny Kravitz, a folk rock musician and actor. Zoë discovered her passion for acting at a young age and started taking acting classes while still at school. Kravitz participated in two movies during her high school studies, which are: (No Reservations) and (The Brave One) in 2007. She later on participated in (Mad Max: Fury Road) in 2015, (Big Little Lies) in 2017, and (Fantastic Beasts: The Crimes of Grindelwald) in 2018.",
                        CrewDateofBirth =new DateTime(1988,12, 1) ,
                        CrewImageURL ="../images/crews/ZoëKravitz1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 3,
                        CrewName="Colin Farrell",
                        CrewBiography="Colin Farrell is an Irish actor, born in 1976. He attended a school to learn acting but was expelled from it. Afterwards, he started his artistic career by playing several small roles in several TV series. In 2000, he got his first starring role in the movie Land of the Tiger. His most important roles are The Killing of a Sacred Deer movie [2017], The Epic movie [2013], The Winter's Tale movie [2014], and Saving Mr. Banks movie [2013].",
                        CrewDateofBirth =new DateTime(1976,5, 31) ,
                        CrewImageURL ="../images/crews/ColinFarrell1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 8,
                    },
                    new Crew()
                    {
                        Id = 4,
                        CrewName="Matt Reeves",
                        CrewBiography="Matthew George Reeves is an American director, screenwriter and producer born on 27 April 1966 in Rockville Center, New York. His passion for filmmaking began at the early age of 8.  His most notable works include Cloverfield (2008), and Dawn of the Planet of the Apes (2014).  He won a Fright Meter Award for Best Screenplay for Let Me In (2010).",
                        CrewDateofBirth =new DateTime(1966,4, 27) ,
                        CrewImageURL ="../images/crews/MattReeves1.jpg",
                        CrewRoleId = 3,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 5,
                        CrewName="Peter Craig",
                        CrewBiography="Peter Craig is an American novelist and screenwriter, known for his dark comedy and exploitation of father-child relationships. He is best known for writing the action/crime film The Town, and also The Hunger Games: Mockingjay – Parts 1 and 2.",
                        CrewDateofBirth =new DateTime(1969,10, 10) ,
                        CrewImageURL ="../images/crews/PeterCraig1.jpg",
                        CrewRoleId = 2,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 6,
                        CrewName="Tom Holland",
                        CrewBiography="He lives with his parents and his three younger brothers. Holland attended Donhead Prep School. After many years of training and being told he’s talented, he debuted in “Billy Elliot: The Musical” where he played Michael, Billy’s best friend. After the show, he got fantastic reviews on his acting and dancing skills. On the fifth anniversary of “Billy Elliot: The Musical” he and fellow crews who played in the musical were invited to meet the Prime Minister Gordon Brown. When Elton John watched one of his plays, he was amazed by his acting abilities and said that Holland is “astonishing”. On the 29th of May 2015 he finished playing in “Billy Elliot: The Musical” after many years of acting greatly in it.",
                        CrewDateofBirth =new DateTime(1996,6, 1) ,
                        CrewImageURL ="../images/crews/TomHolland1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 3,
                    },
                    new Crew()
                    {
                        Id = 7,
                        CrewName="Mark Wahlberg",
                        CrewBiography="Mark Wahlberg is an American actor, film and television producer, and former rapper. He was born in a poor, working-class neighborhood in Boston on June 5, 1971, one of nine children. He first rose to fame as the strapping and often shirtless Marky Mark, frontman of “Marky Mark and the Funky Bunch. He was named No. 1 on VH1's “40 Hottest Hotties of the 90s.” He has executive produced hit TV shows like HBO's “Entourage” (which is widely understood to be based on his own Hollywood story), “Boardwalk Empire” and “How to Make It in America.” As an actor, Wahlberg gained attention for his impressive performances in “Three Kings” (1999), “The Italian Job” (2003) and “I Heart Huckabees” (2004). His work in “The Departed” (2006) won him Oscar and Golden Globe nominations. He also won a National Society of Film Critics Award for Best Supporting Actor. ",
                        CrewDateofBirth =new DateTime(1971,7, 5) ,
                        CrewImageURL ="../images/crews/MarkWahlberg1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 8,
                        CrewName="Antonio Banderas",
                        CrewBiography="Antonio Banderas is a Spanish actor and director. He was born on 1960 in Malaga.His father worked as a police officer, while his mother was a teacher. During his childhood, Banderas dreamt of becoming a successful football player, but at the age of 14 he broke his leg, and started attending drama and acting classes. In the early 1980s he started acting on stage in small Spanish theaters. By the beginning of the 1990s Banderas moved to Hollywood, where he earned his breakthrough and rose to become one of Hollywood's most successful and highest grossing stars. His most famous films include: Assasins (1995), The Mask of Zorro (1998), The 13th Warrior (1999), Frida (2002), The Legend of Zorro (2005), and The Skin I Live In (2011). Banderas married twice: first he married actress Anna Lisa in 1987, and they filed for divorce in 1996. He then married actress Melanie Griffith. ",
                        CrewDateofBirth =new DateTime(1960,8, 10) ,
                        CrewImageURL ="../images/crews/AntonioBanderas1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 9,
                    },
                    new Crew()
                    {
                        Id = 9,
                        CrewName="Joe Carnahan",
                        CrewBiography="Joseph Aaron Carnahan is an American independent (filmmaker) and actor. He was born on the 9th of May, 1969 in the state of Delaware.Joseph grew up in Detroit Michigan and Fairfield, California. He came to public attention in 1998 when he received critical acclaim for “Blood, Guts, Bullets and Octane”. Thereafter he has worked on several films including “Narc” and, more recently, “The A-Team”.",
                        CrewDateofBirth =new DateTime(1969,5, 9) ,
                        CrewImageURL ="../images/crews/JoeCarnahan1.jpg",
                        CrewRoleId = 2,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 10,
                        CrewName="Ruben Fleischer",
                        CrewBiography="Ruben Fleischer is an American director who was born on October 31, 1974 in Washington, USA. Fleischer graduated from Wesleyan University, where he studied History before moving to San Francisco. Ruben is best known for his action-driven movies, and his work has varied between directing, wring and producing. In 2001, he wrote and the directed the short movie (The Girls Guitar Club).",
                        CrewDateofBirth =new DateTime(1974,10, 31) ,
                        CrewImageURL ="../images/crews/RubenFleischer1.jpg",
                        CrewRoleId = 3,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 11,
                        CrewName="Hesham Maged",
                        CrewBiography="An actor and a script writer, graduated from School of Engineering Cairo University. During university, he created a production company with his friends called “Tamr Hendi” that produced movies that ridiculed famous Egyptian movies. Most famous was “Men who do not know the impossible” This work attracted the attention of Mohamed Hefzy who at the time was attempting production and he produced their first series “Afeesh wa Tashbeeh” which portrayed one of the Egyptian classics in a cynical way in each episode.Hefzy then produced for them the movie “Coded Paper” which was a big hit in the box office.Hesham acted and wrote the script for this movie which familiarized his face to the audience.He won the award of the “Best New Faces” for the year 2008, in participation with his mates Ahmed Sabry and Chico.",
                        CrewDateofBirth =new DateTime(1980,4, 26) ,
                        CrewImageURL ="../images/crews/HeshamMaged1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 1,
                    },
                    new Crew()
                    {
                        Id = 12,
                        CrewName="Dina El Sherbiny",
                        CrewBiography="An Egyptian actress and TV presenter, born in Cairo in 1985. She studied at the Faculty of Mass Communication at October 6 University. After graduating, Dina joined acting workshops, and she also enrolled in enunciation workshops. Dina became famous through the program Windows that she presented on Dream Channel in 2006, and she also presented the program Prime Youth in 2011. Dina started acting when she entered a competition to choose new crews in order to participate in the series Special Screening, in which she appeared as herself. After that, she participated in the series Girls' Tales, Third Party and Underground. Dina made her film debut in The Party (2013).",
                        CrewDateofBirth =new DateTime(1985,3, 17) ,
                        CrewImageURL ="../images/crews/DinaElSherbiny1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 1,
                    },
                    new Crew()
                    {
                        Id = 13,
                        CrewName="Mohamed Sallam",
                        CrewBiography="Mohamed Sallam is an Egyptian actor. He graduated from the faculty of commerce in Cairo, where he started acting on stage. His film debut was in the 2006 film 'El Rahina' (The Hostage). He then starred in the hit play 'Ahwa Sada' (Black Coffee) in 2009. He then went on to appear in numerous television series, including 'El Kebir Awy', and films including 'Captain Egypt'.",
                        CrewDateofBirth =new DateTime(1983,12, 15) ,
                        CrewImageURL ="../images/crews/MohamedSallam1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 1,
                    },
                    new Crew()
                    {
                        Id = 14,
                        CrewName="Ihab Blaibel",
                        CrewBiography="Egyptian writer who has written several works including the film Ocean 14 (2015), starring the stars of Teatro Misr.",
                        CrewImageURL ="../images/crews/IhabBlaibel1.jpg",
                        CrewRoleId = 2,
                        NationalityId =1,
                    },
                    new Crew()
                    {
                        Id = 15,
                        CrewName="Hesham Fathy",
                        CrewBiography="Egyptian director who directed programs ad series such as The Franks (2015) starring Hisham Maged, Chico, and Ahmed Fahmy ad the series Ending with Style and Repel Response. He also does works in editing and sound mixing.",
                        CrewImageURL ="../images/crews/HeshamFathy1.jpg",
                        CrewRoleId = 3,
                        NationalityId = 1,
                    },
                    new Crew()
                    {
                        Id = 16,
                        CrewName="Gillian Jacobs",
                        CrewBiography="She is an American actress, born on October 19, 1982 in Pittsburgh, Pennsylvania. She started acting on the local theaters of Pittsburgh, especially in Shakespearean plays, like A Midsummer Night's Dream.  She graduated from the Juilliard School in 2004, where she studied acting.  She's known for Walk of Shame (2014), The Box (2009) and the comedy series Community (2009-2015).",
                        CrewDateofBirth =new DateTime(1982,10, 20) ,
                        CrewImageURL ="../images/crews/GillianJacobs1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 17,
                        CrewName="Chris Pine",
                        CrewBiography="An ​​American actor born on August 26, 1980 in Los Angeles, California. He holds a degree in English from the University of California, Berkeley, then studied acting at the University of Leeds in England. He made his film debut in The Princess Diaries 2: Royal Engagement (2004), after which he starred in many films, most notably Unstoppable (2010),  Wonder Woman (2017), and Star Trek reboot film series (2009–2016).",
                        CrewDateofBirth =new DateTime(1980,8,26) ,
                        CrewImageURL ="../images/crews/ChrisPine1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 18,
                        CrewName="Kiefer Sutherland",
                        CrewBiography="He is an American actor, born on December 21, 1966 in London, England. He got his first role in Max Dugan Returns (1983). He is best known for his role in the Canadian film, The Bay Boy (1984), which won him a Genie Award as best actor. He starred in Amazing Stories (1985) and Trapped in Silence (1986). ",
                        CrewDateofBirth =new DateTime(1966,12, 21) ,
                        CrewImageURL ="../images/crews/KieferSutherland1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 19,
                        CrewName="Tarik Saleh",
                        CrewBiography="Egyptian director and writer born on January 28, 1972. He wrote and directed the movie The Nile Hilton Incident (2017).",
                        CrewDateofBirth =new DateTime(1972,1, 28) ,
                        CrewImageURL ="../images/crews/TarikSaleh1.jpg",
                        CrewRoleId = 3,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 20,
                        CrewName="J.P. Davis",
                        CrewBiography="J.P. Davis is an actor and writer, known for The Plane, Fighting Tommy Riley (2004) and The Contractor (2022).",
                        CrewImageURL ="../images/crews/Davis1.jpg",
                        CrewRoleId = 2,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 21,
                        CrewName="Ahmad Ezz",
                        CrewBiography="Ahmed Ezz was born on July 3, 1971. He began a career in modeling after graduating from the Faculty of Arts from the English division. Ezz began working as a model in the hopes that it would later give him access to acting jobs. However the venture was not successful. After some time, Ezz met director Enas Al Daghdaghy who gave him a minor role in the film “Kallam Al Layl” (Night Talk) in 1999. The director would later give him the lead role in “Muzikirat Murahiqa” (Memoirs of a Teenager) in 2001. ",
                        CrewDateofBirth =new DateTime(1971,7, 23) ,
                        CrewImageURL ="../images/crews/AhmadEzz1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 1,
                    },
                    new Crew()
                    {
                        Id = 22,
                        CrewName="Menna Shalaby",
                        CrewBiography="Menna Shalaby is one of the brightest stars in the younger generation of Egyptian actors. She was born on July 24, 1981 in Cairo. She is the daughter of the famous dancer and performer Zizi Mustafa. Shalaby displayed a passion for performing from a very early age, no doubt due to the exposure to the industry her mother's fame provided. She would often sit in front of the mirror and pretend to be her famous mother, and also fake being sick to get out of going to school, which her mother declared was also acting. Menna made her film debut in 'Al Saher' (The Magician) as Nour in 2001. She next scored a leading role beside Layla Elwy in 'Baheb El Seema' (2004). ",
                        CrewDateofBirth =new DateTime(1982,6, 24) ,
                        CrewImageURL ="../images/crews/MennaShalaby1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 1,
                    },
                    new Crew()
                    {
                        Id = 23,
                        CrewName="Maged El Kedwany",
                        CrewBiography="Maged El Kedwany is an Egyptian film and television actor. In 1967, he was born in Shubra in Cairo, but lived in Kuwait up until age 18. He began his professional career while studying design at the Faculty of Fine Arts. He began acting in a number of amateur plays, which led to him being cast in various TV shows like 'Qanfad' (Hedgehog) and 'Nahnu al Nazre el-Shook.' He's worked on dozens of films, among them are some of the most well-known films of the 1990s, like 'Afareet el-Asphalt' (Asphalt Ghosts) in 1996 and 'Saidi fe Gaea al-Amrikeya' (Saidi at the American University in Cairo) in 1998. His other films include 'Harameya Ki-Gi-To' (Ki-Gi-To Thieves), 'Harameya fe Thailand' (Thieves in Thailand), 'Al-Ragel al-Abyad al-Motawast' (Average White Guy), and 'Khaly min Kolesterol' (Cholesterol-Free). In 2012, he appeared in two high-profile movies, 'Hafla Montasif al-Leil' (Midnight Party) and 'Saaa we Nos' (Hour and a Half).",
                        CrewDateofBirth =new DateTime(1976,12, 10) ,
                        CrewImageURL ="../images/crews/MagedElKedwany1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 1,
                    },
                    new Crew()
                    {
                        Id = 24,
                        CrewName="Sherif Arafa",
                        CrewBiography="Sherif is an Egyptian director, screenwriter and producer. He graduated from the Higher Institute for Cinema in 1982 and he is the son of director Sa’ad ‘Arafa in addition to being an elder brother to director ‘Amr ‘Arafa. Sherif began his cinema career in 1987 when he directed the film The Dwarfs are Coming. He then directed the film The Second Degree starring Soa’ad Hosny and Ahmed Zakky. He was the first to notice the talents of many stars including: Mohamed Sa’ad, Ahmed Helmy, Mohamed Heneidy, Kareem ‘Abd Al ‘Azeez, Ahmed Makky. The director has worked with major stars from the outset of his career, like of Soa’ad Hosny, Ahmed Zakky and Adel Imam.  Sherif has also produced several films and television productions such as the film “Halim” and the TV series Tamer and Shawqqiyah, Critical Moments, and the program The People and Myself through his private production company Partner Pro. Moreover Sherif has also directed several TV commercials for well known products such as Pepsi and Chipsy.  Sherif Arafa has directed several films that were milestones in the history of Egyptian cinema, like The Birds of Darkness, The Principal and Mafia.",
                        CrewDateofBirth =new DateTime(1960,12, 25) ,
                        CrewImageURL ="../images/crews/SherifArafa1.jpg",
                        CrewRoleId = 2,
                        NationalityId = 1,
                    },
                    new Crew()
                    {
                        Id = 25,
                        CrewName="Sherif Arafa",
                        CrewBiography="Sherif is an Egyptian director, screenwriter and producer. He graduated from the Higher Institute for Cinema in 1982 and he is the son of director Sa’ad ‘Arafa in addition to being an elder brother to director ‘Amr ‘Arafa. Sherif began his cinema career in 1987 when he directed the film The Dwarfs are Coming. He then directed the film The Second Degree starring Soa’ad Hosny and Ahmed Zakky. He was the first to notice the talents of many stars including: Mohamed Sa’ad, Ahmed Helmy, Mohamed Heneidy, Kareem ‘Abd Al ‘Azeez, Ahmed Makky. The director has worked with major stars from the outset of his career, like of Soa’ad Hosny, Ahmed Zakky and Adel Imam.  Sherif has also produced several films and television productions such as the film “Halim” and the TV series Tamer and Shawqqiyah, Critical Moments, and the program The People and Myself through his private production company Partner Pro. Moreover Sherif has also directed several TV commercials for well known products such as Pepsi and Chipsy.  Sherif Arafa has directed several films that were milestones in the history of Egyptian cinema, like The Birds of Darkness, The Principal and Mafia.",
                        CrewDateofBirth = new DateTime(1960,12, 25) ,
                        CrewImageURL ="../images/crews/SherifArafa1.jpg",
                        CrewRoleId = 3,
                        NationalityId =1,
                    },
                    new Crew()
                    {
                        Id = 26,
                        CrewName="Tom Bateman",
                        CrewBiography="Tom Bateman is an English actor, born in Oxford in a working-class family. He has a twin brother named Merlin. He studied drama at the London Academy of Music and Dramatic Art. He began his acting career in theatre joining Kenneth Branagh's company in The Winter's Tale. His starred in various TV series including: Da Vinci's Demons, Jekyll and Hyde and Beecham House.  His film roles include: Murder on the Orient Express (2017) and Cold Pursuit (2019). ",
                        CrewDateofBirth =new DateTime(1989,3, 15) ,
                        CrewImageURL ="../images/crews/TomBateman1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 3,
                    },
                    new Crew()
                    {
                        Id = 27,
                        CrewName="Armie Hammer",
                        CrewBiography="Armie Hammer was  born in Santa Monica, California. His mother is a former bank loan officer, his father owns several businesses, and his great-grandfather was oil tycoon and philanthropist Armand Hammer. He lived with his family for five years in the Cayman Islands when he was seven, and then settled back in Los Angeles to pursue acting. He began his acting career with small parts in TV series including: Veronica Mars and Gossip Girl. His first leading role was in Billy: The Early Years in 2008.  His breakthrough film role was in David Fincher's The Social Network in 2010.",
                        CrewDateofBirth =new DateTime(1986,8, 28) ,
                        CrewImageURL ="../images/crews/ArmieHammer1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 28,
                        CrewName="Agatha Christie",
                        CrewBiography="One of the most famous English writers of all time. She was born on September 15, 1890 in Torquay, England. She specialized in writing detective novels. She published her first novel in 1920, which was titled The Mysterious Affair at Styles. Many of her novels have been adapted into serials and films in many countries. She created many characters that she used in most of her works. Among her works are: And Then There Were None, Murder on the Orient Express and A Night of Terror. She died on January 12, 1976 in Oxfordshire.",
                        CrewDateofBirth =new DateTime(1890,9, 15) ,
                        CrewImageURL ="../images/crews/AgathaChristie1.jpg",
                        CrewRoleId = 2,
                        NationalityId = 3,
                    },
                    new Crew()
                    {
                        Id = 29,
                        CrewName="Kenneth Branagh",
                        CrewBiography="He is an actor, writer, director, and producer from Northern Ireland, born on December 10, 1960. He started his acting career in Chariots of Fire (1981). He's known for directing and starring in several film adaptations of William Shakespeare's plays, including Henry V, Much Ado About Nothing, and Hamlet. He was nominated for an Academy Award 5 times.",
                        CrewDateofBirth =new DateTime(1960,10, 10) ,
                        CrewImageURL ="../images/crews/KennethBranagh1.jpg",
                        CrewRoleId = 3,
                        NationalityId = 3,
                    },
                    new Crew()
                    {
                        Id = 30,
                        CrewName="Eiza González",
                        CrewBiography="The Mexican actress and singer was born on January 30th, 1990 in New Mexico. After the success of her show, True Love, in 2012, she decided to take her acting career to Hollywood, even if it means starting from scratch. Despite the rough start, her dreams started coming true in the US as she released several albums. She is best known for From Dusk Till Dawn: The Series (2014), Jem and the Holograms (2015), and Baby Driver (2017).",
                        CrewDateofBirth =new DateTime(1990,1, 30) ,
                        CrewImageURL ="../images/crews/EizaGonzález1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 10,
                    },
                    new Crew()
                    {
                        Id = 31,
                        CrewName="Yahya Abdul-Mateen",
                        CrewBiography="An American actor, born in New Orleans, Louisiana. He is best known for his work in the series The Get Down (2016), and the movies Sidney Hall (2017), Baywatch (2017), and Aquaman (2018).",
                        CrewDateofBirth =new DateTime(1986,7, 15) ,
                        CrewImageURL ="../images/crews/YahyaAbdulMateen1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 32,
                        CrewName="Michael Bay",
                        CrewBiography="Michael Benjamin Bay is an American film director and producer. He got his start in the film industry as an intern on the location of George Lucas' 'Raiders of the Lost Ark,' where he used to file storyboards. Upon watching the film in the theater, he was so impressed by the experience that he decided to become a film director. After directing a series of highly successful music videos, Bay was picked by producer Jerry Bruckheimer to direct 'Bad Boys' (1994), which was his first feature film. .",
                        CrewDateofBirth =new DateTime(1965,2, 17) ,
                        CrewImageURL ="../images/crews/MichaelBay1.jpg",
                        CrewRoleId = 3,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 33,
                        CrewName="Chris Fedak",
                        CrewBiography="Chris Fedak was born on August 20, 1975. He served as producer and writer on the series Chuck (2007-2012), Forever (2014-2015), and DC's Legends of Tomorrow (2016).",
                        CrewDateofBirth =new DateTime(1975,8, 20) ,
                        CrewImageURL ="../images/crews/ChrisFedak1.jpg",
                        CrewRoleId = 2,
                        NationalityId = 2,
                    },
                    new Crew()
                    {
                        Id = 34,
                        CrewName="Jake Gyllenhaal",
                        CrewBiography="Jake Gyllenhall’s father is the director Steven Gyllenhall. His mother, (Funir) is a producer and (screenwriter). His sister is the actress Maggie Gyllenhall. Jake Gyllenhall’s first acting experience occurred at the age of eleven where he acted in the 1991 film (“City Slickers”). Thereafter, Jake would assume roles in several (television and cinematic productions).However his work (in theater) has given him more experience and (exposure) especially since he has performed on Broadway.",
                        CrewDateofBirth =new DateTime(1980,12, 20) ,
                        CrewImageURL ="../images/crews/JakeGyllenhaal1.jpg",
                        CrewRoleId = 1,
                        NationalityId = 2,
                    },
                };
            modelBuilder.Entity<Crew>().HasData(Crews);
            // Crew - Gallary
            var CrewsGallary = new List<Crew_Gallery>()
                {
                    new Crew_Gallery()
                    {
                        Id = 1,
                        CrewId= 1,
                        ImageURL = "../images/crews/RobertPattinson1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 2,
                        CrewId= 1,
                        ImageURL = "../images/crews/RobertPattinson2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 3,
                        CrewId= 1,
                        ImageURL = "../images/crews/RobertPattinson3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 4,
                        CrewId= 1,
                        ImageURL = "../images/crews/RobertPattinson4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 5,
                        CrewId= 1,
                        ImageURL = "../images/crews/RobertPattinson5.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 6,
                        CrewId= 1,
                        ImageURL = "../images/crews/RobertPattinson6.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 7,
                        CrewId= 2,
                        ImageURL = "../images/crews/ZoëKravitz1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 8,
                        CrewId= 2,
                        ImageURL = "../images/crews/ZoëKravitz2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 9,
                        CrewId= 2,
                        ImageURL = "../images/crews/ZoëKravitz3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 10,
                        CrewId= 2,
                        ImageURL = "../images/crews/ZoëKravitz4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 11,
                        CrewId= 3,
                        ImageURL = "../images/crews/ColinFarrell.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 12,
                        CrewId= 3,
                        ImageURL = "../images/crews/ColinFarrel2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 13,
                        CrewId= 3,
                        ImageURL = "../images/crews/ColinFarrel3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 14,
                        CrewId= 3,
                        ImageURL = "../images/crews/ColinFarrel4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 15,
                        CrewId= 3,
                        ImageURL = "../images/crews/ColinFarrel5.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 16,
                        CrewId= 3,
                        ImageURL = "../images/crews/ColinFarrel6.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 17,
                        CrewId= 4,
                        ImageURL = "../images/crews/MattReeves1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 18,
                        CrewId= 4,
                        ImageURL = "../images/crews/MattReeves2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 19,
                        CrewId= 4,
                        ImageURL = "../images/crews/MattReeves3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 20,
                        CrewId= 4,
                        ImageURL = "../images/crews/MattReeves4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 21,
                        CrewId= 5,
                        ImageURL = "../images/crews/PeterCraig1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 22,
                        CrewId= 6,
                        ImageURL = "../images/crews/TomHolland1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 23,
                        CrewId= 6,
                        ImageURL = "../images/crews/TomHolland2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 24,
                        CrewId= 6,
                        ImageURL = "../images/crews/TomHolland3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 25,
                        CrewId= 7,
                        ImageURL = "../images/crews/MarkWahlberg1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 26,
                        CrewId= 7,
                        ImageURL = "../images/crews/MarkWahlberg2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 27,
                        CrewId= 7,
                        ImageURL = "../images/crews/MarkWahlberg3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 28,
                        CrewId= 7,
                        ImageURL = "../images/crews/MarkWahlberg4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 29,
                        CrewId= 7,
                        ImageURL = "../images/crews/MarkWahlberg5.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 30,
                        CrewId= 7,
                        ImageURL = "../images/crews/MarkWahlberg6.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 31,
                        CrewId= 7,
                        ImageURL = "../images/crews/MarkWahlberg7.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 32,
                        CrewId= 8,
                        ImageURL = "../images/crews/AntonioBanderas1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 33,
                        CrewId= 8,
                        ImageURL = "../images/crews/AntonioBanderas2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 34,
                        CrewId= 8,
                        ImageURL = "../images/crews/AntonioBanderas3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 35,
                        CrewId= 8,
                        ImageURL = "../images/crews/AntonioBanderas4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 36,
                        CrewId= 8,
                        ImageURL = "../images/crews/AntonioBanderas5.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 37,
                        CrewId= 8,
                        ImageURL = "../images/crews/AntonioBanderas6.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 38,
                        CrewId= 8,
                        ImageURL = "../images/crews/AntonioBanderas7.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 39,
                        CrewId= 8,
                        ImageURL = "../images/crews/AntonioBanderas8.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 40,
                        CrewId= 9,
                        ImageURL = "../images/crews/JoeCarnahan1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 41,
                        CrewId= 9,
                        ImageURL = "../images/crews/JoeCarnahan2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 42,
                        CrewId= 9,
                        ImageURL = "../images/crews/JoeCarnahan3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 43,
                        CrewId= 10,
                        ImageURL = "../images/crews/RubenFleischer1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 44,
                        CrewId= 10,
                        ImageURL = "../images/crews/RubenFleischer2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 45,
                        CrewId= 10,
                        ImageURL = "../images/crews/RubenFleischer3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 46,
                        CrewId= 10,
                        ImageURL = "../images/crews/RubenFleischer4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 47,
                        CrewId= 10,
                        ImageURL = "../images/crews/RubenFleischer5.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 48,
                        CrewId= 11,
                        ImageURL = "../images/crews/HeshamMaged1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 49,
                        CrewId= 11,
                        ImageURL = "../images/crews/HeshamMaged2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 50,
                        CrewId= 11,
                        ImageURL = "../images/crews/HeshamMaged3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 51,
                        CrewId= 11,
                        ImageURL = "../images/crews/HeshamMaged4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 52,
                        CrewId= 11,
                        ImageURL = "../images/crews/HeshamMaged5.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 53,
                        CrewId= 12,
                        ImageURL = "../images/crews/DinaElSherbiny1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 54,
                        CrewId= 12,
                        ImageURL = "../images/crews/DinaElSherbiny2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 55,
                        CrewId= 12,
                        ImageURL = "../images/crews/DinaElSherbiny3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 56,
                        CrewId= 12,
                        ImageURL = "../images/crews/DinaElSherbiny4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 57,
                        CrewId= 12,
                        ImageURL = "../images/crews/DinaElSherbiny5.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 58,
                        CrewId= 12,
                        ImageURL = "../images/crews/DinaElSherbiny6.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 59,
                        CrewId= 13,
                        ImageURL = "../images/crews/MohamedSallam1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 60,
                        CrewId= 13,
                        ImageURL = "../images/crews/MohamedSallam2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 61,
                        CrewId= 13,
                        ImageURL = "../images/crews/MohamedSallam3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 62,
                        CrewId= 13,
                        ImageURL = "../images/crews/MohamedSallam4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 63,
                        CrewId= 14,
                        ImageURL = "../images/crews/IhabBlaibel1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 64,
                        CrewId= 15,
                        ImageURL = "../images/crews/HeshamFathy1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 65,
                        CrewId= 15,
                        ImageURL = "../images/crews/HeshamFathy2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 66,
                        CrewId= 16,
                        ImageURL = "../images/crews/GillianJacobs1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 67,
                        CrewId= 16,
                        ImageURL = "../images/crews/GillianJacobs2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 68,
                        CrewId= 16,
                        ImageURL = "../images/crews/GillianJacobs3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 69,
                        CrewId= 16,
                        ImageURL = "../images/crews/GillianJacobs4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 70,
                        CrewId= 17,
                        ImageURL = "../images/crews/ChrisPine1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 71,
                        CrewId= 17,
                        ImageURL = "../images/crews/ChrisPine2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 72,
                        CrewId= 17,
                        ImageURL = "../images/crews/ChrisPine3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 73,
                        CrewId= 17,
                        ImageURL = "../images/crews/ChrisPine4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 74,
                        CrewId= 17,
                        ImageURL = "../images/crews/ChrisPine4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 75,
                        CrewId= 18,
                        ImageURL = "../images/crews/KieferSutherland1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 76,
                        CrewId= 18,
                        ImageURL = "../images/crews/KieferSutherland2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 77,
                        CrewId= 18,
                        ImageURL = "../images/crews/KieferSutherland3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 78,
                        CrewId= 18,
                        ImageURL = "../images/crews/KieferSutherland4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 79,
                        CrewId= 19,
                        ImageURL = "../images/crews/TarikSaleh1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 80,
                        CrewId= 20,
                        ImageURL = "../images/crews/Davis1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 81,
                        CrewId= 20,
                        ImageURL = "../images/crews/Davis2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 82,
                        CrewId= 20,
                        ImageURL = "../images/crews/Davis3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 83,
                        CrewId= 21,
                        ImageURL = "../images/crews/AhmadEzz1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 84,
                        CrewId= 21,
                        ImageURL = "../images/crews/AhmadEzz2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 85,
                        CrewId= 21,
                        ImageURL = "../images/crews/AhmadEzz3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 86,
                        CrewId= 21,
                        ImageURL = "../images/crews/AhmadEzz4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 87,
                        CrewId= 22,
                        ImageURL = "../images/crews/MennaShalaby1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 88,
                        CrewId= 22,
                        ImageURL = "../images/crews/MennaShalaby2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 89,
                        CrewId= 22,
                        ImageURL = "../images/crews/MennaShalaby3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 90,
                        CrewId= 22,
                        ImageURL = "../images/crews/MennaShalaby4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 91,
                        CrewId= 23,
                        ImageURL = "../images/crews/MagedElKedwany1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 92,
                        CrewId= 23,
                        ImageURL = "../images/crews/MagedElKedwany2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 93,
                        CrewId= 23,
                        ImageURL = "../images/crews/MagedElKedwany3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 94,
                        CrewId= 24,
                        ImageURL = "../images/crews/SherifArafa1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 95,
                        CrewId= 24,
                        ImageURL = "../images/crews/SherifArafa2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 96,
                        CrewId= 25,
                        ImageURL = "../images/crews/SherifArafa1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 97,
                        CrewId= 25,
                        ImageURL = "../images/crews/SherifArafa2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 98,
                        CrewId= 26,
                        ImageURL = "../images/crews/TomBateman1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 99,
                        CrewId= 26,
                        ImageURL = "../images/crews/TomBateman2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 100,
                        CrewId= 26,
                        ImageURL = "../images/crews/TomBateman3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 101,
                        CrewId= 27,
                        ImageURL = "../images/crews/ArmieHammer1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 102,
                        CrewId= 27,
                        ImageURL = "../images/crews/ArmieHammer2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 103,
                        CrewId= 27,
                        ImageURL = "../images/crews/ArmieHammer3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 104,
                        CrewId= 27,
                        ImageURL = "../images/crews/ArmieHammer4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 105,
                        CrewId= 28,
                        ImageURL = "../images/crews/AgathaChristie1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 106,
                        CrewId= 29,
                        ImageURL = "../images/crews/KennethBranagh1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 107,
                        CrewId= 29,
                        ImageURL = "../images/crews/KennethBranagh2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 108,
                        CrewId= 29,
                        ImageURL = "../images/crews/KennethBranagh3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 109,
                        CrewId= 29,
                        ImageURL = "../images/crews/KennethBranagh4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 110,
                        CrewId= 30,
                        ImageURL = "../images/crews/EizaGonzález1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 111,
                        CrewId= 30,
                        ImageURL = "../images/crews/EizaGonzález2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 112,
                        CrewId= 30,
                        ImageURL = "../images/crews/EizaGonzález3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 113,
                        CrewId= 30,
                        ImageURL = "../images/crews/EizaGonzález4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 114,
                        CrewId= 31,
                        ImageURL = "../images/crews/YahyaAbdulMateen1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 115,
                        CrewId= 31,
                        ImageURL = "../images/crews/YahyaAbdulMateen2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 116,
                        CrewId= 32,
                        ImageURL = "../images/crews/MichaelBay1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 117,
                        CrewId= 32,
                        ImageURL = "../images/crews/MichaelBay2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 118,
                        CrewId= 32,
                        ImageURL = "../images/crews/MichaelBay3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 119,
                        CrewId= 32,
                        ImageURL = "../images/crews/MichaelBay4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 120,
                        CrewId= 33,
                        ImageURL = "../images/crews/ChrisFedak1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 121,
                        CrewId= 33,
                        ImageURL = "../images/crews/ChrisFedak2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 122,
                        CrewId= 33,
                        ImageURL = "../images/crews/ChrisFedak3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 123,
                        CrewId= 33,
                        ImageURL = "../images/crews/ChrisFedak4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 124,
                        CrewId= 34,
                        ImageURL = "../images/crews/JakeGyllenhaal1.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 125,
                        CrewId= 34,
                        ImageURL = "../images/crews/JakeGyllenhaal2.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 126,
                        CrewId= 34,
                        ImageURL = "../images/crews/JakeGyllenhaal3.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 127,
                        CrewId= 34,
                        ImageURL = "../images/crews/JakeGyllenhaal4.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 128,
                        CrewId= 34,
                        ImageURL = "../images/crews/JakeGyllenhaal5.jpg"
                    },
                    new Crew_Gallery()
                    {
                        Id = 129,
                        CrewId= 34,
                        ImageURL = "../images/crews/JakeGyllenhaal6.jpg"
                    },
                };
            modelBuilder.Entity<Crew_Gallery>().HasData(CrewsGallary);
            // Crew - Movie
            var CrewsMovie = new List<Crew_Movie>()
                {
                    new Crew_Movie()
                    {
                        CrewId = 1,
                        MovieId = 1,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 2,
                        MovieId = 1,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 3,
                        MovieId = 1,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 4,
                        MovieId = 1,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 5,
                        MovieId = 1,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 6,
                        MovieId = 2,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 7,
                        MovieId = 2,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 8,
                        MovieId = 2,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 9,
                        MovieId = 2,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 10,
                        MovieId = 2,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 11,
                        MovieId = 3,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 12,
                        MovieId = 3,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 13,
                        MovieId = 3,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 14,
                        MovieId = 3,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 15,
                        MovieId = 3,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 16,
                        MovieId = 4,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 17,
                        MovieId = 4,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 18,
                        MovieId = 4,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 19,
                        MovieId = 4,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 20,
                        MovieId = 4,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 21,
                        MovieId = 8,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 22,
                        MovieId = 8,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 23,
                        MovieId = 8,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 24,
                        MovieId = 8,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 25,
                        MovieId = 8,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 25,
                        MovieId = 6,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 26,
                        MovieId = 6,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 27,
                        MovieId = 6,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 28,
                        MovieId = 6,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 29,
                        MovieId = 6,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 30,
                        MovieId = 16,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 31,
                        MovieId = 16,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 32,
                        MovieId = 16,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 33,
                        MovieId = 16,
                    },
                    new Crew_Movie()
                    {
                        CrewId = 34,
                        MovieId = 16,
                    },
                };
            modelBuilder.Entity<Crew_Movie>().HasData(CrewsMovie);
        }
    }
}
