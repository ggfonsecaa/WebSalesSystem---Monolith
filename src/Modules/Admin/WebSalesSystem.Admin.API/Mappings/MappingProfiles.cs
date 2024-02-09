namespace WebSalesSystem.Admin.API.Mappings;
internal class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        _ = CreateMap<RegisterTenantRequest, RegisterTenantCommand>().ReverseMap();

        _ = CreateMap<TenantDTO, Tenant>().ReverseMap()
                .ForMember(destination =>
                    destination.StorageType, origin =>
                        origin.MapFrom(x => x.Configuration.StorageType))
                .ForMember(destination =>
                    destination.StorageName, origin =>
                        origin.MapFrom(x => x.Configuration.StorageName))
                .ForMember(destination =>
                    destination.UseSubTenants, origin =>
                        origin.MapFrom(x => x.Configuration.UseSubTenants))
                .ForMember(destination =>
                    destination.AllowExternalRegister, origin =>
                        origin.MapFrom(x => x.Configuration.AllowExternalRegister))
                .ForMember(destination =>
                    destination.UseEmailConfirmation, origin =>
                        origin.MapFrom(x => x.Configuration.UseEmailConfirmation));
    }
}