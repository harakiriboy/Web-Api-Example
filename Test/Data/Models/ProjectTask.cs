using System;
using System.Collections.Generic;
using System.Linq;
using Test.Data.Enums;

namespace Test.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int TaskPriority { get; set; }

        // Navigation properties
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
