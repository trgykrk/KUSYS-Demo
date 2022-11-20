using KUSYS_Demo.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IStudentService _studentService;

        public AdminController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> StudentList()
        {
            var studentList = await _studentService.GetDataAll();
            return View(studentList);
        }

        public async Task<IActionResult> StudentAdd()
        {
            var studentList = await _studentService.GetDataAll();
            return View(studentList);
        }
    }
}
