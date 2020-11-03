using Microsoft.AspNetCore.Mvc;
using orbitgrouptest.Business.Interfaces;
using orbitgrouptest.Transversal.Entities;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace orbitgrouptest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly IBusinessStudent repo;
        public StudentController(IBusinessStudent repo)
         => this.repo = repo;

        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Student> students;

            try
            {
                students = repo.Read();
                if (students == null) return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(students);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student student;

            try
            {
                student = repo.Read(id);
                if (student == null) return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post(Student student)
        {
            Student _student;

            try
            {
                _student = repo.Create(student);
                _student = repo.Read(_student.Id);
                if (_student == null) return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            Student _student;

            try
            {
                _student = repo.Read(id);
                if (_student == null) return NotFound();
                _student = repo.Update(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(_student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var student = repo.Read(id);
                if (student == null) return NotFound();
                repo.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
