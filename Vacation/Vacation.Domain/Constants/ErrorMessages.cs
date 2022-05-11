namespace Vacation.Domain.Constants
{
    public class ErrorMessages
    {
        public const string AchievementsByGivenCitizenNotFound = "No achievements by given citizen found.";
        public const string AchievementNotFound = "Achievement with given id not found.";

        public const string CitizensFromGivenCityNotFound = "No citizens from given city found.";
        public const string CitizenNotFound = "Citizen with given id not found.";
        public const string InvalidCitizenId = "CitizenId should be positive number.";

        public const string CitiesByGivenCitizenNotFound = "No cities from given country found.";
        public const string CityNotFound = "City with given id not found.";
        public const string InvalidCityId = "CityId should be positive number.";

        public const string CountryNotFound = "Country with given id not found.";
        public const string CountryAlreadyExists = "Country with given name already exists.";
        public const string InvalidCountryId = "CountryId should be positive number.";

        public const string PlacesInGivenCityNotFound = "No places in given city found.";
        public const string PlaceNotFound = "Place with given id not found.";

        public const string InvalidNameLength = "Name should not exceed 50 characters.";
    }
}
