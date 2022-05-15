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
    public class TasksController : Controller
    {
        private readonly TasksService _service;
        public TasksController(TasksService service)
        {
            _service = service;
        }

        [HttpPost("add-task")]
        public IActionResult AddNewTask([FromBody] ProjectTaskVM task)
        {
            _service.AddTasksWithProject(task);
            return Ok();
        }

        [HttpGet("get-all-tasks")]
        public IActionResult GetAllTasks()
        {
            var result = _service.GetAllTasks();
            return Ok(result);
        }

        [HttpGet("get-task-by-id/{id}")]
        public IActionResult GetTaskById(int id)
        {
            var result = _service.GetTaskById(id);
            return Ok(result);
        }

        [HttpPut("update-task-by-id/{id}")]
        public IActionResult UpdateTaskById(int id, [FromBody]ProjectTaskVM task)
        {
            var result = _service.UpdateTaskById(id, task);
            return Ok(result);
        }

        [HttpPut("start-task-by-id/{id}")]
        public IActionResult StartTaskById(int id)
        {
            var result = _service.StartTaskById(id);
            return Ok(result);
        }

        [HttpPut("end-task-by-id/{id}")]
        public IActionResult EndTaskById(int id)
        {
            var result = _service.EndTaskById(id);
            return Ok(result);
        }

        [HttpDelete("delete-task-by-id/{id}")]
        public IActionResult DeleteTaskById(int id)
        {
            _service.DeleteTaskById(id);
            return Ok();
        }
    }
}
