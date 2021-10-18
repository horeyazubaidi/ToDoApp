using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoApp.Models.Configurations
{
    public class ToDoConfigurations : IEntityTypeConfiguration<ToDo>
    {
        public ToDoConfigurations()
        {
        }

        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(prop => prop.id);

            builder.Property(prop => prop.createdOn)
                .HasColumnType("TIMESTAMP(0)")
                .IsRequired();

            builder.Property(prop => prop.body)
                .HasMaxLength(1000);
                
            builder.Property(prop => prop.name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(prop => prop.status)
                .IsRequired();

        }
    }
}
