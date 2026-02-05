using System;

namespace ProjectManagement.Models
{
    [Serializable]
    public class Project
    {
        public string ProjectNumber { get; set; }
        public string SubprojectNumber { get; set; }
        public string ProjectName { get; set; }
        public string CoodinatorName { get; set; }
        public decimal Balance { get; set; }

        public Project()
        {
        }

        public Project(string projectNumber, string subprojectNumber, string projectName, string coodinatorName, decimal balance)
        {
            ProjectNumber = projectNumber;
            SubprojectNumber = subprojectNumber;
            ProjectName = projectName;
            CoodinatorName = coodinatorName;
            Balance = balance;
        }

    }
}
