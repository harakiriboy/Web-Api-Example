using NUnit.Framework;
using System;
using System.Collections.Generic;
using Test.Data;
using Test.Data.Services;
using Test.Data.ViewModels;
using Test.Models;

namespace UnitTests
{
    public class ProjectsServiceTests
    {
        ProjectsService projectsService;

        [SetUp]
        public void Setup()
        {
            projectsService = new ProjectsService();
        }


        [Test]
        public void AddProject_Works()
        {
            // Arrange
            Project project1 = new Project(1, "Project1", "Description1", new DateTime(2008, 12, 15), new DateTime(2008, 12, 16), Test.Data.Enums.ProjectStatus.NotStarted, 1, null);
            List<Project> Projects = new List<Project> { };
            ProjectVM projectvm = new ProjectVM("Project1", "Description1", new DateTime(2008, 12,15), new DateTime(2008,12,16), Test.Data.Enums.ProjectStatus.NotStarted, 1);

            // Act
            projectsService.AddProject(projectvm);

            // Assert
        }
    }
}
