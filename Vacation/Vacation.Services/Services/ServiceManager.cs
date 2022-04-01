using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Contracts.Services;

namespace Vacation.Services.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICountryService> _lazyCountryService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyCountryService = new Lazy<ICountryService>(() => new CountryService(repositoryManager));
        }

        public ICountryService CountryService => _lazyCountryService.Value;
    }
}
