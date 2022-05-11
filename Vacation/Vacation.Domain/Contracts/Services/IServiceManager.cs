namespace Vacation.Domain.Contracts.Services
{
    public interface IServiceManager
    {
        ICountryService CountryService { get; }

        ICityService CityService { get; }

        IPlaceService PlaceService { get; }

        ICitizenService CitizenService { get; }

        IAchievementService AchievementService { get; }
    }
}
