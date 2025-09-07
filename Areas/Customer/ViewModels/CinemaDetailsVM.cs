namespace MAXCINA.Areas.Customer.ViewModels
{
    public class CinemaDetailsVM
    {
        public int Id { get; set; }
        public Cinemas cinema { get; set; } =null!;
        public List<Movies> AvillableMovies { get; set; } = null!;
    }
}
