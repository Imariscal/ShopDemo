import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IGridModel } from '../../models/grid.model';

@Component({
  selector: 'app-grid',
  imports : [CommonModule],
    templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent {
  @Input() columns: IGridModel[] = [];  
  @Input() data: any[] = [];  

  @Output() edit = new EventEmitter<any>(); 
  @Output() delete = new EventEmitter<any>(); 

  onEdit(item: any) {
    this.edit.emit(item);
  }

  onDelete(id: any) {
    this.delete.emit(id);
  }
}
