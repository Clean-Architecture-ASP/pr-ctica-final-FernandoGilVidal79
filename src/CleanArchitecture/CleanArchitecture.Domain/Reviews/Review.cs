using System.Runtime.InteropServices;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Reviews.Events;

namespace CleanArchitecture.Domain.Reviews;

public sealed class Review : Entity
{
    private Review(Guid id,
                Guid vehicleId,
                Guid rentId,
                Guid userId,
                int rating,
                string comment,
                DateTime? creationDate
    
    
    ) : base(id)
    {
            VehicleId = vehicleId;
            RentId = rentId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
            CreationDate = creationDate;
    }



    public Guid VehicleId {get; private set;}

    public Guid RentId {get; private set;}

    public Guid UserId {get; private set;}

    public int Rating {get; private set;}

    public string? Comment {get; private set;}

    public DateTime? CreationDate {get ; private set;}


    public static Result<Review> Create(Rent rent, int rating, string comment, DateTime? creationDate)
    {
        if (rent.RentStatus != RentStatus.Completed)
        {
            return Result.Failure<Review>(ReviewErrors.NotChosen);
        }

        var review = new Review(Guid.NewGuid(), rent.VehiculeId, rent.Id, rent.UserId, rating, comment, creationDate);

        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));
        return review;
    }

}