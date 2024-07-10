using WebSalesSystem.Shared.Infraestructure.Extensions;

namespace WebSalesSystem.Admin.API.Mappings;
internal class TenantMappingProfile : Profile
{
    public TenantMappingProfile()
    {
        _ = CreateMap<RegisterTenantCommand, RegisterTenantRequest>().ReverseMap()
                .ForMember(destination => 
                    destination.StorageType, origin =>
                        origin.MapFrom(x => Enumeration.FromId<StorageType>(x.StorageType)))
                .ForMember(destination =>       
                    destination.DbProvider, origin =>
                        origin.MapFrom(x => Enumeration.FromId<DbProvider>(x.DbProvider)));

        _ = CreateMap<TenantDTO, Tenant>().ReverseMap()
                .ForMember(destination =>
                    destination.Id, origin => 
                        origin.MapFrom(x => x.Id.ToHashId()))
                .ForMember(destination =>
                    destination.StorageType, origin =>
                        origin.MapFrom(x => x.Configuration.StorageType.Id))
                //.ForMember(destination =>
                //    destination.DbProvider, origin =>
                //        origin.MapFrom(x => x.Configuration.DbProvider.Id))
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