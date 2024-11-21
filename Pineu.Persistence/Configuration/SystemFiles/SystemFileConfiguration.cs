namespace Pineu.Persistence.Configuration.SystemFiles;

public class SystemFileConfiguration : IEntityTypeConfiguration<SystemFile> {
    public void Configure(EntityTypeBuilder<SystemFile> builder) {
        builder.ToTable(TableNames.SystemFile);

        builder.HasData(new {
            Id = Guid.Parse("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
            FilePath = "",
            Url = "",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            IsRemoved = false
        });
    }
}