namespace WeatherDataWebManager.Models
{
    public class IndexViewModel
    {
        public IEnumerable<WeatherDataModel> WeatherDataModels { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
