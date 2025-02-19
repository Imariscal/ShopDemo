 import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';   
import { IItem } from '../models/Item.model';

@Injectable({
  providedIn: 'root'
})
export class ItemService extends BaseService<IItem> {
  constructor(protected override http: HttpClient) {
    super(http);
    this.endPoint =  'api/v1/item';
  }
}
