import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { TenantComponent } from './tenant/tenant.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { TenantValidator } from '../../validators/tenant/tenant.validator';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SharedModule } from '../shared/shared.module';
import { MatStepperModule } from '@angular/material/stepper';
import { RegisterComponent } from './register/register.component';
import { SubtenantComponent } from './subtenant/subtenant.component';
import { SubtenantValidator } from '../../validators/subtenant/subtenant.validator';
import { UserComponent } from './user/user.component';
import { UserValidator } from '../../validators/user/user.validator';
import { SummaryComponent } from './summary/summary.component';


@NgModule({
  declarations: [
    TenantComponent,
    RegisterComponent,
    SubtenantComponent,
    UserComponent,
    SummaryComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatRadioModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatTooltipModule,
    MatProgressSpinnerModule,
    MatIconModule,
    MatStepperModule,
    SharedModule
  ],
  exports: [
    TenantComponent,
    RegisterComponent
  ],
  providers: [ TenantValidator, SubtenantValidator, UserValidator ]
})
export class AdminModule { 

}