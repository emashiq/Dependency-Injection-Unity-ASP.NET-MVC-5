using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyInjection.Models;
using System.Data.Entity;

namespace DependencyInjection.Repository
{
    public class MovieRepository : IMovieRepository,IDisposable
    {
        private MovieDBContext _db;
        public MovieRepository(MovieDBContext db)
        {
            _db = db;
        }
        public void AddMovie(Movie movie)
        {
            _db.Movies.Add(movie);
        }

        public void DeleteMovie(Movie movie)
        {
           _db.Movies.Remove(movie);
        }


        public Movie GetMovie(int id)
        {
            return _db.Movies.Find(id);
        }

        public IQueryable<Movie> GetMovieList()
        {
            return _db.Movies.AsQueryable();
        }

        public void MovieCommit()
        {
            _db.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}