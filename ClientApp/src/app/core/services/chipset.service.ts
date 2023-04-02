import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChipsetAddRequest, ChipsetGetResponse } from '../models/chipset.model';

@Injectable({
  providedIn: 'root',
})
export class ChipsetService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<ChipsetGetResponse[]> {
    return this.http.get<ChipsetGetResponse[]>(`${this.url}/Chipset/GetAll`);
  }

  add(body: ChipsetAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/Chipset/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/Chipset/Delete`, {
      params: queryParams,
    });
  }
}
