import { BreakpointObserver } from '@angular/cdk/layout';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { StepperOrientation } from '@angular/material/stepper';
import { Observable, map } from 'rxjs';
import { TenantComponent } from '../tenant/tenant.component';
import { SubtenantComponent } from '../subtenant/subtenant.component';
import { UserComponent } from '../user/user.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements AfterViewInit {
  stepperOrientation: Observable<StepperOrientation>;

  @ViewChild(TenantComponent) stepTenantComponent!: TenantComponent;
  @ViewChild(SubtenantComponent) stepSubtenantComponent!: SubtenantComponent;
  @ViewChild(UserComponent) stepUserComponent!: UserComponent;

  stepTenant!: AbstractControl;
  stepSubtenant!: AbstractControl;
  stepUser!: AbstractControl;

  constructor(_breakpointObserver: BreakpointObserver) { 
    this.stepperOrientation = _breakpointObserver.observe('(min-width: 767px)')
      .pipe(map(({ matches }) => (matches ? 'horizontal' : 'vertical')));
  }

  ngAfterViewInit(): void {
    this.stepTenant = this.stepTenantComponent.tenantRegisterForm;
    this.stepSubtenant = this.stepSubtenantComponent.subtenantRegisterForm;
    this.stepUser = this.stepUserComponent.userRegisterForm;
  }
}
