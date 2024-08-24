namespace BlazorCRUD.Application.Services
{
    public abstract class BaseService
    {
        private readonly ILogger _logger;

        protected BaseService(ILogger logger)
        {
            _logger = logger;
        }

        protected void LogError(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

}
