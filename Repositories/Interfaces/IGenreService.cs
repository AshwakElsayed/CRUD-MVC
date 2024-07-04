using MovieStore_MVC.Models.DTO;
using MovieStore_MVC.Models.Domain;

namespace MovieStore_MVC.Repositories.Interfaces;

public interface IGenreService
{
   bool Add(Genre model);
   bool Update(Genre model);
   Genre GetById(int id);
   bool Delete(int id);
   IQueryable<Genre> List();

}
