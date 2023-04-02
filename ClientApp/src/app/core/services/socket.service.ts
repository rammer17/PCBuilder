import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SocketAddRequest, SocketGetResponse } from '../models/socket.model';

@Injectable({
  providedIn: 'root',
})
export class SocketService {
  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  getAll(): Observable<SocketGetResponse[]> {
    return this.http.get<SocketGetResponse[]>(`${this.url}/Socket/GetAll`);
  }
  add(body: SocketAddRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/Socket/Add`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/Socket/Delete`, {
      params: queryParams,
    });
  }
}
