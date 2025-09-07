namespace MAXCINA.ViewModels
{
    public class CinemasVM
    {
        public string Name { get; set;}
        public string Description { get; set; }
        public string CinemaLogo { get; set; }
        public string Address { get; set; }
        public List<MoviesVM> Movies { get; set; }
    }
}
