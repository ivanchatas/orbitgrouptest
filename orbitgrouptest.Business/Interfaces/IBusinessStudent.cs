﻿using orbitgrouptest.Transversal.Entities;
using System.Collections.Generic;

namespace orbitgrouptest.Business.Interfaces
{
    public interface IBusinessStudent
    {
        /// Read
        List<Student> Read();

        /// Read
        Student Read(int id);

        /// Create
        Student Create(Student student);

        /// Update
        Student Update(Student student);

        /// Delete
        public void Delete(int id);
    }
}
