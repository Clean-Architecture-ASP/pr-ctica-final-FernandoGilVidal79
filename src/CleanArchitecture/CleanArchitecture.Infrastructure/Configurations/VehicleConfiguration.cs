using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Infrastructure.Configurations;


internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicles");
        builder.HasKey(vehicle  => vehicle.Id);
        builder.OwnsOne (vehicle => vehicle.Address);
        builder.Property(vehicle => vehicle.Model)
            .HasMaxLength(200)
            .HasConversion(model => model!.value, value => new Model(value));
        builder.Property(vehicle => vehicle.Vin)
            .HasMaxLength(500)
            .HasConversion(vin => vin!.value, value => new Vin(value));
        
        builder.OwnsOne(vehicle => vehicle.Price, priceBuilder => 
            {
            priceBuilder.Property(currency => currency.currencyType)
                .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
            }
        );

        builder.OwnsOne(vehicle => vehicle.Maintenance, priceBuilder => 
            {
                priceBuilder.Property(currency => currency.currencyType)
                .HasConversion(curremcyType => curremcyType.Code, code => CurrencyType.FromCode(code!));
            }
        );

    }
}
