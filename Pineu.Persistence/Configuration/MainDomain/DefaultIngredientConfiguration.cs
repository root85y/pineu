using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pineu.Domain.Entities.MainDomain;
using Pineu.Persistence.Constants;

namespace Pineu.Persistence.Configuration.MainDomain {
    internal class DefaultIngredientConfiguration : IEntityTypeConfiguration<DefaultIngredient> {
        public void Configure(EntityTypeBuilder<DefaultIngredient> builder) {
            builder.ToTable(TableNames.DefaultIngredient);
        }
    }
}
