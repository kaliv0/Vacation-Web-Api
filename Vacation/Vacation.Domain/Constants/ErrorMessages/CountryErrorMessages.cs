namespace Vacation.Domain.Constants.ErrorMessages
{
    public class CountryErrorMessages
    {
        public const string CountryNotFound = "Country with given id not found.";
        public const string CountryAlreadyExists = "Country with given name already exists.";
        public const string InvalidNameLength = "Country name should not exceed 50 characters.";
    }
}
