using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.ViewModels;
using Test.Models;

namespace Test.Data.Services
{
    public class ProjectsService
    {
        private AppDbContext _context;
        public ProjectsService()
        {

        }
        public ProjectsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddProject(ProjectVM project)
        {
            var _project = new Project()
            {
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ProjectStatus = Enums.ProjectStatus.NotStarted,
                ProjectPriority = project.ProjectPriority
            };

            _context.Projects.Add(_project);
            _context.SaveChanges();

        }

        public List<Project> GetAllProjectsData()
        {
            var _allProjectData = _context.Projects.ToList();
            return _allProjectData;
        }

        public ProjectWithTasksVM GetProjectDataById(int projectId)
        {
            var _projectData = _context.Projects.Where(n => n.Id == projectId).Select(n => new ProjectWithTasksVM()
            {
                Name = n.Name,
                Description = n.Description,
                StartDate = n.StartDate,
                EndDate = n.EndDate,
                ProjectStatus = n.ProjectStatus,
                ProjectPriority = n.ProjectPriority,
                Tasks = n.Tasks.Select(n => new ProjectTaskVM()
                {
                    Name = n.Name,
                    Description = n.Description,
                    TaskStatus = n.TaskStatus,
                    TaskPriority = n.TaskPriority,
                    ProjectId = n.ProjectId
                }).ToList()
            }).FirstOrDefault();

            return _projectData;
        }

        public Project StartProjectById(int projectId)
        {
            var _project = _context.Projects.FirstOrDefault(n => n.Id == projectId);
            if(_project != null)
            {
                _project.ProjectStatus = Enums.ProjectStatus.Active;
                _context.SaveChanges();
            }

            return _project;
        }

        public Project EndProjectById(int projectId)
        {
            var _project = _context.Projects.FirstOrDefault(n => n.Id == projectId);
            if (_project != null)
            {
                _project.ProjectStatus = Enums.ProjectStatus.Completed;
                _context.SaveChanges();
            }

            return _project;
        }

        public void DeleteProjectById(int id)
        {
            var _project = _context.Projects.FirstOrDefault(n => n.Id == id);

            if (_project != null)
            {
                _context.Projects.Remove(_project);
                _context.SaveChanges();
            }
        }

        public void RemoveTaskFromProjectById(int projectid, int taskid)
        {
            var _project = _context.Projects.FirstOrDefault(n => n.Id == projectid);
            var _task = _context.Tasks.FirstOrDefault(n => n.Id == taskid);

            if(_project != null)
            {
                if(_task != null)
                {
                    _project.Tasks.Remove(_task);
                    _context.SaveChanges();
                }
            }
        }

        public void SortProjectByName()
        {

        }

    }
}
