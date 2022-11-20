using KUSYS_Demo.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var studentList = await _studentService.GetDataAll();
            return View(studentList);
        }

    }
}
