using Microsoft.AspNetCore.Mvc;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
