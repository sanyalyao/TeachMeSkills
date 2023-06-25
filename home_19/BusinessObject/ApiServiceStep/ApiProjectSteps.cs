using home_19.BusinessObject.Models;
using home_19.BusinessObject.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace home_19.BusinessObject.ApiServiceStep
{
    public class ApiProjectSteps
    {
        protected ProjectService ProjectService;

        public ApiProjectSteps(ProjectService projectService)
        {
            ProjectService = projectService;
        }

        public Project GetProjectByCodeSteps(string code)
        {
            var response = ProjectService.GetProjectByCode(code);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<Project>>(response.Content).Result;
        }

        public List<Project> GetProjectsSteps()
        {
            RestResponse response = ProjectService.GetProjects();

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<EntityProjects<List<Project>>>>(response.Content).Result.Entities;
        }
    }
}
