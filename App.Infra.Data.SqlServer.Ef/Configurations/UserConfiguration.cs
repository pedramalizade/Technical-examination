using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.SqlServer.Ef.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<CarOfUser>
    {
        public void Configure(EntityTypeBuilder<CarOfUser> builder)
        {

            builder.HasKey(x => x.Id);
            builder.ToTable("CarOfUsers");
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(11).IsRequired();
            builder.Property(x => x.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.LicensePlateCar).HasMaxLength(6).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(100).IsRequired();



        }
    }
}
