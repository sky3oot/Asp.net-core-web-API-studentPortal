using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Abstraction.Models;
using StudentPortal.Abstraction.Services;
using StudentPortal.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IStudentPortalServices _studentPortal;
        public LoginController(IStudentPortalServices studentPortalServices)
        {
            _studentPortal = studentPortalServices;
        }

        [HttpPost]
        public ActionResult<List<string>> SaveLogin([FromBody] Login login)
        {

            var result = _studentPortal.SaveLogin(login);
            if (result.Count < 1)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
        //[HttpGet]
        //public IActionResult GetDetails()
        //{
        //    var employees =  _studentPortal.GetLogin();
        //    return Ok(employees);
        //}
        [HttpPut]
        public IActionResult UpdateDetail([FromBody] Login login)
        {

            var result = _studentPortal.UpdateLogin(login);
            if (result.Count < 1)
            {

                return Ok();
            }
            else
            {
                return BadRequest(result);
            }

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDetail(Guid id)
        {
            _studentPortal.DeleteLogin(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(Guid id)
        {

            var data = _studentPortal.GetLogin(id);
            _studentPortal.GetLogin(id);

            return Ok(data);
        }

    }
}
