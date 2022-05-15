using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.ViewModels;
using Test.Models;

namespace Test.Data.Services
{
    public class TasksService
    {
        private AppDbContext _context;
        public TasksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTasksWithProject(ProjectTaskVM task)
        {
            var _task = new ProjectTask()
            {
                Name = task.Name,
                Description = task.Description,
                TaskStatus = Enums.TaskStatus.ToDo,
                TaskPriority = task.TaskPriority,
                ProjectId = task.ProjectId
            };

            _context.Tasks.Add(_task);
            _context.SaveChanges();

        }

        public List<ProjectTask> GetAllTasks() => _context.Tasks.ToList();

        public ProjectTaskVM GetTaskById(int taskId)
        {
            var _task = _context.Tasks.Where(n => n.Id == taskId).Select(task => new ProjectTaskVM()
            {
                Name = task.Name,
                Description = task.Description,
                TaskStatus = task.TaskStatus,
                TaskPriority = task.TaskPriority,
                ProjectId = task.ProjectId
            }).FirstOrDefault();

            return _task;
        }

        public ProjectTask UpdateTaskById(int taskId, ProjectTaskVM task)
        {
            var _task = _context.Tasks.FirstOrDefault(n => n.Id == taskId);
            if (_task != null)
            {
                _task.Name = task.Name;
                _task.Description = task.Description;
                _task.TaskStatus = task.TaskStatus;
                _task.TaskPriority = task.TaskPriority;
                _task.ProjectId = task.ProjectId;

                _context.SaveChanges();
            }

            return _task;
        }

        public ProjectTask StartTaskById(int taskId)
        {
            var _task = _context.Tasks.FirstOrDefault(n => n.Id == taskId);
            if(_task != null)
            {
                _task.TaskStatus = Enums.TaskStatus.InProgress;
                _context.SaveChanges();
            }

            return _task;
        }

        public ProjectTask EndTaskById(int taskId)
        {
            var _task = _context.Tasks.FirstOrDefault(n => n.Id == taskId);
            if (_task != null)
            {
                _task.TaskStatus = Enums.TaskStatus.Done;
                _context.SaveChanges();
            }

            return _task;
        }

        public void DeleteTaskById(int taskId)
        {
            var _task = _context.Tasks.FirstOrDefault(n => n.Id == taskId);
            if (_task != null)
            {
                _context.Tasks.Remove(_task);
                _context.SaveChanges();
            }
        }

    }
}
