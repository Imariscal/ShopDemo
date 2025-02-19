import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { IShop } from '../models/shop.model';

@Injectable({
    providedIn: 'root'
})
export class ShopService extends BaseService<IShop> {
    constructor(protected override http: HttpClient) {
        super(http);
        this.endPoint =  'api/v1/shopStore';
    }
}
