using RealEstateAgency.Models;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace RealEstateAgency.Services
{
    public class EmployeeService
    {
        private readonly DatabaseService _dbService;

        public EmployeeService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Employee> GetAllEmployees()
        {
            var query = "SELECT * FROM employees ORDER BY last_name, first_name";
            var dataTable = _dbService.ExecuteQueryDisconnected(query);
            return MapEmployees(dataTable);
        }

        public Employee? GetEmployeeById(int id)
        {
            var query = "SELECT * FROM employees WHERE id = @id";
            var parameters = new NpgsqlParameter[] { new("@id", id) };
            var dataTable = _dbService.ExecuteQueryConnected(query, parameters);

            return dataTable.Rows.Count > 0 ? MapEmployee(dataTable.Rows[0]) : null;
        }

        public void AddEmployee(Employee employee)
        {
            var query = @"
                INSERT INTO employees (first_name, last_name, middle_name, position, phone, email, hire_date, salary)
                VALUES (@first_name, @last_name, @middle_name, @position, @phone, @email, @hire_date, @salary)";

            var parameters = new NpgsqlParameter[]
            {
                new("@first_name", employee.FirstName),
                new("@last_name", employee.LastName),
                new("@middle_name", string.IsNullOrEmpty(employee.MiddleName) ? (object)DBNull.Value : employee.MiddleName),
                new("@position", employee.Position),
                new("@phone", string.IsNullOrEmpty(employee.Phone) ? (object)DBNull.Value : employee.Phone),
                new("@email", string.IsNullOrEmpty(employee.Email) ? (object)DBNull.Value : employee.Email),
                new("@hire_date", employee.HireDate ?? (object)DBNull.Value),
                new("@salary", employee.Salary ?? (object)DBNull.Value)
            };

            _dbService.ExecuteNonQuery(query, parameters);
        }

        public void UpdateEmployee(Employee employee)
        {
            var query = @"
                UPDATE employees 
                SET first_name = @first_name,
                    last_name = @last_name,
                    middle_name = @middle_name,
                    position = @position,
                    phone = @phone,
                    email = @email,
                    hire_date = @hire_date,
                    salary = @salary
                WHERE id = @id";

            var parameters = new NpgsqlParameter[]
            {
                new("@id", employee.Id),
                new("@first_name", employee.FirstName),
                new("@last_name", employee.LastName),
                new("@middle_name", string.IsNullOrEmpty(employee.MiddleName) ? (object)DBNull.Value : employee.MiddleName),
                new("@position", employee.Position),
                new("@phone", string.IsNullOrEmpty(employee.Phone) ? (object)DBNull.Value : employee.Phone),
                new("@email", string.IsNullOrEmpty(employee.Email) ? (object)DBNull.Value : employee.Email),
                new("@hire_date", employee.HireDate ?? (object)DBNull.Value),
                new("@salary", employee.Salary ?? (object)DBNull.Value)
            };

            _dbService.ExecuteNonQuery(query, parameters);
        }

        public void DeleteEmployee(int id)
        {
            var query = "DELETE FROM employees WHERE id = @id";
            var parameters = new NpgsqlParameter[] { new("@id", id) };
            _dbService.ExecuteNonQuery(query, parameters);
        }

        private List<Employee> MapEmployees(DataTable dataTable)
        {
            var employees = new List<Employee>();
            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(MapEmployee(row));
            }
            return employees;
        }

        private Employee MapEmployee(DataRow row)
        {
            return new Employee
            {
                Id = Convert.ToInt32(row["id"]),
                FirstName = row["first_name"].ToString() ?? string.Empty,
                LastName = row["last_name"].ToString() ?? string.Empty,
                MiddleName = row["middle_name"].ToString() ?? string.Empty,
                Position = row["position"].ToString() ?? string.Empty,
                Phone = row["phone"].ToString() ?? string.Empty,
                Email = row["email"].ToString() ?? string.Empty,
                HireDate = row["hire_date"] == DBNull.Value ? null : Convert.ToDateTime(row["hire_date"]),
                Salary = row["salary"] == DBNull.Value ? null : Convert.ToDecimal(row["salary"]),
                CreatedAt = Convert.ToDateTime(row["created_at"])
            };
        }
    }
}