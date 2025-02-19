import { Component,inject } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IClientModel } from '../../models/client.model';
import { ClientService } from '../../services/client.service';
import { ClientModalComponent } from './client-modal/client-modal.component';
import { clientGridCfg, IGridModel } from '../../models/grid.model';
import { GridComponent } from '../../components/grid/grid.component';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { BaseCrudComponent } from '../../components/base-crud/base.component';

@Component({
  selector: 'app-client',
  imports: [CommonModule, ReactiveFormsModule, ClientModalComponent, GridComponent, ConfirmDialogComponent],
  templateUrl: '../../components/base-crud/base.component.html'
})

export class ClientComponent extends BaseCrudComponent<IClientModel> {
  modalComponent = ClientModalComponent;
  constructor() {
    super(inject(ClientService), clientGridCfg);
  }
}



