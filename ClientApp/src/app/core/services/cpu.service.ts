import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  CpuAddRequest,
  CpuGetCompatibleRequest,
  CpuGetResponse,
} from '../models/cpu.model';

@Injectable({
  providedIn: 'root',
})
export class CpuService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<CpuGetResponse> {
    return this.http.get<CpuGetResponse>(`${this.url}/Cpu/GetAll`);
  }

  getCompatible(body: CpuGetCompatibleRequest): Observable<CpuGetResponse> {
    return this.http.post<CpuGetResponse>(
      `${this.url}/Cpu/GetAllCompatible`,
      body
    );
  }

  add(body: CpuAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/Cpu/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/Cpu/Delete`, {
      params: queryParams,
    });
  }
}
