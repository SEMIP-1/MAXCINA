namespace MAXCINA.ViewModels
{
    public class CategoriesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MoviesVM> Movies { get; set; }
    }
}
