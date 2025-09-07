namespace MAXCINA.ViewModels
{
    public class ActorsVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public string News { get; set; }
        public List<MoviesVM> Movies { get; set; }
    }
}
