namespace Vacation.Domain.Contracts.Services
{
    public interface IServiceManager
    {
        ICountryService CountryService { get; }

        IAchievementService AchievementService { get; }
    }
}
