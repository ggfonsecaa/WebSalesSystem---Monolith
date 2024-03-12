namespace WebSalesSystem.Shared.Domain.Extensions;
internal static class HeaderDictionaryExtension
{
    public static CultureInfo GetCultureInfo(this IHeaderDictionary header)
    {
        List<(string, decimal)>? languages = [];
        string? acceptedLanguage = header.AcceptLanguage;

        if (acceptedLanguage == null || acceptedLanguage?.Length == 0)
        {
            return new CultureInfo("es");
        }

        string[]? acceptedLanguages = acceptedLanguage?.Split(',');

        foreach (string language in acceptedLanguages!)
        {
            string[]? languageDetails = language.Split(';');

            if (languageDetails.Length == 1)
            {
                languages.Add((languageDetails[0], 1));
            }
            else
            {
                languages.Add((languageDetails[0], Convert.ToDecimal(languageDetails[1].Replace("q=", ""))));
            }
        }

        string languageToSet = languages.OrderByDescending(l => l.Item2).First().Item1;
        return new CultureInfo(languageToSet);
    }
}