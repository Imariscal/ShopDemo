import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { IClientModel } from '../models/client.model';

@Injectable({
    providedIn: 'root'
})
export class ClientService extends BaseService<IClientModel> {
    
    constructor(protected override http: HttpClient) {
        super(http);
        this.endPoint = 'api/v1/client';
    }
}
