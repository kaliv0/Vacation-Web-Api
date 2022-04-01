using Vacation.Domain.Contracts.Repositories;

namespace Vacation.Data.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICountryRepository> _lazyCountryRepository;

        public RepositoryManager(VacationDbContext dbContext)
        {
            _lazyCountryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(dbContext));
        }

        public ICountryRepository CountryRepository => _lazyCountryRepository.Value;
    }
}
