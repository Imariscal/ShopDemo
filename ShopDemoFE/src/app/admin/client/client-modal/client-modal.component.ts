import { Component, EventEmitter, Inject, Input, OnChanges, OnInit, Output, signal, Signal, SimpleChanges } from '@angular/core';
import { IClientItem, IClientModel } from '../../../models/client.model';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { clientValidationMessages } from '../../../shared/validations/form.validations';
import { GridComponent } from '../../../components/grid/grid.component';
import { clientItemCfg } from '../../../models/grid.model';
import { ItemService } from '../../../services/item.service';
import { IItem } from '../../../models/Item.model';

@Component({
  selector: 'app-client-modal',
  imports: [ReactiveFormsModule, GridComponent, FormsModule],
  templateUrl: './client-modal.component.html',
  styleUrl: './client-modal.component.css'
})
export class ClientModalComponent implements OnChanges, OnInit {

  private originalClient!: IClientModel;
  clientForm: FormGroup;
  clientItems! : IClientItem[];
  gridColumns = clientItemCfg;
  items! : IItem[];
  selectedOption! : IItem;

  constructor(private fb: FormBuilder,
    private itemsService : ItemService,
    @Inject('selectedItem') private client: IClientModel | null,
    @Inject('modalClose') private closeModal: Function,
    @Inject('onSave') private saveClient: Function
  ) {
    this.originalClient = this.client ? { ...this.client } : { id: '', };
    this.clientForm = this.createForm();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['client'] && changes['client'].currentValue) {
      this.clientForm.patchValue(this.client ?? { id: null });
    }
  }

  createForm(): FormGroup {
    return this.fb.group({
      id: [null],
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      address: ['', Validators.required]
    });
  }


  save() {
    if (this.clientForm.valid) {
      this.saveClient(this.clientForm.value as IClientModel);
    }
  }

  ngOnInit() {

    this.itemsService.getAll()
      .subscribe( (data : any) => {
         this.items = data.payload;
         console.log(data)
      })

    if (this.clientForm) {
      this.clientForm.patchValue(this.originalClient);
    }
  }

  getErrorMessage(controlName: string): string | null {
      const control = this.clientForm.get(controlName);
      if (control && control.invalid && (control.dirty || control.touched)) {
        const errors = control.errors;
        if (errors) {
          const errorKey = Object.keys(errors)[0];
          return clientValidationMessages[controlName][errorKey];
        }
      }
      return null;
    }

  cancel() {
    this.closeModal();
  }

  getSelectedItem(item: IItem) {
    if (item) {
      // const itemVal: IClientItem = {
      //   ItemId: item.id,
      //   DateAdded: new Date(),  
      //   Item: item 
      // // };
   
      // if (this.client?.clientItem) {
      //   this.client.clientItem.push(itemVal);
      // } else {
      //   this.client = { clientItem: [itemVal] }; 
      // }
    }
  }
  
}
