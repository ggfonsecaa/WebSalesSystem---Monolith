import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { SubtenantValidator } from '../../../validators/subtenant/subtenant.validator';
import { SubtenantModel } from '../../../models/subtenant.model';
import { ValidationErrors } from 'fluentvalidation-ts';

@Component({
  selector: 'app-subtenant',
  templateUrl: './subtenant.component.html',
  styleUrl: './subtenant.component.css'
})
export class SubtenantComponent {
  subtenantRegisterForm = this._formBuilder.group({
    identificationType: ['1', { validators: [Validators.required], nonNullable: true }],
    identificationNumber: [ '', { validators: [Validators.required, Validators.maxLength(50)], nonNullable: true }],
    name: [ '', { validators: [Validators.required, Validators.maxLength(50)], nonNullable: true }],
    email: [ '', { validators: [Validators.required, Validators.email, Validators.maxLength(50)], nonNullable: true }],
    description: [ '', { validators: [Validators.required, Validators.maxLength(255)], nonNullable: true }],
    
  });

  get identificationType(): FormControl { return this.subtenantRegisterForm.get('identificationType') as FormControl; };
  get identificationNumber(): FormControl { return this.subtenantRegisterForm.get('identificationNumber') as FormControl };
  get name(): FormControl { return this.subtenantRegisterForm.get('name') as FormControl };
  get email(): FormControl { return this.subtenantRegisterForm.get('email') as FormControl };
  get description(): FormControl { return this.subtenantRegisterForm.get('description') as FormControl };
  

  constructor(private _formBuilder: FormBuilder, private _subtenantValidator: SubtenantValidator, private dialog: Dialog) {

  }

  validate(): ValidationErrors<SubtenantComponent> {
    return this._subtenantValidator.validate(Object.assign(new SubtenantModel(), this.subtenantRegisterForm.value));
  }
}
