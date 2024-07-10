import { Validator } from "fluentvalidation-ts";
import { UserModel } from "../../models/user.model";
import { GenderType, ValidationMessages } from "../validation-messages";

export class UserValidator extends Validator<UserModel> {
  constructor() {
    super();

    let userName: string = $localize`:@@user_username:`;
    let email: string = $localize`:@@user_email:`;
    let password: string = $localize`:@@user_password:`;
    let passwordConfirmation: string = $localize`:@@user_passwordConfirmation:`;
      
    this.ruleFor('userName')
      .notNull().withMessage(ValidationMessages.required())
      .notEmpty().withMessage(ValidationMessages.required())
      .maxLength(50).withMessage(ValidationMessages.stringMaxLength(userName, GenderType.male, 50));

    this.ruleFor('email')
      .notNull().withMessage(ValidationMessages.required())
      .notEmpty().withMessage(ValidationMessages.required())
      .emailAddress().withMessage(ValidationMessages.invalidEmail())
      .maxLength(50).withMessage(ValidationMessages.stringMaxLength(email, GenderType.male, 50));
      
    this.ruleFor('password')
      .notNull().withMessage(ValidationMessages.required())
      .notEmpty().withMessage(ValidationMessages.required())
      .maxLength(20).withMessage(ValidationMessages.stringMaxLength(password, GenderType.female, 20));
      
    this.ruleFor('passwordConfirmation')
      .must((passwordConfirmation, formModel) => passwordConfirmation === formModel.password).withMessage('Error')
      .maxLength(20).withMessage(ValidationMessages.stringMaxLength(password, GenderType.female, 20));
  }
}