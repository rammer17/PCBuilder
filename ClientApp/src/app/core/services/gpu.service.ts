import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  GpuAddRequest,
  GpuGetCompatibleRequest,
  GpuGetResponse,
} from '../models/gpu.model';

@Injectable({
  providedIn: 'root',
})
export class GpuService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<GpuGetResponse> {
    return this.http.get<GpuGetResponse>(`${this.url}/Gpu/GetAll`);
  }

  getCompatible(body: GpuGetCompatibleRequest): Observable<GpuGetResponse> {
    return this.http.post<GpuGetResponse>(
      `${this.url}/Gpu/GetAllCompatible`,
      body
    );
  }

  add(body: GpuAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/Gpu/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/Gpu/Delete`, {
      params: queryParams,
    });
  }
}
