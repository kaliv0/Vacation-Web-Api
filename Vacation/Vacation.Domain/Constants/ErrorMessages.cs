namespace Vacation.Domain.Constants
{
    public class ErrorMessages
    {
        public const string NoAchievementsFound = "No achievements found.";
        public const string AchievementNotFound = "Achievement with given id not found.";

        public const string NoCitizensFound = "No citizens found.";
        public const string CitizenNotFound = "Citizen with given id not found.";
        public const string InvalidCitizenId = "CitizenId should be positive number.";

        public const string NoCitiesFound = "No cities found.";
        public const string CityNotFound = "City with given id not found.";
        public const string InvalidCityId = "CityId should be positive number.";

        public const string NoCountriesFound = "No countries found.";
        public const string CountryNotFound = "Country with given id not found.";
        public const string CountryAlreadyExists = "Country with given name already exists.";
        public const string InvalidCountryId = "CountryId should be positive number.";

        public const string NoPlacesFound = "No places found.";
        public const string PlaceNotFound = "Place with given id not found.";

        public const string InvalidNameLength = "Name should not exceed 50 characters.";
        public const string NoItemsFound = "No items found by given search criteria.";
    }
}
