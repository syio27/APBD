using DoctorPatientAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorPatientAPI.EFConfigurations
{
    public class AppUserEntityTypeConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(e => e.IdUser);
            builder.Property(e => e.IdUser).ValueGeneratedNever();
            builder.Property(e => e.Login).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(300);
            builder.Property(e => e.RefreshToken).IsRequired();
            builder.Property(e => e.RefreshTokenExp).HasColumnType("datetime");
            builder.Property(e => e.Salt).IsRequired();
        }
    }
}
