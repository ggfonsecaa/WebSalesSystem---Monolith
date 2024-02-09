namespace WebSalesSystem.Admin.Application.Commands.RegisterTenant;
public class RegisterTenantCommandValidator : AbstractValidator<RegisterTenantCommand>
{
    public RegisterTenantCommandValidator()
    {
        RuleFor(x => x.Name).Cascade(CascadeMode.Continue)
            .NotNull().WithMessage("Nulo")
            .NotEmpty().WithMessage("Vacio")
            .MaximumLength(TenantConstants.NAME_LENGHT).WithMessage("Muy largo")
            .WithName("Nombre");

        //RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
        //    .NotNull().WithMessage(AppValidations.REQUIRED)
        //    .NotEmpty().WithMessage(AppValidations.NOT_EMPTY)
        //    .EmailAddress().WithMessage(AppValidations.INVALID_EMAIL)
        //    .MaximumLength(TenantConstants.EMAIL_LENGTH).WithMessage(AppValidations.STRING_MAXLENGHT)
        //    .WithName(AdminStrings.TENANT_EMAIL);

        //RuleFor(x => x.Description).Cascade(CascadeMode.Stop)
        //    .NotNull().WithMessage(AppValidations.REQUIRED)
        //    .NotEmpty().WithMessage(AppValidations.NOT_EMPTY)
        //    .MaximumLength(TenantConstants.DESCRIPTION_LENGHT).WithMessage(AppValidations.STRING_MAXLENGHT)
        //    .WithName(AdminStrings.TENANT_DESCRIPTION);

        //RuleFor(x => x.StorageType).Cascade(CascadeMode.Stop)
        //    .IsInEnum().WithMessage(AppValidations.OPTION_INVALID)
        //    .WithName(AdminStrings.TENANT_STORAGETYPE);

        //RuleFor(x => x.StorageName).Cascade(CascadeMode.Stop)
        //    .NotNull().WithMessage(AppValidations.REQUIRED)
        //    .NotEmpty().WithMessage(AppValidations.NOT_EMPTY)
        //    .MaximumLength(TenantConstants.STORAGENAME_LENGHT).WithMessage(AppValidations.STRING_MAXLENGHT)
        //    .WithName(AdminStrings.TENANT_STORAGENAME);
    }
}
