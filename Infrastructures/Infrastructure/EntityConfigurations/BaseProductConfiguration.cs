using ApplicationDomain.Entities;
using AspNetCore.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class BaseProductConfiguration : EntityConfigurationBase<BaseProduct>
    {
        public override void OnConfigure(EntityTypeBuilder<BaseProduct> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd(); 
        }
    }
}
