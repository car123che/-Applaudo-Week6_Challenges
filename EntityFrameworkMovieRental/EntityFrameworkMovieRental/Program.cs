using EFMovieRentalDomain;
using EFMovieRentalDomain.Models;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace EntityFrameworkMovieRental
{
    internal class Program
    {

        private static MovieRentalContext context = new MovieRentalContext();

        static async Task Main(string[] args)
        {
            //await AddTag("Miedo");
            //await  DeleteTag(3);
            // await UpdateTag(1, "Acción");
            /*var tags = await GetAllTags();
            foreach (var tag in tags)
            {
                 Console.WriteLine(tag.Name);
            }*/
            /*var tag = await GetTag(1);
            await Console.Out.WriteLineAsync(tag.Name);
            Console.ReadLine();*/


            //await AddMovie(new Movie() {  Title = "Avengers 4", Description = "Marvel Studios Avenger", PosterStock = 50, TrailerLink = "Avengers.com", SalePrice = 15.52, Likes = 90 });
            //await DeleteMovie(2);
            //await UpdateMovie(4, new Movie() { Title = "Buscando a Nemo", Description = "Nemo nemo", PosterStock = 4, TrailerLink = "Nemo.com", SalePrice = 9.52, Likes = 70 });
            /*var movies = await GetAllMovies();
            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Title);
            }*/
            /* var movie = await GetMovie(1);
             await Console.Out.WriteLineAsync(movie.Title);*/

            //await AddMovieTag(4, 7);
            //await DeleteMovieTag(3, 7);


            /*var movies = await  GetMovieTagsByMovie(1);
            foreach (var item in movies)
            {
                await Console.Out.WriteLineAsync(item.TagName + " | " + item.Title);
            }*/

            /*var movies = await  GetMovieTagsByTag(7);
            foreach (var item in movies)
            {
                await Console.Out.WriteLineAsync(item.TagName + " | " + item.Title);
            }*/
        }

       /* private static async Task QueryFilter()
        {
            var movies = await context.Movies.Where(e => e.Title.Contains("n")).ToListAsync();

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Title);
            }

        }


        // Crear un Tag
        static async Task AddTag(string Name)
        {
            var tag = new Tag() { Name = Name };
            await context.AddAsync(tag);

            await context.SaveChangesAsync();
        }


        // Eliminar un Tag
        static async Task DeleteTag(int Id)
        {
            var tag = await context.Tags.FindAsync(Id);
            context.Tags.Remove(tag);
            await context.SaveChangesAsync();
        }

        // Modificar un Tag
        static async Task UpdateTag(int Id, string newName)
        {
            var tag = await context.Tags.FindAsync(Id);
            tag.Name = newName;
            await context.SaveChangesAsync();
        }

        // Obtener Todos los Tags
        static async Task<List<Tag>> GetAllTags()
        {
            var tags = await context.Tags.ToListAsync();
            return tags;
        }


        // Obtener un Tag
        static async Task<Tag> GetTag(int Id)
        {
            var tag = await context.Tags.FindAsync(Id);
            return tag;
        }*/



        /*// Crear una pelicula
        static async Task AddMovie(Movie Movie)
        {
            await context.AddAsync(Movie);

            await context.SaveChangesAsync();
        }

        // Eliminar una pelicula
        static async Task DeleteMovie(int Id)
        {
            var movie = await context.Movies.FindAsync(Id);
            context.Movies.Remove(movie);
            await context.SaveChangesAsync();
        }

        // Modificar una pelicula
        static async Task UpdateMovie(int Id, Movie newMovie)
        {
            var movie = await context.Movies.FindAsync(Id);
            movie.Title= newMovie.Title;
            movie.Description = newMovie.Description;
            movie.PosterStock = newMovie.PosterStock;
            movie.TrailerLink = newMovie.TrailerLink;
            movie.SalePrice = newMovie.SalePrice;
            movie.Likes = newMovie.Likes;
            movie.Availability = newMovie.Availability;
            await context.SaveChangesAsync();
        }

        // Obtener todas las peliculas
        static async Task<List<Movie>> GetAllMovies()
        {
            var movies = await context.Movies.ToListAsync();
            return movies;
        }

        // Obtener una pelicula
        static async Task<Movie> GetMovie(int Id)
        {
            var movie = await context.Movies.FindAsync(Id);
            return movie;
        }*/


        // Vincular una pelicula con un Tag
        static async Task AddMovieTag(int movieId, int tagId)
        {
            var movieTag = new MovieTag() { MovieId =  movieId, TagId = tagId };
            await context.AddAsync(movieTag);

            await context.SaveChangesAsync();
        }

        // Eliminar Vinculo
        static async Task DeleteMovieTag(int movieId, int tagId)
        {
            await context.Database.ExecuteSqlRawAsync($"Delete from MovieTags  WHERE MovieId = {movieId} and TagId = {tagId}");
            await context.SaveChangesAsync();
        }

        // Obtener todos los Tags de una pelicula
        static async Task<List<MovieTagsDetail>> GetMovieTagsByMovie(int moveiId)
        {
            var movies = await context.MovieTags.Include(q => q.Movie).Select(
                    q =>
                    new MovieTagsDetail
                    {
                        Title = q.Movie.Title,
                        Description = q.Movie.Description,
                        PosterStock = q.Movie.PosterStock,
                        TrailerLink = q.Movie.TrailerLink,
                        SalePrice = q.Movie.SalePrice,
                        Likes = q.Movie.Likes,
                        Availability = q.Movie.Availability, 
                        TagName = q.Tag.Name,
                        MovieId = q.MovieId,
                        TagId = q.TagId
                    }
                ).Where( q => q.MovieId == moveiId).ToListAsync();

            return movies;

        }

        // Obtener todas las peliculas de un tag
        static async Task<List<MovieTagsDetail>> GetMovieTagsByTag(int tagId)
        {
            var movies = await context.MovieTags.Include(q => q.Movie).Select(
                    q =>
                    new MovieTagsDetail
                    {
                        Title = q.Movie.Title,
                        Description = q.Movie.Description,
                        PosterStock = q.Movie.PosterStock,
                        TrailerLink = q.Movie.TrailerLink,
                        SalePrice = q.Movie.SalePrice,
                        Likes = q.Movie.Likes,
                        Availability = q.Movie.Availability,
                        TagName = q.Tag.Name,
                        MovieId = q.MovieId,
                        TagId = q.TagId
                    }
                ).Where(q => q.TagId == tagId).ToListAsync();

            return movies;

        }

    }
}