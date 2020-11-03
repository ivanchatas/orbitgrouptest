using orbitgrouptest.Business.Interfaces;
using orbitgrouptest.Data.Interfaces;
using orbitgrouptest.Transversal.Entities;
using System.Collections.Generic;

namespace orbitgrouptest.Business.Implements
{
    public class BusinessStudent : IBusinessStudent
    {
        readonly IRepositoryStudent repo;

        public BusinessStudent(IRepositoryStudent respository)
            => repo = respository;

        public List<Student> Read()
            => repo.Read();

        public Student Read(int id)
            => repo.Read(id);

        public Student Create(Student student)
            => repo.Create(student);

        public Student Update(Student student) 
            => repo.Update(student);

        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}
