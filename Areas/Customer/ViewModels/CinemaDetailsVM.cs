namespace MAXCINA.Areas.Customer.ViewModels
{
    public class CinemaDetailsVM
    {
        public Cinemas cinema { get; set; } =null!;
        public List<Movies> AvillableMovies { get; set; } = null!;
    }
}
