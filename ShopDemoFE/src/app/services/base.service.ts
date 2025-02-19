import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService<T> {
  protected apiUrl: string = "http://localhost:5007/";
  protected endPoint : string = "";

  constructor(protected http: HttpClient) {}

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(`${this.apiUrl}${this.endPoint}`);
  }

  getById(id: number | string): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}${this.endPoint}/${id}`);
  }

  create(item: T): Observable<T> {
    return this.http.post<T>(`${this.apiUrl}${this.endPoint}`, item);
  }

  update(id: number | string, item: T): Observable<T> {
    return this.http.put<T>(`${this.apiUrl}${this.endPoint}/${id}`, item);
  }

  delete(id: number | string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}${this.endPoint}/${id}`);
  }
}
