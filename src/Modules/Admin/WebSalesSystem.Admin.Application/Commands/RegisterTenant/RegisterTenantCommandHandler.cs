namespace WebSalesSystem.Admin.Application.Commands.RegisterTenant;
public class RegisterTenantCommandHandler(IUnitOfWork<AdminDbContext> unitOfWork, ILogger<RegisterTenantCommandHandler> logger, IMapper mapper, IFeatureManager featureManager, IServiceProvider serviceProvider) : IRequestHandler<RegisterTenantCommand, ErrorOr<TenantDTO>>
{
    private readonly ILogger<RegisterTenantCommandHandler> _logger = logger;
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IFeatureManager _featureManager = featureManager;
    private readonly IUnitOfWork<AdminDbContext> _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;


    public async Task<ErrorOr<TenantDTO>> Handle(RegisterTenantCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Solicitud de registro realizada para el cliente '{Tenant}'", request.Name);

        var x = !await _featureManager.IsEnabledAsync("WeatherForecast", new FeatureFilterContext { Module = "Admin" });

        #region Valida que el cliente ya está registrado con el correo electronico
        if ((await _unitOfWork.GetRepository<Tenant>().GetByQueryAsync(x => x.Name == request.Name && x.Email == request.Email, cancellationToken: cancellationToken)).FirstOrDefault() is Tenant tenant)
        {

            _logger.LogInformation("Solicitud de registro fallida para el cliente '{Tenant}': El cliente ya se encuentra registrado.", request.Name);
            ErrorOr<TenantDTO> errorResult = ErrorOr<TenantDTO>.From([Error.Conflict("Error", "Duplicado")]);
            //await _idempotencyService.CreateRequestAsync(errorResult, cancellationToken);

            return errorResult;
        }
        #endregion

        Tenant tenantToRegister = new(request.Name, request.Email, request.Description, request.StorageType, request.StorageName, request.UseSubTenants, request.AllowExternalRegister, request.UseEmailConfirmation);

        _ = await _unitOfWork.GetRepository<Tenant>().InsertAsync(tenantToRegister, cancellationToken);
        _ = await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Registro realizado para el cliente '{Tenant}'", request.Name);
        return ErrorOrFactory.From(_mapper.Map<TenantDTO>(tenantToRegister));
    }
}