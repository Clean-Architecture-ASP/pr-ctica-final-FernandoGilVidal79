namespace CleanArchitecture.Domain.Rents;

public sealed record DateRange{
    private DateRange()
    {

    }

    public DateOnly Start {get; init;}

    public DateOnly End {get; init;}

    public int DaysRent => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end){
        if (start > end)
        {
            throw new ApplicationException("La fecha final es anterior a la fecha de inicio");
        }

        return new  DateRange{
            Start = start,
            End = end
        };
    }
}