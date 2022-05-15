using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Services;
using Test.Data.ViewModels;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private readonly ProjectsService _service;
        public ProjectsController(ProjectsService service)
        {
            _service = service;
        }

        [HttpPost("add-project")]
        public IActionResult AddProject([FromBody] ProjectVM projectVM)
        {
            _service.AddProject(projectVM);
            return Ok();
        }

        [HttpGet("get-project-by-id/{id}")]
        public IActionResult GetProjectById(int id)
        {
            var result = _service.GetProjectDataById(id);
            return Ok(result);
        }

        [HttpGet("get-all-projects")]
        public IActionResult GetAllProjects()
        {
            var result = _service.GetAllProjectsData();
            return Ok(result);
        }

        [HttpPut("start-project-by-id/{id}")]
        public IActionResult StartProjectById(int id)
        {
            var result = _service.StartProjectById(id);
            return Ok(result);
        }

        [HttpPut("end-task-by-id/{id}")]
        public IActionResult EndProjectById(int id)
        {
            var result = _service.EndProjectById(id);
            return Ok(result);
        }

        [HttpDelete("delete-project-by-id/{id}")]
        public IActionResult DeleteProjectById(int id)
        {
            _service.DeleteProjectById(id);
            return Ok();
        }

        [HttpDelete("remove-task-from-project-by-id/{projectid}/{taskid}")]
        public IActionResult RemoveTaskFromProjectById(int projectid, int taskid)
        {
            _service.RemoveTaskFromProjectById(projectid, taskid);
            return Ok();
        }
    }
}
