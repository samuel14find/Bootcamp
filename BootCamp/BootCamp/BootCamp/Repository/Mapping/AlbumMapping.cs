using BootCamp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Repository.Mapping
{
    /// <summary>
    /// Observe a propriedade: 
    /// builder.HasMany(x => x.Musics).WithOne(x => x.Album).OnDelete(DeleteBehavior.Cascade);
    /// Aqui indico que um album tem várias músicas. E estou indicando que se deletar um album ,
    /// as músicas também serão deletadas. E as outras propriedades são auto descritivas. 
    /// </summary>
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albuns");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Band).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Backdrop).IsRequired();

            builder.HasMany(x => x.Musics).WithOne(x => x.Album).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
