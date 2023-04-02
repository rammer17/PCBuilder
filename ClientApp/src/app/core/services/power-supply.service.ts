import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  PowerSupplyAddRequest,
  PowerSupplyGetCompatibleRequest,
  PowerSupplyGetResponse,
} from '../models/power-supply.model';

@Injectable({
  providedIn: 'root',
})
export class PowerSupplyService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<PowerSupplyGetResponse[]> {
    return this.http.get<PowerSupplyGetResponse[]>(
      `${this.url}/PowerSupply/GetAll`
    );
  }

  getCompatible(
    body: PowerSupplyGetCompatibleRequest
  ): Observable<PowerSupplyGetResponse[]> {
    return this.http.post<PowerSupplyGetResponse[]>(
      `${this.url}/PowerSupply/GetCompatible`,
      body
    );
  }

  add(body: PowerSupplyAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/PowerSupply/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/PowerSupply/Delete`, {
      params: queryParams,
    });
  }
}
