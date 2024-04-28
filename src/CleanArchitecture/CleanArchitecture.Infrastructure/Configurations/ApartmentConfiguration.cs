using System.Diagnostics;
using CleanArchitecture.Domain.Apartments;
using CleanArchitecture.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.ToTable("apartments");
        builder.HasKey(apartment  => apartment.Id);
        builder.OwnsOne (apartment => apartment.Address);
        
        builder.OwnsOne(apartment => apartment.Price, priceBuilder => 
            {
            priceBuilder.Property(currency => currency.currencyType)
                .HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
            }
        );
     
    }
}