namespace BookMe.Domain.Bookings;

public record DateRange
{
    private DateRange(DateOnly start, DateOnly end)
    {
        Start = start;
        End = end;
    }

    private DateOnly Start { get; }
    private DateOnly End { get; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ApplicationException("Start date cannot be after end date");
        }

        return new DateRange(start, end);
    }
}