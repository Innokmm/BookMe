﻿namespace BookMe.Domain.Shared;

public record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money first, Money second)
    {
        if (first.Currency != second.Currency)
        {
            throw new InvalidOperationException("Currencies are different");
        }

        return first with { Amount = first.Amount + second.Amount };
    }

    public static Money operator *(Money first, Money second)
    {
        if (first.Currency != second.Currency)
        {
            throw new InvalidOperationException("Currencies are different");
        }

        return first with { Amount = first.Amount * second.Amount };
    }

    public static Money Zero(Currency currency) => new(0, currency);

    public bool IsZero() => this == Zero(Currency);
};