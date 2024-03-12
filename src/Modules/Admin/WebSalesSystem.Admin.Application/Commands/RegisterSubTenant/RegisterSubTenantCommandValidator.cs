using WebSalesSystem.Shared.Domain.Globalization.Resources.Strings;
using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.SubTenantAggregate;

namespace WebSalesSystem.Admin.Application.Commands.RegisterSubTenant;
public class RegisterSubTenantCommandValidator : AbstractValidator<RegisterSubTenantCommand>
{
    public RegisterSubTenantCommandValidator()
    {
        _ = RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(AppValidations.ERROR_REQUIRED)
            .NotEmpty().WithMessage(AppValidations.ERROR_EMPTY)
            .MaximumLength(SubTenantConstants.NAME_LENGHT).WithMessage(AppValidations.ERROR_NUMBERMAXLENGHT)
            .WithName(AppStrings.SUBTENANT_NAME);

        _ = RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(AppValidations.ERROR_REQUIRED)
            .NotEmpty().WithMessage(AppValidations.ERROR_EMPTY)
            .EmailAddress().WithMessage(AppValidations.ERROR_INVALIDEMAIL)
            .MaximumLength(SubTenantConstants.EMAIL_LENGTH).WithMessage(AppValidations.ERROR_STRINGMAXLENGHT)
            .WithName(AppStrings.SUBTENANT_EMAIL);

        _ = RuleFor(x => x.Description).Cascade(CascadeMode.Stop)
            .NotNull().WithMessage(AppValidations.ERROR_REQUIRED)
            .NotEmpty().WithMessage(AppValidations.ERROR_EMPTY)
            .MaximumLength(SubTenantConstants.DESCRIPTION_LENGHT).WithMessage(AppValidations.ERROR_STRINGMAXLENGHT)
            .WithName(AppStrings.SUBTENANT_DESCRIPTION);
    }
}