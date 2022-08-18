using System;
using Application.Dal.Contract;
using Application.Entities;
namespace Application.Data.DataAccess;

public class EmployeeDataAccess : IDataAccess<Employee, int>
{
    Employee IDataAccess<Employee, int>.Create(Employee entity)
    {
        throw new NotImplementedException();
    }

    Employee IDataAccess<Employee, int>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Employee> IDataAccess<Employee, int>.Get()
    {
        throw new NotImplementedException();
    }

    Employee IDataAccess<Employee, int>.Get(int id)
    {
        throw new NotImplementedException();
    }

    Employee IDataAccess<Employee, int>.Update(int id, Employee entity)
    {
        throw new NotImplementedException();
    }
}
 
