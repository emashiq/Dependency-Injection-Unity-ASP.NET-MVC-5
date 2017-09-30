using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Models;
namespace DependencyInjection.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        Movie GetMovie(int id);
        IQueryable<Models.Movie> GetMovieList();
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void MovieCommit();
        
        

    }
}
