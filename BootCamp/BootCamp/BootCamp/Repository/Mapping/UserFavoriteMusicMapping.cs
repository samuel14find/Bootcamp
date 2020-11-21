using BootCamp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Repository.Mapping
{
    public class UserFavoriteMusicMapping : IEntityTypeConfiguration<UserFavoritMusic>
    {
        public void Configure(EntityTypeBuilder<UserFavoritMusic> builder)
        {
            builder.ToTable("UserFavoritMusic");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.MusicId);

            // Aqui vou fazer o mapeamento para as músicas. Só vou ter uma música favorita
            builder.HasOne(x => x.Music)
                .WithOne()
                .HasForeignKey<UserFavoritMusic>(x => x.MusicId);
        }
    }
}
