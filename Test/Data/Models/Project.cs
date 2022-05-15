using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Enums;

namespace Test.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public int ProjectPriority { get; set; }

        // Navigation properties
        public List<ProjectTask> Tasks { get; set; }


        public Project(int projid, string projname, string projdes, DateTime projstart, DateTime projend, Enum projstat, int projprior, List<ProjectTask> projtasks)
        {
            Id = projid;
            Name = projname;
            Description = projdes;
            StartDate = projstart;
            EndDate = projend;
            ProjectStatus = (ProjectStatus)projstat;
            ProjectPriority = projprior;
            Tasks = projtasks;
        }

        public Project()
        {

        }

    }
}
