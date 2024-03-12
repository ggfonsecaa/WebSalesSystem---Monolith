namespace WebSalesSystem.Admin.Infraestructure.EntityConfigurations;
public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public TenantConfiguration() { }

    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        #region Definicion de nombre de tabla
        _ = builder.ToTable("Tenants");
        #endregion

        #region Definición de campos y tipos de datos
        _ = builder.Property(x => x.Id).IsRequired().UseIdentityColumn().ValueGeneratedOnAdd();
        _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(TenantConstants.NAME_LENGHT);
        _ = builder.Property(x => x.Email).IsRequired().HasMaxLength(TenantConstants.EMAIL_LENGTH);
        _ = builder.Property(x => x.Description).IsRequired().HasMaxLength(TenantConstants.DESCRIPTION_LENGHT);
        _ = builder.Property(x => x.Identifier).IsRequired();
        _ = builder.Property(x => x.IsActive).IsRequired();
        _ = builder.Property(x => x.CreatedBy).IsRequired();
        _ = builder.Property(x => x.CreatedAt).IsRequired();
        _ = builder.Property(x => x.LastModifiedBy);
        _ = builder.Property(x => x.LastModifiedAt);
        _ = builder.Property(x => x.RowVersion).IsRequired().IsConcurrencyToken().IsRowVersion().ValueGeneratedOnAddOrUpdate();
        _ = builder.Ignore(x => x.Configuration);
        _ = builder.Ignore(x => x.DomainEvents);
        //_ = builder.Ignore(x => x.SubTenants);
        #endregion

        #region Definición de índices
        _ = builder.HasIndex(x => new { x.Name, x.Email }).IsUnique();
        #endregion

        #region Definición de llaves primarias
        _ = builder.HasKey(x => x.Id);
        #endregion

        #region Definición de value objects
        _ = builder.OwnsOne(x => x.Configuration, c =>
        {
            //c.ToTable("Configuration");
            _ = c.Property(x => x.StorageType).HasColumnName("StorageType").IsRequired().HasConversion<StorageTypeConverter>();
            _ = c.Property(x => x.DbProvider).HasColumnName("DbProvider").IsRequired().HasConversion<DbProviderConverter>();
            _ = c.Property(x => x.StorageName).HasColumnName("StorageName").HasMaxLength(TenantConstants.STORAGENAME_LENGHT);
            _ = c.Property(x => x.UseSubTenants).HasColumnName("UseSubTenants");
            _ = c.Property(x => x.AllowExternalRegister).HasColumnName("AllowExternalRegister");
            _ = c.Property(x => x.UseEmailConfirmation).HasColumnName("UseEmailConfirmation");
        });
        #endregion

        #region Definición de datos iniciales
        #endregion;
    }
}