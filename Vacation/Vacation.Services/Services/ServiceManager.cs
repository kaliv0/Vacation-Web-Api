using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Contracts.Services;

namespace Vacation.Services.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICountryService> _lazyCountryService;
        private readonly Lazy<ICityService> _lazyCityService;
        private readonly Lazy<IPlaceService> _lazyPlaceService;
        private readonly Lazy<ICitizenService> _lazyCitizenService;
        private readonly Lazy<IAchievementService> _lazyAchievementService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyCountryService = new Lazy<ICountryService>(()
                => new CountryService(repositoryManager));

            _lazyCityService = new Lazy<ICityService>(()
                => new CityService(repositoryManager));

            _lazyPlaceService = new Lazy<IPlaceService>(()
                => new PlaceService(repositoryManager));

            _lazyCitizenService = new Lazy<ICitizenService>(()
                => new CitizenService(repositoryManager));

            _lazyAchievementService = new Lazy<IAchievementService>(()
                => new AchievementService(repositoryManager));
        }

        public ICountryService CountryService => _lazyCountryService.Value;

        public ICityService CityService => _lazyCityService.Value;

        public IPlaceService PlaceService => _lazyPlaceService.Value;

        public ICitizenService CitizenService => _lazyCitizenService.Value;

        public IAchievementService AchievementService => _lazyAchievementService.Value;
    }
}
