using WebSalesSystem.Shared.Domain.Globalization.Resources.Strings;

namespace WebSalesSystem.Admin.Application.Commands.RegisterTenant;
public class RegisterTenantCommandValidator : AbstractValidator<RegisterTenantCommand>
{
    public RegisterTenantCommandValidator()
    {
        _ = RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(AppValidations.ERROR_REQUIRED)
            .NotEmpty().WithMessage(AppValidations.ERROR_EMPTY)
            .MaximumLength(TenantConstants.NAME_LENGHT).WithMessage(AppValidations.ERROR_NUMBERMAXLENGHT)
            .WithName(AppStrings.TENANT_NAME);

        _ = RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(AppValidations.ERROR_REQUIRED)
            .NotEmpty().WithMessage(AppValidations.ERROR_EMPTY)
            .EmailAddress().WithMessage(AppValidations.ERROR_INVALIDEMAIL)
            .MaximumLength(TenantConstants.EMAIL_LENGTH).WithMessage(AppValidations.ERROR_STRINGMAXLENGHT)
            .WithName(AppStrings.TENANT_EMAIL);

        _ = RuleFor(x => x.Description).Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(AppValidations.ERROR_REQUIRED)
            .NotEmpty().WithMessage(AppValidations.ERROR_EMPTY)
            .MaximumLength(TenantConstants.DESCRIPTION_LENGHT).WithMessage(AppValidations.ERROR_STRINGMAXLENGHT)
            .WithName(AppStrings.TENANT_DESCRIPTION);

        _ = RuleFor(x => x.StorageType).Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(AppValidations.ERROR_INVALIDOPTION)
            .Must(x => x.Equals(Enumeration.FromId<StorageType>(x.Id))).WithMessage(AppValidations.ERROR_INVALIDOPTION)
            .WithName(AppStrings.TENANT_STORAGETYPE);

        _ = RuleFor(x => x.StorageName).Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(AppValidations.ERROR_REQUIRED)
            .NotEmpty().WithMessage(AppValidations.ERROR_EMPTY)
            .MaximumLength(TenantConstants.STORAGENAME_LENGHT).WithMessage(AppValidations.ERROR_STRINGMAXLENGHT)
            .WithName(AppStrings.TENANT_STORAGENAME);
    }
}
