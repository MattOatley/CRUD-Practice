using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleAPP
{
    public interface IDepartmentRepository
    {
        // States that we need a method called GetAllDepartments that returns a collection
        // That conforms to IEnumerable<T>
        IEnumerable<Department> GetAllDepartments();
        void InsertDepartment(string newDepartmentName);
    }
}
