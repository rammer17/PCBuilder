import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  RamAddRequest,
  RamGetCompatibleRequest,
  RamGetResponse,
} from '../models/ram.model';

@Injectable({
  providedIn: 'root',
})
export class RamService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<RamGetResponse> {
    return this.http.get<RamGetResponse>(`${this.url}/Ram/GetAll`);
  }

  getCompatible(body: RamGetCompatibleRequest): Observable<RamGetResponse> {
    return this.http.post<RamGetResponse>(
      `${this.url}/Ram/GetAllCompatible`,
      body
    );
  }

  add(body: RamAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/Ram/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/Ram/Delete`, {
      params: queryParams,
    });
  }
}
