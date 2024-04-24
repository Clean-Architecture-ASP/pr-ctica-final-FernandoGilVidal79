using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;


internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Name)
            .HasMaxLength(200)
            .HasConversion(name => name!.value, value => new Name (value));

        builder.Property(user => user.Surname)
            .HasMaxLength(200)
            .HasConversion(surname => surname!.value, value => new Surname (value));
        
            builder.Property(user => user.Email)
            .HasMaxLength(400)
            .HasConversion(email => email!.value, value => new Domain.Users.Email (value));
            
            builder.HasIndex(user => user.Email).IsUnique();
    }

}
