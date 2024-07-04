
using MovieStore_MVC.Models.DTO;
using MovieStore_MVC.Models.Domain;

namespace MovieStore_MVC.Repositories.Interfaces
{
    public interface IMovieService
    {
       bool Add(Movie model);
       bool Update(Movie model);
       Movie GetById(int id);
       bool Delete(int id);
        IQueryable<Movie> List();
       MovieListVm List(string term = "", bool paging = false, int currentPage = 0);
       List<int> GetGenreByMovieId(int movieId);

    }
}
