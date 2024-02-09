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
        _ = builder.Property(x => x.Id).IsRequired().UseIdentityColumn().ValueGeneratedOnAdd().HasColumnOrder(1);
        _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(TenantConstants.NAME_LENGHT).HasColumnOrder(2);
        _ = builder.Property(x => x.Email).IsRequired().HasMaxLength(TenantConstants.EMAIL_LENGTH).HasColumnOrder(3);
        _ = builder.Property(x => x.Description).IsRequired().HasMaxLength(TenantConstants.DESCRIPTION_LENGHT).HasColumnOrder(4);
        _ = builder.Property(x => x.Identifier).IsRequired().HasColumnOrder(5);
        _ = builder.Property(x => x.IsActive).IsRequired().HasColumnOrder(6);
        _ = builder.Property(x => x.CreatedBy).IsRequired();
        _ = builder.Property(x => x.CreatedAt).IsRequired();
        _ = builder.Property(x => x.LastModifiedBy);
        _ = builder.Property(x => x.LastModifiedAt);
        _ = builder.Property(x => x.RowVersion).IsRequired().IsConcurrencyToken().IsRowVersion().ValueGeneratedOnAddOrUpdate();
        _ = builder.Ignore(x => x.Configuration);
        _ = builder.Ignore(x => x.DomainEvents);
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
            _ = c.Property(x => x.StorageType).HasColumnName("StorageType").IsRequired();
            _ = c.Property(x => x.StorageName).HasColumnName("StorageName").IsRequired().HasMaxLength(TenantConstants.STORAGENAME_LENGHT);
            _ = c.Property(x => x.UseSubTenants).HasColumnName("UseSubTenants");
            _ = c.Property(x => x.AllowExternalRegister).HasColumnName("AllowExternalRegister");
            _ = c.Property(x => x.UseEmailConfirmation).HasColumnName("UseEmailConfirmation");
        });
        #endregion

        #region Definición de datos iniciales
        #endregion;
    }
}