using home_19.BusinessObject.Models;
using home_19.Core;
using RestSharp;

namespace home_19.BusinessObject.Services
{
    public class ProjectService : BaseService
    {
        public string GetProjectByCodeEndpoint = "/project/{code}";
        public string AccessToProjectByCodeEndpoint = "/project/{code}/access";
        public string ProjectEndpoint = "/project";

        public ProjectService(BaseAPIClient apiClient) : base(apiClient) { }

        public RestResponse GetProjectByCode(string projectCode)
        {
            var request = new RestRequest(GetProjectByCodeEndpoint).AddUrlSegment("code", projectCode);

            return apiClient.Execute(request);
        }

        public RestResponse GetProjects()
        {
            var request = new RestRequest(ProjectEndpoint);

            return apiClient.Execute(request);
        }

        public RestResponse DeleteProjectByCode(string projectCode)
        {
            var request = new RestRequest(GetProjectByCodeEndpoint, Method.Delete).AddUrlSegment("code", projectCode);

            return apiClient.Execute(request);
        }

        public RestResponse GrantAccessToProjectByCode(string projectCode, MemberModel member)
        {
            var request = new RestRequest(AccessToProjectByCodeEndpoint, Method.Post).AddUrlSegment("code", projectCode);
            request.AddBody(member);

            return apiClient.Execute(request);
        }

        public RestResponse RevokeAccessToProjectByCode(string projectCode, MemberModel member)
        {
            var request = new RestRequest(AccessToProjectByCodeEndpoint, Method.Post).AddUrlSegment("code", projectCode);
            request.AddBody(member);

            return apiClient.Execute(request);
        }

        public RestResponse CreateProject(CreateProjectModel project)
        {
            var request = new RestRequest(ProjectEndpoint, Method.Post);
            request.AddBody(project);

            return apiClient.Execute(request);
        }

        public Project GetProjectByCode<ProjectType>(string projectCode) where ProjectType : Project
        {
            var request = new RestRequest(GetProjectByCodeEndpoint).AddUrlSegment("code", projectCode);

            return apiClient.Execute<CommonResultResponse<Project>>(request).Result;
        }
    }
}
