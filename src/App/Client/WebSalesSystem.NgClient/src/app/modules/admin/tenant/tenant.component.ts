import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ValidationErrors } from 'fluentvalidation-ts';
import { TenantModel } from '../../../models/tenant-model';
import { TenantValidator } from '../../../validators/tenant/tenant.validator';
import { Dialog } from '@angular/cdk/dialog';
import { ModalComponent } from '../../shared/modal/modal.component';

@Component({
  selector: 'app-tenant',
  templateUrl: './tenant.component.html',
  styleUrl: './tenant.component.css'
})
export class TenantComponent {
  tenantRegisterForm = this._formBuilder.group({
    name: [ '', { validators: [Validators.required, Validators.maxLength(50)], nonNullable: true }],
    email: [ '', { validators: [Validators.required, Validators.email, Validators.maxLength(50)], nonNullable: true }],
    description: [ '', { validators: [Validators.required, Validators.maxLength(255)], nonNullable: true }],
    storageType: [ '1' , { validators: [Validators.required], nonNullable: true }],
    dbProvider: [ '1' , { validators: [Validators.required], nonNullable: true }],
    storageName: [{ value: '', disabled: true }, Validators.maxLength(30)],
    useSubTenants: [ false, { nonNullable: true }],
    allowExternalRegister: [ false, { nonNullable: true }],
    useEmailConfirmation: [ false, { nonNullable: true }]
  });

  get name(): FormControl { return this.tenantRegisterForm.get('name') as FormControl };
  get email(): FormControl { return this.tenantRegisterForm.get('email') as FormControl };
  get description(): FormControl { return this.tenantRegisterForm.get('description') as FormControl };
  get storageType(): FormControl { return this.tenantRegisterForm.get('storageType') as FormControl };
  get dbProvider(): FormControl { return this.tenantRegisterForm.get('dbProvider') as FormControl };
  get storageName(): FormControl { return this.tenantRegisterForm.get('storageName') as FormControl };
  get useSubTenants(): FormControl { return this.tenantRegisterForm.get('useSubTenants') as FormControl };
  get allowExternalRegister(): FormControl { return this.tenantRegisterForm.get('allowExternalRegister') as FormControl };
  get useEmailConfirmation(): FormControl { return this.tenantRegisterForm.get('useEmailConfirmation') as FormControl; };
  

  constructor(private _formBuilder: FormBuilder, private _tenantValidator: TenantValidator, private dialog: Dialog) {
    this.storageType.valueChanges.subscribe((value) => 
    { 
      if (value != 1) {
        this.storageName.enable();
      } else { 
        this.storageName.disable();
        this.storageName.setValue('');
      }
    });
  }

  validate(): ValidationErrors<TenantModel> {
    return this._tenantValidator.validate(Object.assign(new TenantModel(), this.tenantRegisterForm.value));
  }

  openDialog(): void {
    this.dialog.open<string>(ModalComponent, { disableClose: true });
  }
}