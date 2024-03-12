namespace WebSalesSystem.Admin.Infraestructure.EntityConfigurations;
public class SubTenantConfiguration : IEntityTypeConfiguration<SubTenant>
{
    public SubTenantConfiguration() { }

    public void Configure(EntityTypeBuilder<SubTenant> builder)
    {
        #region Definicion de nombre de tabla
        _ = builder.ToTable("SubTenants");
        #endregion

        #region Definición de campos y tipos de datos
        _ = builder.Property(x => x.Id).IsRequired().UseIdentityColumn().ValueGeneratedOnAdd();
        _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(SubTenantConstants.NAME_LENGHT);
        _ = builder.Property(x => x.Email).IsRequired().HasMaxLength(SubTenantConstants.EMAIL_LENGTH);
        _ = builder.Property(x => x.Description).IsRequired().HasMaxLength(SubTenantConstants.DESCRIPTION_LENGHT);
        _ = builder.Property(x => x.IsActive).IsRequired();
        _ = builder.Property(x => x.TenantId).IsRequired();
        _ = builder.Property(x => x.CreatedBy).IsRequired();
        _ = builder.Property(x => x.CreatedAt).IsRequired();
        _ = builder.Property(x => x.LastModifiedBy);
        _ = builder.Property(x => x.LastModifiedAt);
        _ = builder.Property(x => x.RowVersion).IsRequired().IsConcurrencyToken().IsRowVersion().ValueGeneratedOnAddOrUpdate();
        _ = builder.Ignore(x => x.DomainEvents);
        _ = builder.Ignore(x => x.Tenant);
        #endregion

        #region Definición de índices
        _ = builder.HasIndex(x => new { x.Name, x.Email }).IsUnique();
        #endregion

        #region Definición de llaves primarias
        _ = builder.HasKey(x => x.Id);
        #endregion

        #region Definición de value objects
        #endregion

        #region Definicion de llaves foráneas
        _ = builder.HasOne(x => x.Tenant).WithMany(x => x.SubTenants).HasForeignKey(x => x.TenantId).OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Definición de datos iniciales
        #endregion;
    }
}