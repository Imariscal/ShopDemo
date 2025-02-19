import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  imports: [CommonModule],
  styleUrls: ['./confirm-dialog.component.css']
})
export class ConfirmDialogComponent {
  @Input() title: string = 'Confirmación';
  @Input() message: string = '¿Estás seguro de continuar?';
  @Input() isOpen: boolean = false;

  @Output() onConfirm = new EventEmitter<void>();
  @Output() onClose = new EventEmitter<void>();

  confirm() {
    this.onConfirm.emit();
    this.close();
  }

  close() {
    this.onClose.emit();
  }
}
