import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  CaseAddRequest,
  CaseGetCompatibleRequest,
  CaseGetResponse,
} from '../models/case.model';

@Injectable({
  providedIn: 'root',
})
export class CaseService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<CaseGetResponse> {
    return this.http.get<CaseGetResponse>(`${this.url}/Case/GetAll`);
  }

  getCompatible(body: CaseGetCompatibleRequest): Observable<CaseGetResponse> {
    return this.http.post<CaseGetResponse>(
      `${this.url}/Case/GetAllCompatible`,
      body
    );
  }

  add(body: CaseAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/Case/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/Case/Delete`, {
      params: queryParams,
    });
  }
}
