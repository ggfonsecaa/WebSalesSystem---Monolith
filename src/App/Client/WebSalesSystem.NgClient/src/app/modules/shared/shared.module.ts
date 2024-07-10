import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { ModalComponent } from './modal/modal.component';
import { DialogModule } from '@angular/cdk/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';


@NgModule({
  declarations: [
    ModalComponent
  ],
  imports: [
    CommonModule,
    DialogModule,
    MatProgressSpinnerModule,
    SharedRoutingModule
  ],
  exports: [
    ModalComponent
  ],
})
export class SharedModule { }
