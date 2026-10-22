/*
 * CÂU 7: Sửa file RouteConfig.cs để phương thức Action Index của DailyForecastController được thực hiện mặc định khi truy cập ứng dụng.
 * 
 * 1. Nếu đề bài yêu cầu trên nền tảng ASP.NET MVC 5 (.NET Framework), code trong App_Start/RouteConfig.cs như sau:
 * 
 * using System.Web.Mvc;
 * using System.Web.Routing;
 * 
 * namespace a
 * {
 *     public class RouteConfig
 *     {
 *         public static void RegisterRoutes(RouteCollection routes)
 *         {
 *             routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
 * 
 *             routes.MapRoute(
 *                 name: "Default",
 *                 url: "{controller}/{action}/{id}",
 *                 defaults: new { controller = "DailyForecast", action = "Index", id = UrlParameter.Optional }
 *             );
 *         }
 *     }
 * }
 * 
 * 2. Nếu làm trên nền tảng ASP.NET Core (.NET 8.0 - Project hiện tại), routing mặc định được cấu hình trong file Program.cs:
 * 
 * app.MapControllerRoute(
 *     name: "default",
 *     pattern: "{controller=DailyForecast}/{action=Index}/{id?}");
 */

namespace a.App_Start
{
    public class RouteConfig
    {
        // Class tham chiếu cho Câu 7 phục vụ chấm bài
    }
}
