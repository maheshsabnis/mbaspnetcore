using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreapiapp.Controllers
{
    /// <summary>
    /// Customizign the Route for accepting Request for
    /// Same HTTP Request Type Action Method but different in Names
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class DeptBindingController : ControllerBase
    {
        IServiceRepository<Department, int> deptRepo;
        public DeptBindingController(IServiceRepository<Department, int> deptRepo)
        {
            this.deptRepo = deptRepo;
        }

        /// <summary>
        /// http://sever/DeptBinding/PostDeptBody
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PoseDeptBody")]
        public IActionResult PostDeptBody([FromBody] Department dept)
        {
            return Ok(dept);
        }

        /// <summary>
        /// http://sever/DeptBinding/PostDeptQueryOldFashion?DeptNo=333&DeptName=ruru&Locaiton=rtrt&Capacity=99
        /// </summary>
        /// <param name="DeptNo"></param>
        /// <param name="DeptName"></param>
        /// <param name="Location"></param>
        /// <param name="Capacity"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PostDeptQueryOldFashion")]
        public IActionResult PostDeptQueryOldFashion(int DeptNo, string DeptName, string Location, int Capacity)
        {
            // Explicitly read Query Parameters and pass to CLR Object
            Department dept = new Department()
            {
                DeptNo = DeptNo,
                DeptName = DeptName,
                Location = Location,
                Capacity = Capacity
            };
            return Ok(dept);
        }
        /// <summary>
        ///  http://sever/DeptBinding/PostDeptQuery?DeptNo=333&DeptName=ruru&Locaiton=rtrt&Capacity=99
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PostDeptQuery")]
        public IActionResult PostDeptQuery([FromQuery]Department dept)
        {
           // FromQuery will Implicitly Map the QUery Parameters to CLR Object    
            return Ok(dept);
        }




        /// <summary>
        /// Explicitly Define Routing
        /// http://sever/DeptBinding/PostDeptRouteOldFashion/333/ruru/rtrt/99
        /// </summary>
        /// <param name="DeptNo"></param>
        /// <param name="DeptName"></param>
        /// <param name="Location"></param>
        /// <param name="Capacity"></param>
        /// <returns></returns>
        [HttpPost("{DeptNo}/{DeptName}/{Location}/{Capacity}")]
        [ActionName("PostDeptRouteOldFashion")]
        public IActionResult PostDeptRouteOldFashion(int DeptNo, string DeptName, string Location, int Capacity)
        {
            // Explicitly read Query Parameters and pass to CLR Object
            Department dept = new Department()
            {
                DeptNo = DeptNo,
                DeptName = DeptName,
                Location = Location,
                Capacity = Capacity
            };
            return Ok(dept);
        }


        /// <summary>
        ///  http://sever/DeptBinding/PostDeptRoute?DeptNo=333&DeptName=ruru&Locaiton=rtrt&Capacity=99
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost("{DeptNo}/{DeptName}/{Location}/Capacity")]
        [ActionName("PostDeptRoute")]
        public IActionResult PostDeptRoute([FromRoute] Department dept)
        {
            // FromRoute will Implicitly Map the Route Parameters to CLR Object    
            return Ok(dept);
        }
    }
}
