namespace Vacation.Domain.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        ICountryRepository CountryRepository { get; }

        ICityRepository CityRepository { get; }

        IPlaceRepository PlaceRepository { get; }

        ICitizenRepository CitizenRepository { get; }

        IAchievementRepository AchievementRepository { get; }
    }
}
