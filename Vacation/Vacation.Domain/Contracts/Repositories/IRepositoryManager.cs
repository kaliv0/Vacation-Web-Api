namespace Vacation.Domain.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        ICountryRepository CountryRepository { get; }

        ICityRepository CityRepository { get; }

        IAchievementRepository AchievementRepository { get; }
    }
}
