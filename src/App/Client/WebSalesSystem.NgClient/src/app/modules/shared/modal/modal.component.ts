import { Component } from '@angular/core';
import {Dialog, DialogRef} from '@angular/cdk/dialog';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
  constructor(public dialogRef: DialogRef) {}
}
