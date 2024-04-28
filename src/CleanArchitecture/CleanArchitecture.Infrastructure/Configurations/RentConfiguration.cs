using CleanArchitecture.Domain.Apartments;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class RentConfiguration : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.ToTable("rents");
        builder.HasKey(rent => rent.Id);

        builder.OwnsOne(rent => rent.Price, priceBuilder => 
        {
            priceBuilder.Property(currency => currency.currencyType)
            .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });

        builder.OwnsOne(rent => rent.MaintenancePrice, priceBuilder => 
        {
            priceBuilder.Property(currency => currency.currencyType)
            .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });

        builder.OwnsOne(rent => rent.ExtraPrice, priceBuilder => 
        {
            priceBuilder.Property(currency => currency.currencyType)
            .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });

        builder.OwnsOne(rent => rent.TotalPrice, priceBuilder => 
        {
            priceBuilder.Property(currency => currency.currencyType)
            .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
        });

        builder.OwnsOne(rent => rent.Duration);

        builder.HasOne<Vehicle>().WithMany().HasForeignKey(rent => rent.VehiculeId);

        builder.HasOne<Apartment>().WithMany().HasForeignKey(rent => rent.VehiculeId);

        builder.HasOne<User>().WithMany().HasForeignKey(rent => rent.UserId);
    }
}
