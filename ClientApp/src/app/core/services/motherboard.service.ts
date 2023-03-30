import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  MotherboardAddRequest,
  MotherboardGetCompatibleRequest,
  MotherboardGetResponse,
} from '../models/motherboard.model';

@Injectable({
  providedIn: 'root',
})
export class MotherboardService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<MotherboardGetResponse> {
    return this.http.get<MotherboardGetResponse>(
      `${this.url}/Motherboard/GetAll`
    );
  }

  getCompatible(
    body: MotherboardGetCompatibleRequest
  ): Observable<MotherboardGetResponse> {
    return this.http.post<MotherboardGetResponse>(
      `${this.url}/Cpu/GetAllCompatible`,
      body
    );
  }

  add(body: MotherboardAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/Motherboard/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/Motherboard/Delete`, {
      params: queryParams,
    });
  }
}
