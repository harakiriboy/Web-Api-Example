using System;
using System.Collections.Generic;
using System.Linq;
using Test.Data.Enums;
using Test.Models;

namespace Test.Data.ViewModels
{
    public class ProjectTaskVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int TaskPriority { get; set; }

        // Navigation properties
        public int ProjectId { get; set; }
    }
}
