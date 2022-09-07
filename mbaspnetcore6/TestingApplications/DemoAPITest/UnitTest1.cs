using Moq;
using Application.Dal.Contract;
using Application.Entities;
using coreapiapp;
using coreapiapp.Controllers;
using coreapiapp.Repositories;
using coreapiapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPITest;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetWithIdTest()
    {
        // 1. Arrange
        int id = 10;
        // 2. Lets Create Mock objects
        Mock<IDataAccess<Application.Entities.Department, int>> mockDataAccess = new Mock<IDataAccess<Department, int>>();
        // 3. Lets Create Mock Object for Repositories
        Mock<IServiceRepository<Application.Entities.Department, int>> mockRepository = new Mock<IServiceRepository<Application.Entities.Department, int>>();
        // 4. DepartmentController Object
        DepartmentController departmentController = new DepartmentController(mockRepository.Object);

        var acrtualResult =  departmentController.Get(id);
        Assert.IsInstanceOf<IActionResult>(acrtualResult);

        
    }

    [Test]
    public void PostTestBadResult()
    {
        // Arrangement
        // 1. Lets Create Mock objects
        Mock<IDataAccess<Application.Entities.Department, int>> mockDataAccess = new Mock<IDataAccess<Department, int>>();
        // 2. Lets Create Mock Object for Repositories
        Mock<IServiceRepository<Application.Entities.Department, int>> mockRepository = new Mock<IServiceRepository<Application.Entities.Department, int>>();
        // 3. DepartmentController Object
        DepartmentController departmentController = new DepartmentController(mockRepository.Object);

        // 4. Create Model State Dioctionary that will have Error Messages
        // Arranging the Expected Error Messages for the Model That wil be passed to the Post Method
      


        departmentController.ModelState.AddModelError("DeptName", "DeptName is Required");
        var Dept = new Department()
        {
            DeptNo = 1000,
            Location = "HAHAHAH",
            Capacity = 500
        };

        // Act
        var ActualResult = departmentController.Post(Dept);
        // Assertion
         Assert.IsInstanceOf<BadRequestObjectResult>(ActualResult);
    }
}
