namespace home_19.Core
{
    public class BaseService
    {
        protected BaseAPIClient apiClient;

        public BaseService(BaseAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }
    }
}
