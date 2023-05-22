using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.OOXML.XSSF.UserModel;
using WeatherDataWebManager.Models;

namespace WeatherDataWebManager.Services.Classes
{
    public class ExcelWeatherDataModelsImporter
    {
        List<WeatherDataModel> weatherDataModels = new();
        DateOnly date;
        TimeOnly time;
        double temperature;
        double humidity;
        double dewPoint;
        double pressure;
        string[] windDirections = new string[] { };
        double windSpeed;
        double cloudCover;
        double lowerCloudLimitInMeters;
        double horizontalVisibilityInKm;
        string weatherPhenomena = string.Empty;

        string[] filesNames = new[] 
        { 
            "C:\\WebSites\\WeatherDataWebManager\\WeatherDataWebManager\\Weather.Moscow.2010-2014\\Weather.Moscow.2010-2014\\moskva_2010.xlsx",
            "C:\\WebSites\\WeatherDataWebManager\\WeatherDataWebManager\\Weather.Moscow.2010-2014\\Weather.Moscow.2010-2014\\moskva_2010.xlsxs",
            "C:\\WebSites\\WeatherDataWebManager\\WeatherDataWebManager\\Weather.Moscow.2010-2014\\Weather.Moscow.2010-2014\\moskva_2011.xlsx",
            "C:\\WebSites\\WeatherDataWebManager\\WeatherDataWebManager\\Weather.Moscow.2010-2014\\Weather.Moscow.2010-2014\\moskva_2012.xlsx",
            "C:\\WebSites\\WeatherDataWebManager\\WeatherDataWebManager\\Weather.Moscow.2010-2014\\Weather.Moscow.2010-2014\\moskva_2013.xlsx"
        };

        public List<WeatherDataModel> Import()
        {
            List<WeatherDataModel> weatherDataModels = new();
            foreach (string fileName in filesNames)
            {
                if (fileName.EndsWith("xlsx") ^ fileName.EndsWith("xls"))
                {
                    XSSFWorkbook xssfWorkbook = new XSSFWorkbook(fileName);
                    foreach (var sheet in xssfWorkbook)
                    {
                        int lastRawIndex = sheet.LastRowNum;
                        for (int i = 5; i < lastRawIndex; i++)
                        {
                            IRow row = sheet.GetRow(i);

                            if (row.Cells.ElementAt(0).CellType != CellType.Blank)
                            {
                                date = DateOnly.Parse(row.Cells.ElementAt(0).StringCellValue);
                            }
                            if (row.Cells.ElementAt(1).CellType != CellType.Blank)
                            {
                                time = TimeOnly.Parse(row.Cells.ElementAt(1).StringCellValue);
                            }
                            if (row.Cells.ElementAt(2).CellType != CellType.Blank)
                            {
                                temperature = row.Cells.ElementAt(2).NumericCellValue;
                            }
                            if (row.Cells.ElementAt(3).CellType != CellType.Blank)
                            {
                                humidity = row.Cells.ElementAt(3).NumericCellValue;
                            }
                            if (row.Cells.ElementAt(4).CellType != CellType.Blank)
                            {
                                dewPoint = row.Cells.ElementAt(4).NumericCellValue;
                            }
                            if (row.Cells.ElementAt(5).CellType != CellType.Blank)
                            {
                                pressure = row.Cells.ElementAt(5).NumericCellValue;
                            }
                            if (row.Cells.ElementAt(6).CellType != CellType.Blank)
                            {
                                windDirections = row.Cells.ElementAt(6).StringCellValue.Split(new char[] { ' ', ',' });
                            }
                            if (row.Cells.ElementAt(7).CellType != CellType.Blank)
                            {
                                try
                                {
                                    windSpeed = row.Cells.ElementAt(7).NumericCellValue;
                                }
                                catch { }
                            }
                            if (row.Cells.ElementAt(8).CellType != CellType.Blank)
                            {
                                try
                                {
                                    cloudCover = row.Cells.ElementAt(8).NumericCellValue;
                                }
                                catch
                                {
                                    cloudCover = 0;
                                }
                            }
                            if (row.Cells.ElementAt(9).CellType != CellType.Blank)
                            {
                                try
                                {
                                    lowerCloudLimitInMeters = row.Cells.ElementAt(9).NumericCellValue;
                                }
                                catch
                                {

                                }
                            }
                            if (row.Cells.ElementAt(10).CellType != CellType.Blank)
                            {
                                try
                                {
                                    horizontalVisibilityInKm = row.Cells.ElementAt(10).NumericCellValue;
                                }
                                catch { horizontalVisibilityInKm = 0; }
                            }
                            try
                            {
                                if (row.Cells.ElementAt(11).CellType != CellType.Blank)
                                {
                                    weatherPhenomena = row.Cells.ElementAt(11).StringCellValue;
                                }
                            }
                            catch
                            {

                            }
                            weatherDataModels.Add(new WeatherDataModel
                            {
                                CloudCover = cloudCover,
                                Date = date,
                                DewPoint = dewPoint,
                                HorizontalVisibilityInKilometers = horizontalVisibilityInKm,
                                Humidity = humidity,
                                LowerCloudLimitInMeters = lowerCloudLimitInMeters,
                                Pressure = pressure,
                                Temperature = temperature,
                                Time = time,
                                WeatherPhenomena = weatherPhenomena,
                                WindDirections = windDirections,
                                WindSpeed = windSpeed
                            });
                        }
                    }
                }
            }
            return weatherDataModels;
        }
    }
}
