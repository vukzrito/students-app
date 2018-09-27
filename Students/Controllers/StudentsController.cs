﻿using System;
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

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid) return View(student);

            await _studentRepository.Insert(student);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _studentRepository.Update(student);

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
    }
}