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
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Models");
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.HasMany(x => x.usercars)
              .WithOne(x => x.Model)
              .HasForeignKey(x => x.ModelId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Model>()
            {
                new Model(){Id = 1 , Title = "دنا"},
                new Model(){Id = 2 , Title = "206"},
                new Model(){Id = 3 , Title = "207"},
                new Model(){Id = 4 , Title = "تیبا"},
                new Model(){Id = 5 , Title = "تارا"},
                new Model(){Id = 6 , Title = "شاهین"},
                new Model(){Id = 7 , Title = "پراید"},
            });

        }
    }
}
