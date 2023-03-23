using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Data;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApiContext _context;

        public StudentController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit (Student student)
        {
            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Find(student.Id);
                if (studentInDb == null)
                    return new JsonResult(NotFound());
                studentInDb = student;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(student));
        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Students.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var ressult = _context.Students.Find(id);
            if (ressult == null)
                return new JsonResult(NotFound());
            _context.Students.Remove(ressult);
            _context.SaveChanges();
            return new JsonResult(Ok(NoContent()));
        }

        // Get All
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.Students.ToList();
            return new JsonResult(Ok(result));
        }
    }
}
