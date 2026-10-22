using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using a.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace a.Controllers
{
    public class DailyForecastController : Controller
    {
        // Khai báo danh sách List<DailyForecast>
        private static List<DailyForecast> forecasts = new List<DailyForecast>();

        // Phương thức khởi tạo không tham số của lớp, thêm 6 đối tượng vào danh sách
        public DailyForecastController()
        {
            if (forecasts.Count == 0)
            {
                forecasts.Add(new DailyForecast("001", new DateTime(2026, 10, 19), 24, 34, 80));
                forecasts.Add(new DailyForecast("002", new DateTime(2026, 10, 19), 26, 33, 40));
                forecasts.Add(new DailyForecast("003", new DateTime(2026, 10, 19), 20, 32, 98));
                forecasts.Add(new DailyForecast("001", new DateTime(2026, 10, 20), 20, 27, 68));
                forecasts.Add(new DailyForecast("002", new DateTime(2026, 10, 20), 23, 31, 90));
                forecasts.Add(new DailyForecast("003", new DateTime(2026, 10, 20), 18, 26, 90));
            }
        }

        // Câu 3: Action Index hiển thị hai danh sách trên cùng một trang
        public IActionResult Index()
        {
            // Danh sách 1: Thông tin thời tiết ngày 20/10/2026
            var listByDate = forecasts
                .Where(f => f.ForecastDate.Date == new DateTime(2026, 10, 20).Date)
                .ToList();

            // Danh sách 2: Thông tin thời tiết của Hà Nội (Mã thành phố 001)
            var listHanoi = forecasts
                .Where(f => f.CityID == "001")
                .ToList();

            ViewBag.ListByDate = listByDate;
            ViewBag.ListHanoi = listHanoi;

            return View();
        }

        // Helper tạo danh sách SelectListItem cho DropDownList
        private List<SelectListItem> GetCitySelectList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "001", Text = "001 - Hà Nội" },
                new SelectListItem { Value = "002", Text = "002 - TP. Hồ Chí Minh" },
                new SelectListItem { Value = "003", Text = "003 - Hải Phòng" }
            };
        }

        // Câu 4: Action Create (GET)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Cities = GetCitySelectList();
            return View();
        }

        // Câu 4: Action Create (POST) nhập thông tin đưa vào danh sách
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DailyForecast model)
        {
            if (ModelState.IsValid)
            {
                // Thêm đối tượng vào danh sách
                forecasts.Add(model);

                // Sau khi gửi dữ liệu, hiển thị toàn bộ thông tin của đối tượng vừa nhập trên View Details.cshtml
                return View("Details", model);
            }

            ViewBag.Cities = GetCitySelectList();
            return View(model);
        }

        // View Details để hiển thị thông tin đối tượng
        public IActionResult Details(DailyForecast model)
        {
            return View(model);
        }
    }
}
