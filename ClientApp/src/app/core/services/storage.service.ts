import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StorageAddRequest, StorageGetResponse } from '../models/storage.model';

@Injectable({
  providedIn: 'root',
})
export class StorageService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<StorageGetResponse[]> {
    return this.http.get<StorageGetResponse[]>(`${this.url}/Storage/GetAll`);
  }
  add(body: StorageAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/Storage/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/Storage/Delete`, {
      params: queryParams,
    });
  }
}
