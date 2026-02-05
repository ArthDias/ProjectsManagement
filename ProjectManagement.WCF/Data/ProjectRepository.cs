using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.WCF.Data
{
    public class ProjectRepository
    {
        private static ProjectRepository _instance;
        private static readonly object _lock = new object();
        private readonly List<Project> _projects;

        private ProjectRepository()
        {
            _projects = new List<Project>();
            LoadMockData();
        }

        public static ProjectRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ProjectRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        private void LoadMockData()
        {
            _projects.Add(new Project
            {
                ProjectNumber = "2024001",
                SubprojectNumber = "001",
                ProjectName = "Pesquisa em Inteligência Artificial",
                CoodinatorName = "Dr. Carlos Silva",
                Balance = 150000.00m,
            });

            _projects.Add(new Project
            {
                ProjectNumber = "2024002",
                SubprojectNumber = "001",
                ProjectName = "Desenvolvimento de Aplicações Web",
                CoodinatorName = "Profa. Ana Santos",
                Balance = 85000.50m
            });

            _projects.Add(new Project
            {
                ProjectNumber = "2024003",
                SubprojectNumber = "002",
                ProjectName = "Estudo de Energias Renováveis",
                CoodinatorName = "Dr. Roberto Oliveira",
                Balance = 220000.00m
            });
        }

        public bool RegisterProject(Project project)
        {
            try
            {
                lock (_lock)
                {
                    _projects.Add(project);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Project> GetAllProjects()
        {
            lock (_lock)
            {
                return new List<Project>(_projects);
            }
        }

        public List<Project> GetByProjectNumber(string ProjectNumber)
        {
            lock (_lock)
            {
                return _projects
                    .Where(p => p.ProjectNumber != null &&
                                p.ProjectNumber.IndexOf(ProjectNumber, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
        }

        public List<Project> GetByProjectName(string ProjectName)
        {
            lock (_lock)
            {
                return _projects
                    .Where(p => p.ProjectName != null &&
                                p.ProjectName.IndexOf(ProjectName, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
        }
    }
}
