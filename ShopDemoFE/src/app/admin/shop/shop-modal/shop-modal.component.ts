import { Component, EventEmitter, Inject, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { shopValidationMessages } from '../../../shared/validations/form.validations';
import { IShop } from '../../../models/shop.model';

@Component({
  selector: 'app-shop-modal',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './shop-modal.component.html',
  styleUrls: ['./shop-modal.component.css']
})
export class ShopModalComponent implements OnChanges {
  shopForm: FormGroup;
  private originalShop!: IShop;

  constructor(private fb: FormBuilder,
    @Inject('selectedItem') private shop: IShop | null,
    @Inject('modalClose') private closeModal: Function,
    @Inject('onSave') private saveShop: Function
  ) {
    this.originalShop = this.shop ? { ...this.shop } : { id: '', name: '', address: '' };
    this.shopForm = this.createForm();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['shop'] && changes['shop'].currentValue) {
      this.shopForm.patchValue(this.shop ?? { id: null, name: '', address: '' });
    }
  }

  ngOnInit() {
    if (this.shop) {
      this.shopForm.patchValue(this.originalShop);
    }
  }


  createForm(): FormGroup {
    return this.fb.group({
      id: [null],
      name: ['', [Validators.required, Validators.minLength(3)]],
      address: ['', Validators.required]
    });
  }

  save() {
    if (this.shopForm.valid) {
      this.saveShop(this.shopForm.value as IShop);
    }
  }

  getErrorMessage(controlName: string): string | null {
    const control = this.shopForm.get(controlName);
    if (control && control.invalid && (control.dirty || control.touched)) {
      const errors = control.errors;
      if (errors) {
        const errorKey = Object.keys(errors)[0];
        return shopValidationMessages[controlName][errorKey];
      }
    }
    return null;
  }

  cancel() {
    this.closeModal();
  }
}
