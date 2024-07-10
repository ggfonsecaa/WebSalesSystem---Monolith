import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { Validators, FormControl, FormBuilder } from '@angular/forms';
import { ValidationErrors } from 'fluentvalidation-ts';
import { UserModel } from '../../../models/user.model';
import { UserValidator } from '../../../validators/user/user.validator';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  userRegisterForm = this._formBuilder.group({
      userName: [ '', { validators: [Validators.required, Validators.maxLength(50)], nonNullable: true }],
      email: ['', { validators: [Validators.required, Validators.email, Validators.maxLength(50)], nonNullable: true }],
      password: ['', { validators: [Validators.required, Validators.maxLength(20)], nonNullable: true }],
      passwordConfirmation: [ '', { validators: [Validators.required, Validators.maxLength(20)], nonNullable: true }], 
    });

  get userName(): FormControl { return this.userRegisterForm.get('userName') as FormControl };
  get email(): FormControl { return this.userRegisterForm.get('email') as FormControl };
  get password(): FormControl { return this.userRegisterForm.get('password') as FormControl };
  get passwordConfirmation(): FormControl { return this.userRegisterForm.get('passwordConfirmation') as FormControl };
  
  hidePassword = true;
  hideConfirmation = true;

  constructor(private _formBuilder: FormBuilder, private _userValidator: UserValidator) {
    this.passwordConfirmation.valueChanges.subscribe((value) => 
    { 
      if (value != this.password.value) {
        
      }
    });
  }

  validate(): ValidationErrors<UserModel> {
    return this._userValidator.validate(Object.assign(new UserModel(), this.userRegisterForm.value));
  }
}
