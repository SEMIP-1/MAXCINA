namespace MAXCINA.Areas.Customer.ViewModels
{
    public class MoviesFilterVM
    {
        public List<Movies> movies { get; set; } = null!;
        public List<Categories> categories { get; set; } = null!;
        public List<Cinemas> cinemas { get; set; } = null!;
    }
}
