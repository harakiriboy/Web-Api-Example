using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Enums;
using Test.Models;

namespace Test.Data.ViewModels
{
    public class ProjectVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public int ProjectPriority { get; set; }

        public ProjectVM(string projname, string projdes, DateTime projstart, DateTime projend, Enum projstat, int projprior)
        {
            Name = projname;
            Description = projdes;
            StartDate = projstart;
            EndDate = projend;
            ProjectStatus = (ProjectStatus)projstat;
            ProjectPriority = projprior;
        }

    }

    public class ProjectWithTasksVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public int ProjectPriority { get; set; }

        // Navigation properties
        public List<ProjectTaskVM> Tasks { get; set; }
    }
}
