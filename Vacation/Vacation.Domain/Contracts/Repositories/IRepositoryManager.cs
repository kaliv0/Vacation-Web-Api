namespace Vacation.Domain.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        ICountryRepository CountryRepository { get; }

        IAchievementRepository AchievementRepository { get; }
    }
}
