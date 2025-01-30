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
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Admins");
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50).IsRequired();


            builder.HasData(new List<Admin>()
            {
                new Admin(){Id = 1 , FirstName = "پدرام" ,LastName="علیزاده",UserName="Pedram" , Password="0909"}

            });
        }
    }
}
