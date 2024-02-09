namespace WebSalesSystem.Shared.Infraestructure.Extensions;
public static class HashIntExtension
{
    public const string HashIdsSalt = "62067687-f2be-4a71-aef2-6dcaa25f3cdf";

    public static string ToHashId(this int number) => GetHasher().Encode(number);

    public static int FromHashId(this string encoded) => GetHasher().Decode(encoded).FirstOrDefault();

    private static Hashids GetHasher() => new(HashIdsSalt, 8);
}