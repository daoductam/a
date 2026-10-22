using System;
using System.ComponentModel.DataAnnotations;

namespace a.Models
{
    public class DailyForecast
    {
        [Display(Name = "Mã thành phố")]
        [Required(ErrorMessage = "Vui lòng chọn hoặc nhập mã thành phố")]
        public string CityID { get; set; } = string.Empty;

        [Display(Name = "Ngày dự báo")]
        [Required(ErrorMessage = "Vui lòng chọn ngày dự báo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ForecastDate { get; set; }

        [Display(Name = "Nhiệt độ thấp nhất")]
        [Required(ErrorMessage = "Vui lòng nhập nhiệt độ thấp nhất")]
        public double MinTemperature { get; set; }

        [Display(Name = "Nhiệt độ cao nhất")]
        [Required(ErrorMessage = "Vui lòng nhập nhiệt độ cao nhất")]
        public double MaxTemperature { get; set; }

        [Display(Name = "Độ ẩm")]
        [Required(ErrorMessage = "Vui lòng nhập độ ẩm")]
        public int Humidity { get; set; }

        [Display(Name = "Nhiệt độ trung bình")]
        public double AvgTemperature
        {
            get
            {
                return (MaxTemperature + MinTemperature) / 2.0;
            }
        }

        public DailyForecast()
        {
        }

        public DailyForecast(string cityId, DateTime forecastDate, double minTemperature, double maxTemperature, int humidity)
        {
            CityID = cityId;
            ForecastDate = forecastDate;
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            Humidity = humidity;
        }
    }
}
