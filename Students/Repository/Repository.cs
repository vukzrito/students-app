using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Models;

namespace Students.Repository
{
    public class Repository : IRepository<Student>
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student Get(string id)
        {
            return _context.Students.FirstOrDefault(m => m.Id == id);
        }

        public void Insert(Student student)
        {
            student.Id = Guid.NewGuid().ToString();
            _context.Add(student);
        }

        public void Update(Student student)
        {
            _context.Update(student);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}