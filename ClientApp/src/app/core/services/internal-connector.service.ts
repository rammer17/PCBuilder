import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  InternalConnectorAddRequest,
  InternalConnectorGetResponse,
} from '../models/internal-connector.model';

@Injectable({
  providedIn: 'root',
})
export class InternalConnectorService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<InternalConnectorGetResponse[]> {
    return this.http.get<InternalConnectorGetResponse[]>(
      `${this.url}/InternalConnector/GetAll`
    );
  }

  add(body: InternalConnectorAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/InternalConnector/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/InternalConnector/Delete`, {
      params: queryParams,
    });
  }
}
