import { Validator } from "fluentvalidation-ts";
import { TenantModel } from "../../models/tenant-model";
import { GenderType, ValidationMessages } from "../validation-messages";

export class TenantValidator extends Validator<TenantModel> {
  constructor() {
    super();

    let name: string = $localize`:@@tenant_name:`;
    let email: string = $localize`:@@tenant_email:`;
    let description: string = $localize`:@@tenant_description:`;
    let storageName: string = $localize`:@@tenant_storageName:`;

      this.ruleFor('name')
          .notNull().withMessage(ValidationMessages.required())
          .notEmpty().withMessage(ValidationMessages.required())
          .maxLength(50).withMessage(ValidationMessages.stringMaxLength(name, GenderType.male, 50));

      this.ruleFor('email')
          .notNull().withMessage(ValidationMessages.required())
          .notEmpty().withMessage(ValidationMessages.required())
          .emailAddress().withMessage(ValidationMessages.invalidEmail())
          .maxLength(50).withMessage(ValidationMessages.stringMaxLength(email, GenderType.male, 50));
      
      this.ruleFor('description')
          .notNull().withMessage(ValidationMessages.required())
          .notEmpty().withMessage(ValidationMessages.required())
          .maxLength(255).withMessage(ValidationMessages.stringMaxLength(description, GenderType.female, 255));
      
      this.ruleFor('storageName')
          .notNull().withMessage(ValidationMessages.required())
          .notEmpty().withMessage(ValidationMessages.required())
          .maxLength(50).withMessage(ValidationMessages.stringMaxLength(storageName, GenderType.male, 50));
  }
}