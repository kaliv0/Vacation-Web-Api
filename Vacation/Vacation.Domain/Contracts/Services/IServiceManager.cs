namespace Vacation.Domain.Contracts.Services
{
    public interface IServiceManager
    {
        ICountryService CountryService { get; }

        ICityService CityService { get; }

        IAchievementService AchievementService { get; }
    }
}
