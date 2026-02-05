using System.Collections.Generic;
using System.ServiceModel;
using ProjectManagement.Models;

namespace ProjectManagement.WCF
{
    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        bool RegisterProject(Project project);

        [OperationContract]
        List<Project> GetByProjectNumber(string ProjectNumber);

        [OperationContract]
        List<Project> GetByProjectName(string ProjectName);

        [OperationContract]
        List<Project> GetAllProjects();
    }
}
