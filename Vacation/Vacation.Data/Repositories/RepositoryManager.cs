using Vacation.Domain.Contracts.Repositories;

namespace Vacation.Data.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICountryRepository> _lazyCountryRepository;
        private readonly Lazy<ICityRepository> _lazyCityRepository;
        private readonly Lazy<IAchievementRepository> _lazyAchievementRepository;

        public RepositoryManager(VacationDbContext dbContext)
        {
            _lazyCountryRepository = new Lazy<ICountryRepository>(()
                => new CountryRepository(dbContext));

            _lazyCityRepository = new Lazy<ICityRepository>(()
                => new CityRepository(dbContext));

            _lazyAchievementRepository = new Lazy<IAchievementRepository>(()
                => new AchievementRepository(dbContext));
        }

        public ICountryRepository CountryRepository => _lazyCountryRepository.Value;

        public ICityRepository CityRepository => _lazyCityRepository.Value;

        public IAchievementRepository AchievementRepository => _lazyAchievementRepository.Value;
    }
}
