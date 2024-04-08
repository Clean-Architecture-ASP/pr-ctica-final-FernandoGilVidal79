namespace CleanArchitecture.Domain.Vehicles;

public record Currency(decimal quantity, CurrencyType currencyType)
{
    public static Currency operator +(Currency first, Currency second)
    {
        if (first.currencyType != second.currencyType)
        {
            throw new InvalidOperationException("El tipo de moneda debe ser el mismo");
        }

        return new Currency(first.quantity + second.quantity, first.currencyType);
    }

    public static Currency Zero() => new Currency(0, CurrencyType.None);

    public static Currency Zero(CurrencyType currencyType) => new(0, currencyType);

    public bool IsZero() => this == Zero(currencyType);
}

