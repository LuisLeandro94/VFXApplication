using VFXApplication.Models;

namespace VFXApplication.Services
{
	public class InitializationService : IHostedService
	{
        private readonly IServiceScopeFactory _scopeFactory;

        public InitializationService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var apiContext = scope.ServiceProvider.GetRequiredService<ApiContext>();
                // Seeding users.
                // Here we are using Task.Run since AddTestData is synchronous and doesn't need to be async
                await Task.Run(() => UserService.AddTestData(apiContext));
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

