using orbitgrouptest.Data.Interfaces;
using orbitgrouptest.Transversal.Entities;
using System.Collections.Generic;
using System.Linq;

namespace orbitgrouptest.Data.Implements
{
    public class RepositoryStudent : IRepositoryStudent
    {
        /// Read
        public List<Student> Read()
        {
            using (var db = new Context())
            {
                return db.Students.ToList();
            }
        }

        /// Read
        public Student Read(int id)
        {
            using (var db = new Context())
            {
                return db.Students.FirstOrDefault(s => s.Id == id);
            }
        }

        /// Create
        public Student Create(Student student)
        {
            using (var db = new Context())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
            return student;
        }

        /// Update
        public Student Update(Student student)
        {
            using (var db = new Context())
            {
                db.Students.Update(student);
                db.SaveChanges(); // success
            }
            return student;
        }

        /// Delete
        public void Delete(int id)
        {
            using (var db = new Context())
            {
                var student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }

    }
}
