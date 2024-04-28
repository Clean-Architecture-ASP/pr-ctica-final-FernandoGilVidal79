using CleanArchitecture.Application.Abstractions.Email;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Rents.Events;
using CleanArchitecture.Domain.Users;
using MediatR;

namespace CleanArchitecture.Application.Rents.RentReservation;

internal sealed class RentReservationDomainEventHandler : INotificationHandler<RentReservedDomainEvent>
{
    private readonly IRentRepository _rentRepository;
    private readonly IUserRepository _userRespository;
    private readonly IEmailService _emailsService;

    public RentReservationDomainEventHandler(IRentRepository rentRepository, IUserRepository userRespository, IEmailService emailsService)
    {
        _rentRepository = rentRepository;
        _userRespository = userRespository;
        _emailsService = emailsService;
    }

    public async Task Handle(RentReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var rent = await _rentRepository.GetByIdAsync(notification.rentId, cancellationToken);

        if (rent == null)
        {
            return;
        }

        var user = await _userRespository.GetByIdAsync(rent.UserId, cancellationToken);

        if (user is null)
        {
            return;             
        }


        await _emailsService.SendAsync(user.Email, "Alquiler Reservado", "Tienes que confirmar esta reserva, de lo contrario se cancelará");
    }
}