import { Component, EventEmitter, Inject, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { IItem } from '../../../models/Item.model';
import { CommonModule } from '@angular/common';
import { validationMessages } from '../../../shared/validations/form.validations';

@Component({
  selector: 'app-item-modal',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './item-modal.component.html',
  styleUrls: ['./item-modal.component.css']
})
export class ItemModalComponent implements OnChanges, OnInit {

  private originalItem!: IItem;
  itemForm: FormGroup;

  constructor(private fb: FormBuilder,
    @Inject('selectedItem') private item: IItem | null,
    @Inject('modalClose') private closeModal: Function,
    @Inject('onSave') private saveShop: Function
  ) {
    this.originalItem = this.item ? { ...this.item } : { id: '' };
    this.itemForm = this.createForm();
  }

  ngOnInit() {
    if (this.itemForm) {
      this.itemForm.patchValue(this.originalItem);
    }
  }


  ngOnChanges(changes: SimpleChanges) {
    if (changes['item'] && changes['item'].currentValue) {
      this.itemForm.patchValue(this.item ?? { id: null, code: '', description: '', prize: 0, image: '', stock: 0 });
    }
  }

  createForm(): FormGroup {
    return this.fb.group({
      id: [null],
      code: ['', [Validators.required, Validators.minLength(3)]],
      description: ['', Validators.required],
      prize: [0, [Validators.required, Validators.min(1)]],
      image: ['', Validators.required],
      stock: [0, [Validators.required, Validators.min(1)]]
    });
  }

  save() {
    if (this.itemForm.valid) {
      this.saveShop(this.itemForm.value as IItem);
    }
  }

  getErrorMessage(controlName: string): string | null {
    const control = this.itemForm.get(controlName);
    if (control && control.invalid && (control.dirty || control.touched)) {
      const errors = control.errors;
      if (errors) {
        const errorKey = Object.keys(errors)[0];
        return validationMessages[controlName][errorKey];
      }
    }
    return null;
  }

  cancel() {
    this.closeModal();
  }
}
