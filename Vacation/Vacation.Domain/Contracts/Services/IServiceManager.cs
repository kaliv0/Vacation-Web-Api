namespace Vacation.Domain.Contracts.Services
{
    public interface IServiceManager
    {
        ICountryService CountryService { get; }
    }
}
