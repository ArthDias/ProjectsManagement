using ProjectManagement.WCF.Data;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjectManagement.WCF
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectRepository _repository;

        public ProjectService()
        {
            _repository = ProjectRepository.Instance;
        }

        public bool RegisterProject(Project project)
        {
            try
            {
                Thread.Sleep(1000);

                if (project == null)
                    return false;

                return _repository.RegisterProject(project);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Project> GetByProjectNumber(string numeroproject)
        {
            try
            {
                Thread.Sleep(800);

                if (string.IsNullOrWhiteSpace(numeroproject))
                    return new List<Project>();

                return _repository.GetByProjectNumber(numeroproject);
            }
            catch (Exception)
            {
                return new List<Project>();
            }
        }

        public List<Project> GetByProjectName(string nomeproject)
        {
            try
            {
                Thread.Sleep(800);

                if (string.IsNullOrWhiteSpace(nomeproject))
                    return new List<Project>();

                return _repository.GetByProjectName(nomeproject);
            }
            catch (Exception)
            {
                return new List<Project>();
            }
        }

        public List<Project> GetAllProjects()
        {
            try
            {
                Thread.Sleep(800);

                return _repository.GetAllProjects();
            }
            catch (Exception)
            {
                return new List<Project>();
            }
        }
    }
}
