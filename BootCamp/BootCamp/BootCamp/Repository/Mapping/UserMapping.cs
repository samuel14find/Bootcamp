using BootCamp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Repository.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User"); // Builder vai trabalhar com uma tabela chamada User
            builder.HasKey(x => x.Id); // Ela tem uma chave primária
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); // O valor da chave vai ser adicionado na hora da inserção
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200); // Email obrigatório e seu tamanho máximo é 200
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200); //..
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200); //..
            builder.Property(x => x.Photo).IsRequired().HasMaxLength(500); //.. 
            // Se eu deletar um usuário não faz sentido ter música favorita dele
            builder.HasMany(x => x.FavoritMusic)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
