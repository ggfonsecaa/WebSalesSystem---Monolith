import { Validator } from "fluentvalidation-ts";
import { SubtenantModel } from "../../models/subtenant.model";
import { GenderType, ValidationMessages } from "../validation-messages";

export class SubtenantValidator extends Validator<SubtenantModel> {
  constructor() {
    super();

    let identificationType: string = $localize`:@@subtenant_identificationType:`;
    let identificationNumber: string = $localize`:@@subtenant_identificationNumber:`;
    let name: string = $localize`:@@subtenant_name:`;
    let email: string = $localize`:@@subtenant_email:`;
    let description: string = $localize`:@@subtenant_description:`;

      this.ruleFor('identificationType')
          .notNull().withMessage(ValidationMessages.required());
      
      this.ruleFor('identificationNumber')
          .notNull().withMessage(ValidationMessages.required())
          .notEmpty().withMessage(ValidationMessages.required())
          .maxLength(30).withMessage(ValidationMessages.stringMaxLength(identificationNumber, GenderType.male, 30));
      
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
  }
}