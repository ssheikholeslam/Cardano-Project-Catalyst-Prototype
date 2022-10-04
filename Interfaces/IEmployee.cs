using Cardano_Catalyst.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano_Catalyst.Interfaces
{
    public interface IEmployee
    {
        IMongoCollection<Employee> employeeCollection { get; }
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeDetails(string Id);
        void Create(Employee employee);
        void Update(string Id, Employee employee);
        void Delete(string Id);
    }
}
