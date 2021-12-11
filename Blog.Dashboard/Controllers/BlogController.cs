using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Dashboard.ControllerTypes;
using Blog.Dashboard.Models.Blog;
using Business.Abstract;
using ClosedXML.Excel;

namespace Blog.Dashboard.Controllers
{
    public class BlogController : DashboardBaseController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var model = new BlogListViewModel();
            var result = _blogService.GetBlogListWithCategory();
            if (result.Success)
            {
                return View(model);
            }
            return View();
        }

        public IActionResult ExcelExportBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var work = workbook.Worksheets.Add("Blog Listesi");

                work.Cell(1, 1).Value = "Blog Id";
                work.Cell(1, 2).Value = "Blog Başlık";
                work.Cell(1, 3).Value = "Kategori Adı";

                foreach (var (blog, index) in _blogService.GetBlogListWithCategory().Data.Select((blog, index) => (blog, index)))
                {
                    work.Cell(index + 2, 1).Value = blog.BlogId;
                    work.Cell(index + 2, 2).Value = blog.Title;
                    work.Cell(index + 2, 3).Value = blog.Category.Name;

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
