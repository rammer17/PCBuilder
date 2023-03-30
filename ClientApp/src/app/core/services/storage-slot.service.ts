import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  StorageSlotAddRequest,
  StorageSlotGetResponse,
} from '../models/storage-slot.model';

@Injectable({
  providedIn: 'root',
})
export class StorageSlotService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<StorageSlotGetResponse> {
    return this.http.get<StorageSlotGetResponse>(
      `${this.url}/StorageSlot/GetAll`
    );
  }
  add(body: StorageSlotAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/StorageSlot/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/StorageSlot/Delete`, {
      params: queryParams,
    });
  }
}
