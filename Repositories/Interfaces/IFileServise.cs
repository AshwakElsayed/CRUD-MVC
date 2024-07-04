namespace MovieStore_MVC.Repositories.Interfaces
{
    public interface IFileServise
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }
}
