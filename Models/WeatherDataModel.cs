using NPOI.SS.UserModel;

namespace WeatherDataWebManager.Models
{
    public class WeatherDataModel
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double DewPoint { get; set; }
        public double Pressure { get; set; }
        public string[] WindDirections { get; set; }
        public double WindSpeed { get; set; }
        public double CloudCover { get; set; }
        public double LowerCloudLimitInMeters { get; set; }
        public double HorizontalVisibilityInKilometers { get; set; }
        public string WeatherPhenomena { get; set; }
    }
}
