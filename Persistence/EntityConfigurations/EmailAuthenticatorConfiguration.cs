using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Application;

namespace Persistence.EntityConfigurations;

public class EmailAuthenticatorConfiguration : IEntityTypeConfiguration<EmailAuthenticator>
{
    public void Configure(EntityTypeBuilder<EmailAuthenticator> builder)
    {
        builder.ToTable("EmailAuthenticators").HasKey(ea => ea.Id);

        builder.Property(ea => ea.Id).HasColumnName("Id").IsRequired();
        builder.Property(ea => ea.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(ea => ea.ActivationKey).HasColumnName("ActivationKey");
        builder.Property(ea => ea.IsVerified).HasColumnName("IsVerified").IsRequired();
        builder.Property(oa => oa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oa => oa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oa => oa.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ea => !ea.DeletedDate.HasValue);

        builder.HasOne(ea => ea.User);
    }
}