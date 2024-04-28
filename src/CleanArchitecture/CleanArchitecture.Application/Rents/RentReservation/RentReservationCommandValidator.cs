using FluentValidation;

namespace CleanArchitecture.Application.Rents.RentReservation;

public class RentReservationCommandValidator : AbstractValidator<RentReservationCommand>
{
    public RentReservationCommandValidator()
    {
        RuleFor (c => c.userId).NotEmpty();
        RuleFor (c => c.vehicleId).NotEmpty();
        RuleFor (c => c.dateStart).LessThan(c=> c.dateEnd);
    }
}