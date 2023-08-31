namespace BookMe.Domain.Bookings;

public record DateRange
{
    private DateRange(DateOnly start, DateOnly end)
    {
        Start = start;
        End = end;
    }

    public DateOnly Start { get; }
    public DateOnly End { get; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start >= end)
        {
            throw new ApplicationException("End date must be after start date");
        }

        return new DateRange(start, end);
    }
}