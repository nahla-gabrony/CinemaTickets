using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.Movies;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class MovieService : EntityRepository<Movie> , IMovieService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieService(CinemaTicketsContext context,
                                IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public override IQueryable<Movie> Search(IQueryable<Movie> movies, string search)
        {
            return movies.Include(x=>x.Show).Where(m => m.MovieName.Contains(search) ||
                                                       m.Genres_Movies.Any(G => G.Genre.GenreName.Contains(search)) ||
                                                       m.Language.LanguageName.Contains(search) ||
                                                       m.Country.CountryName.Contains(search) ||
                                                       m.Crew_Movies.Any(c=>c.Crew.CrewName.Contains(search)));
        }
        public async Task<MovieEditViewModel> GetDetailsByIdAdmin(int id)
        {
            var model = await _context.Movies.Where(movie => movie.Id == id)
                                         .Select(movie => new MovieEditViewModel
                                         {
                                             MovieId = movie.Id,
                                             MovieName = movie.MovieName,
                                             MovieDescription = movie.MovieDescription,
                                             MovieRate = movie.MovieRate,
                                             MovieReleaseDate = movie.MovieReleaseDate,
                                             MovieRunningTime = movie.MovieRunningTime,
                                             ExistPhoto = movie.MovieImageURL,
                                             CountryId = movie.CountryId,
                                             LanguageId = movie.LanguageId,
                                             GenresId = (movie.Genres_Movies.Where(x => x.MovieId == id && x.GenreId == x.Genre.Id).Select(x => x.Genre.Id)).ToList(),
                                             ActorsId = (movie.Crew_Movies.Where(x => x.MovieId == id && x.CrewId == x.Crew.Id && x.Crew.CrewRoleId == 1).Select(x => x.Crew.Id)).ToList(),
                                             WritersId = (movie.Crew_Movies.Where(x => x.MovieId == id && x.CrewId == x.Crew.Id && x.Crew.CrewRoleId == 2).Select(x => x.Crew.Id)).ToList(),
                                             DirectorsId = (movie.Crew_Movies.Where(x => x.MovieId == id && x.CrewId == x.Crew.Id && x.Crew.CrewRoleId == 3).Select(x => x.Crew.Id)).ToList(),
                                         }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }
        public async Task<MovieEditViewModel> GetDetailsById(int id)
        {
            var model = await _context.Movies.Where(movie => movie.Id == id)
                                         .Select(movie => new MovieEditViewModel
                                         {
                                             MovieId = movie.Id, 
                                             MovieName = movie.MovieName,
                                             MovieDescription = movie.MovieDescription,
                                             MovieRate = movie.MovieRate,
                                             MovieReleaseDate = movie.MovieReleaseDate,
                                             MovieRunningTime = movie.MovieRunningTime,
                                             ExistPhoto = movie.MovieImageURL,
                                             Shows = movie.Show.Where(x => x.MovieId == id).ToList(),
                                             CountryName = movie.Country.CountryName,
                                             LanguageName = movie.Language.LanguageName,
                                             GenresName = string.Join(",", movie.Genres_Movies.Where(x => x.MovieId == id && x.GenreId == x.Genre.Id).Select(x => x.Genre.GenreName)),
                                             ExistMovieGallery = movie.MovieGallary.Select(g => new Movie_Gallery()
                                             {
                                                 Id = g.Id,
                                                 ImageURL = g.ImageURL
                                             }).ToList(),
                                             ExistCrew = movie.Crew_Movies.Select(x => new Crew_Movie()
                                             {
                                                 Crew = new Crew()
                                                 {
                                                     Id = x.CrewId,
                                                     CrewName = x.Crew.CrewName,
                                                     CrewImageURL = x.Crew.CrewImageURL,
                                                     CrewRoleId = x.Crew.CrewRoleId
                                                 },
                                             }).ToList(),
                                         }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }
        public async Task Update(MovieEditViewModel model, string folderPath)
        {
            Movie editItem = await _context.Movies.Include(G => G.Genres_Movies)
                                                  .Include(CM => CM.Crew_Movies)
                                                  .Include(MG => MG.MovieGallary)
                                                  .FirstOrDefaultAsync(m => m.Id == model.MovieId);
            editItem.MovieName = model.MovieName;
            editItem.MovieDescription = model.MovieDescription;
            editItem.MovieRate = model.MovieRate;
            editItem.MovieRunningTime = model.MovieRunningTime;
            editItem.MovieReleaseDate = model.MovieReleaseDate;
            editItem.LanguageId = model.LanguageId;
            editItem.CountryId = model.CountryId;

            await AddCoverPhoto(model, editItem, folderPath, model.ExistPhoto);
            await AddGallaryPhotos(model, editItem, folderPath);
            AddGenresMovies(model, editItem);
            AddCrewMovies(model, editItem);

            _context.Movies.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task Create(MovieCreateViewModel model, string folderPath)
        {
            Movie createItem = new()
            {
                Id = model.MovieId,
                MovieName = model.MovieName,
                MovieDescription = model.MovieDescription,
                MovieRate = model.MovieRate,
                MovieReleaseDate = model.MovieReleaseDate,
                MovieRunningTime = model.MovieRunningTime,
                CountryId = model.CountryId,
                LanguageId = model.LanguageId,
            };


            await AddCoverPhoto(model, createItem, folderPath);
            await AddGallaryPhotos(model, createItem, folderPath);
            AddGenresMovies(model, createItem);
            AddCrewMovies(model, createItem);

            await _context.Movies.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }
  
        public async Task<IEnumerable<Movie>> CrewFilmography(int crewId)
        {
            return await _context.Crew_Movies.Include(x=>x.Movie.Show).Where(c => c.CrewId == crewId).Select(c => c.Movie).ToListAsync();

        }
        public async Task<IEnumerable<Movie>> GetMovies(string status)
        {
            if(status != null)
            {
                if(status == "all")
                {
                    return await _context.Movies.Include(x => x.Show).Where(x => x.Show.Any(x => x.ShowEndDate > DateTime.Today)).ToListAsync();
                }
                 else if (status == "now")
                {
                    return await _context.Movies.Include(x=>x.Show).Where(x=>x.Show.Any(x=>x.ShowStartDate < DateTime.Today && x.ShowEndDate > DateTime.Today)).ToListAsync();
                }
                else if (status == "soon")
                {
                    return await _context.Movies.Include(x => x.Show).Where(x => x.Show.Any(x => x.ShowStartDate > DateTime.Today)).ToListAsync();
                }
            }
            return  await _context.Movies.Include(x => x.Show).ToListAsync(); 

        }

        public async Task<IEnumerable<Movie>> Related(int movieId)
        {
            var movieGenres = await _context.Genres_Movies.Where(x => x.MovieId == movieId).Select(x => x.GenreId).ToListAsync();
            List<Movie> result = new List<Movie>();
            foreach (var item in movieGenres)
            {
                var movies = await _context.Movies.Include(x => x.Show).Where(x => x.Genres_Movies.Any(m => m.GenreId == item && m.MovieId != movieId)).ToListAsync();
                result.AddRange(movies);
            }
            return result.Distinct().Take(3);
        }


        // Hellper Function
        private async Task AddCoverPhoto(MovieCreateViewModel model, Movie Item, string folderPath, string ExistPhoto = null)
        {
            if (model.CoverPhoto != null)
            {
                if (ExistPhoto != null)
                {
                    string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "movies", ExistPhoto);
                    System.IO.File.Delete(FilePath);
                }
                Item.MovieImageURL = await UploadPhoto(model.CoverPhoto, folderPath);
            }
        }
        private async Task AddGallaryPhotos(MovieCreateViewModel model, Movie Item, string folderPath)
        {
            if (model.GallaryPhotos != null)
            {
                Item.MovieGallary = new List<Movie_Gallery>();
                foreach (var image in model.GallaryPhotos)
                {
                    Item.MovieGallary.Add(new Movie_Gallery()
                    {
                        MovieId = Item.Id,
                        ImageURL = await UploadPhoto(image, folderPath)
                    });
                }
            }
        }

        private void AddGenresMovies(MovieCreateViewModel model, Movie Item)
        {
            if (model.GenresId != null)
            {
                Item.Genres_Movies = new List<Genre_Movie>();
                foreach (var GenreMovie in model.GenresId)
                {
                    Item.Genres_Movies.Add(new()
                    {
                        GenreId = GenreMovie,
                        MovieId = Item.Id,
                    });
                }
            }
        }

        private void AddCrewMovies(MovieCreateViewModel model, Movie Item)
        {
            Item.Crew_Movies = new List<Crew_Movie>();
            if (model.ActorsId != null)
            {
                foreach (var ActorId in model.ActorsId)
                {
                    Item.Crew_Movies.Add(new Crew_Movie()
                    {
                        CrewId = ActorId,
                        MovieId = Item.Id,
                    });
                }
            }

            if (model.WritersId != null)
            {
                foreach (var writerId in model.WritersId)
                {
                    Item.Crew_Movies.Add(new Crew_Movie()
                    {
                        CrewId = writerId,
                        MovieId = Item.Id,
                    });
                }
            }

            if (model.DirectorsId != null)
            {
                foreach (var directorId in model.DirectorsId)
                {
                    Item.Crew_Movies.Add(new Crew_Movie()
                    {
                        CrewId = directorId,
                        MovieId = Item.Id,
                    });
                }
            }
        }



    }
}
