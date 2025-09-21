namespace MAXCINA.Areas.Customer.ViewModels
{
    public class FilterVM
    {
        public string? Name { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; } 
        public int? categoryId { get; set; }
        public int? cinemaId { get; set; }
        public bool isTranding { get; set; }
    }
}
