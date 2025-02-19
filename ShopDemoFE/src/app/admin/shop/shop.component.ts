import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { ReactiveFormsModule } from '@angular/forms'; 
import { shopGridCfg } from '../../models/grid.model';
import { GridComponent } from '../../components/grid/grid.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { ShopModalComponent } from './shop-modal/shop-modal.component';
import { IShop } from '../../models/shop.model';
import { ShopService } from '../../services/shop.service';
import { BaseCrudComponent } from '../../components/base-crud/base.component';

@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ShopModalComponent, GridComponent, ConfirmDialogComponent],
  templateUrl: '../../components/base-crud/base.component.html',
})
export class ShopComponent extends BaseCrudComponent<IShop> {
  modalComponent = ShopModalComponent; 
  constructor() {
    super(inject(ShopService), shopGridCfg);
  }
}
