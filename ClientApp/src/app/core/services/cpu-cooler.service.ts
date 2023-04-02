import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  CpuCoolerGetResponse,
  CpuCoolerAddRequest,
  CpuCoolerGetCompatibleRequest,
} from '../models/cpu-cooler.model';

@Injectable({
  providedIn: 'root',
})
@Injectable({
  providedIn: 'root',
})
export class CpuCoolerService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<CpuCoolerGetResponse[]> {
    return this.http.get<CpuCoolerGetResponse[]>(`${this.url}/CpuCooler/GetAll`);
  }

  getCompatible(
    body: CpuCoolerGetCompatibleRequest
  ): Observable<CpuCoolerGetResponse[]> {
    return this.http.post<CpuCoolerGetResponse[]>(
      `${this.url}/CpuCooler/GetCompatible`,
      body
    );
  }

  add(body: CpuCoolerAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/CpuCooler/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/CpuCooler/Delete`, {
      params: queryParams,
    });
  }
}
