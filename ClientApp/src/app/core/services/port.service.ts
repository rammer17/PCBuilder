import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PortAddRequest, PortGetResponse } from '../models/port.model';

@Injectable({
  providedIn: 'root',
})
export class PortService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<PortGetResponse> {
    return this.http.get<PortGetResponse>(`${this.url}/Port/GetAll`);
  }
  add(body: PortAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/Port/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/Port/Delete`, {
      params: queryParams,
    });
  }
}
