namespace BookMe.Domain.Apartments;

public record Currency
{
    public static readonly Currency Usd = new("Usd");
    public static readonly Currency Eur = new("Eur");

    private Currency(string code) => Code = code;

    public string Code { get; init; }

    public static Currency FromCode(string? code)
    {
        return All.FirstOrDefault(c => c.Code.ToLower() == code?.ToLower()) ??
               throw new ApplicationException("The currency code is invalid");
    }
    
    public static IReadOnlyCollection<Currency> All => new[]
    {
        Usd, 
        Eur
    };
}