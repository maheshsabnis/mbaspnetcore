using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreapiapp.Controllers
{
    [Route("api/[controller]")]
   // [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IServiceRepository<Department, int> deptRepo;
        /// <summary>
        /// Dependency Injection of Repository
        /// </summary>
        /// <param name="repo"></param>
        public DepartmentController(IServiceRepository<Department, int> repo)
        {
            deptRepo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ResponseStatus<Department> response = new ResponseStatus<Department>();
                response = deptRepo.GetRecords();
                return Ok(response.Records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ResponseStatus<Department> response = new ResponseStatus<Department>();
                response = deptRepo.GetRecord(id);
                return Ok(response.Record);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post(Department dept)
        {
            ResponseStatus<Department> response = new ResponseStatus<Department>();
            //try
            //{
                if (ModelState.IsValid)
                {
                    if (dept.Capacity <= 0)
                        throw new Exception("Capacity cannot be 0 or -ve");  
                    response = deptRepo.CreateRecord(dept);
                    return Ok(response);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Error Occurred {ex.Message}");
            //}
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Department dept)
        {
            ResponseStatus<Department> response = new ResponseStatus<Department>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = deptRepo.UpdateRecord(id,dept);
                    return Ok(response);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseStatus<Department> response = new ResponseStatus<Department>();
            try
            {
                response = deptRepo.DeleteRecord(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Occurred {ex.Message}");
            }
        }

    }
}
