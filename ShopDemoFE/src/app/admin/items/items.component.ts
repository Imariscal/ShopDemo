import { Component, inject } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; 
import { itemGridCfg } from '../../models/grid.model';
import { GridComponent } from '../../components/grid/grid.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { ItemModalComponent } from './item-modal/item-modal.component';
import { IItem } from '../../models/Item.model';
import { ItemService } from '../../services/item.service';
import { BaseCrudComponent } from '../../components/base-crud/base.component';

@Component({
  selector: 'app-items',
  imports: [CommonModule, ReactiveFormsModule, ItemModalComponent, GridComponent, ConfirmDialogComponent],
  templateUrl: '../../components/base-crud/base.component.html'
 
})

export class ItemsComponent extends BaseCrudComponent<IItem> {
  modalComponent = ItemModalComponent; 
  constructor() {
    super(inject(ItemService), itemGridCfg);
  }
}
