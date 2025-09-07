namespace MAXCINA.Areas.Customer.ViewModels
{
    public class MovieDetailsVM
    {
        public Movies Movie { get; set; } =null!;
        public List<Movies> SimilarMovies { get; set; } = null!;
    }
}
