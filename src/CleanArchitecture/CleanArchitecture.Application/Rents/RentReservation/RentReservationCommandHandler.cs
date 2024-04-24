using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehicles;

namespace CleanArchitecture.Application.Rents.RentReservation;


internal sealed class RentReservationCommandHandler : ICommandHandler<RentReservationCommand, Guid>
{

    private readonly IUserRepository _userRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IRentRepository _rentRepository;
    private readonly PriceService _priceService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public RentReservationCommandHandler(IUserRepository userRepository, IVehicleRepository vehicleRepository, IRentRepository rentRepository, PriceService priceService, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
    {
        _userRepository = userRepository;
        _vehicleRepository = vehicleRepository;
        _rentRepository = rentRepository;
        _priceService = priceService;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(RentReservationCommand request, CancellationToken cancellationToken)
    {
       var user = await _userRepository.GetByIdAsync(request.userId, cancellationToken);
       
       if (user == null)
       {
            return Result.Failure<Guid>(UserErrors.NotFound);
       }

       var vehicle = await _vehicleRepository.GetByIdAsync(request.vehicleId, cancellationToken);

       if (vehicle == null)
       {
            return Result.Failure<Guid>(VehicleErrors.NotFound);
       }

       var duration = DateRange.Create(request.dateStart, request.dateEnd);

       if (await _rentRepository.IsOverlappingAsync(vehicle, duration, cancellationToken))
       {
            return Result.Failure<Guid>(RentErrors.Overlap);
       }

     try{

       var rent = Rent.Renting(vehicle, user.Id, duration, _dateTimeProvider.CurrentTime, _priceService);
       _rentRepository.Add(rent);

      await _unitOfWork.SaveChangesAsync(cancellationToken);

       return rent.Id;
     }
     catch(ConcurrencyException)
     {
          return Result.Failure<Guid>(RentErrors.Overlap);
     }


    }
}