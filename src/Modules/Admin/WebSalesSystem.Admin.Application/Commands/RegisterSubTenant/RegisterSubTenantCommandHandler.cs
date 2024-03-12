using WebSalesSystem.Shared.Domain.Tenancy;
using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.SubTenantAggregate;

namespace WebSalesSystem.Admin.Application.Commands.RegisterSubTenant;
public class RegisterSubTenantCommandHandler(IUnitOfWork<AdminDbContext> unitOfWork, ILogger<RegisterSubTenantCommandHandler> logger, IMapper mapper, ITenantAccessor tenantAccessor) : IRequestHandler<RegisterSubTenantCommand, ErrorOr<SubTenantDTO>>
{
    private readonly ILogger<RegisterSubTenantCommandHandler> _logger = logger;
    private readonly IUnitOfWork<AdminDbContext> _unitOfWork = unitOfWork;
    private readonly ITenantAccessor _tenantAccessor = tenantAccessor;
    private readonly IMapper _mapper = mapper;


    public async Task<ErrorOr<SubTenantDTO>> Handle(RegisterSubTenantCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Solicitud de registro realizada para el sub cliente '{SubTenant}'", request.Name);

        #region Valida que el sub cliente ya está registrado con el correo electronico
        if ((await _unitOfWork.GetRepository<SubTenant>().GetByQueryAsync(x => x.Name == request.Name && x.Email == request.Email && x.TenantId == _tenantAccessor.Tenant!.Id, cancellationToken: cancellationToken)).FirstOrDefault() is SubTenant subTenant)
        {

            _logger.LogInformation("Solicitud de registro fallida para el sub cliente '{SubTenant}': El sub cliente ya se encuentra registrado.", request.Name);
            ErrorOr<SubTenantDTO> errorResult = ErrorOr<SubTenantDTO>.From([Error.Conflict("Error", AppValidations.ERROR_DUPLICATERECORD)]);
            //await _idempotencyService.CreateRequestAsync(errorResult, cancellationToken);

            return errorResult;
        }
        #endregion

        Tenant? tenant = (await _unitOfWork.GetRepository<Tenant>().GetByQueryAsync(x => x.Id == _tenantAccessor.Tenant!.Id, asTracking: true, cancellationToken: cancellationToken)).FirstOrDefault();
        SubTenant subTenantToRegister = new(request.Name, request.Email, request.Description, tenant!);

        _ = await _unitOfWork.GetRepository<SubTenant>().InsertAsync(subTenantToRegister, cancellationToken);
        _ = await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Registro realizado para el sub cliente '{SubTenant}'", request.Name);
        return ErrorOrFactory.From(_mapper.Map<SubTenantDTO>(subTenantToRegister));
    }
}
