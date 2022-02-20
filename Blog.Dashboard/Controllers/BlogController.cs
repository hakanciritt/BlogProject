using Blog.Dashboard.ControllerTypes;
using Blog.Dashboard.Models.Blog;
using Business.Abstract;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Dashboard.Controllers
{
    public class BlogController : DashboardBaseController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new BlogListViewModel();
            var result = await _blogService.GetAllBlogListWithCategoryAsync();
            model.Blogs = result.Data;

            if (result.Success)
            {
                return View(model);
            }
            return View();
        }

        public async Task<IActionResult> Status(int id)
        {
            var result = await _blogService.BlogStatusUpdateAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExcelExportBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var work = workbook.Worksheets.Add("Blog Listesi");

                work.Cell(1, 1).Value = "Blog Id";
                work.Cell(1, 2).Value = "Blog Başlık";
                work.Cell(1, 3).Value = "Kategori Adı";
                work.Cell(1, 4).Value = "İçerik";
                work.Cell(1, 5).Value = "Durum";
                work.Cell(1, 6).Value = "Oluşturulma Tarihi";
                work.Cell(1, 7).Value = "Güncelleme Tarihi";

                var res = _blogService.GetBlogListWithCategoryAsync().Result.Data.Select((blog, index) => (blog, index));
                foreach (var (blog, index) in res)
                {
                    work.Cell(index + 2, 1).Value = blog.BlogId;
                    work.Cell(index + 2, 2).Value = blog.Title;
                    work.Cell(index + 2, 3).Value = blog.Category.Name;
                    work.Cell(index + 2, 4).Value = blog.Content;
                    //work.Cell(index + 2, 5).Value = blog.Status ? "Aktif" : "Pasif";
                    work.Cell(index + 2, 6).Value = blog.CreateDate;
                    work.Cell(index + 2, 7).Value = blog.UpdateDate;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogListesi.xlsx");
                }
            }
        }
    }
}
