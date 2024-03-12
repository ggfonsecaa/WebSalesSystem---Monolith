using WebSalesSystem.Admin.Application.Commands.RegisterSubTenant;
using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.SubTenantAggregate;
using WebSalesSystem.Shared.Infraestructure.Extensions;

namespace WebSalesSystem.Admin.API.Mappings;
public class SubTenantMappingProfile : Profile
{
    public SubTenantMappingProfile()
    {
        _ = CreateMap<RegisterSubTenantCommand, RegisterSubTenantRequest>().ReverseMap();

        _ = CreateMap<TenantModel, Tenant>().ReverseMap()
                .ForMember(destination =>
                    destination.TenantId, origin =>
                        origin.MapFrom(x => x.Id.ToHashId()));

        _ = CreateMap<SubTenantDTO, SubTenant>().ReverseMap()
                .ForMember(destination =>
                    destination.Id, origin =>
                        origin.MapFrom(x => x.Id.ToHashId()));
    }
}