using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Models;
using Students.Repository;

namespace Students.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentsController(ApplicationDbContext context)
        {
            _studentRepository = new Repository.Repository(context);
        }

        public IActionResult Index()
        {
            return View(_studentRepository.GetAll());
        }

        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var student = _studentRepository.Get(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            if (!ModelState.IsValid) return View(student);

            _studentRepository.Insert(student);
            _studentRepository.Save();
            return Created(new Uri(RouteData.ToString(), UriKind.Relative), student);
        }
        
        public JsonResult GetById([FromRoute] string id)
        {
            var student = _studentRepository.Get(id);
            return Json(student);
        }

        [HttpPost]
        public IActionResult Edit(string id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);
            _studentRepository.Update(student);
            _studentRepository.Save();

            return Ok();

        }
    }
}