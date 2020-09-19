using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MS.Customer.Persistence.src.Data
{
    public static class CustomerMappings
    {
        public static void OnModelCreating(EntityTypeBuilder<Domain.Customer> builder)
        {
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Birthday).HasColumnType("date");

            builder.Property(e => e.FirstName).IsRequired();

            builder.Property(e => e.LastName).IsRequired();

            builder.Property(e => e.Address).IsRequired();
           
            SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<Domain.Customer> builder)
    {
        var customers = new[]
        {
                new Domain.Customer
                {
                    Id = Guid.Parse("9f35b48d-cb87-4783-bfdb-21e36012930a"),
                    FirstName = "Will",
                    LastName = "Smith",
                    Address = "Adress-1",
                    Birthday = new DateTime(1961, 01, 01),
                },
                new Domain.Customer
                {
                    Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                    FirstName = "Brad",
                    LastName = "Pitt",
                    Address = "Adress-2",
                    Birthday = new DateTime(1962, 02, 02),
                },
                new Domain.Customer
                {
                    Id = Guid.Parse("971316e1-4966-4426-b1ea-a36c9dde1066"),
                    FirstName = "George",
                    LastName = "Clooney",
                    Address = "Adress-3",
                    Birthday = new DateTime(1963, 03, 03),
                }
            };

        builder.HasData(customers);
    }
}
}
