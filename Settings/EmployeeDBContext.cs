using Cardano_Catalyst.Interfaces;
using Cardano_Catalyst.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano_Catalyst.Settings
{
    public class EmployeeDBContext : IEmployee
    {
        public readonly IMongoDatabase _db;

        public EmployeeDBContext(IOptions<MongoDbConfig> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Employee> employeeCollection => 
            _db.GetCollection<Employee>("Employee");

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeCollection.Find(x => true).ToList();
        }
        public Employee GetEmployeeDetails(string Id)
        {
            var employeeDetails = employeeCollection.Find(x => x.Id == Id).FirstOrDefault();
            return employeeDetails;
        }

        public void Create(Employee employee)
        {
            employeeCollection.InsertOne(employee);
        }

        public void Update(string Id, Employee employee)
        {
            var filter = Builders<Employee>.Filter.Eq(x => x.Id, Id);
            var update = Builders<Employee>.Update
                .Set("Name", employee.Name)
                .Set("Department", employee.Department)
                .Set("Address", employee.Address)
                .Set("City", employee.City)
                .Set("Country", employee.Country);

            employeeCollection.UpdateOne(filter, update);
        }
        public void Delete(string Id)
        {
            var filter = Builders<Employee>.Filter.Eq(x => x.Id, Id);
            employeeCollection.DeleteOne(filter);
        }
    }
}
