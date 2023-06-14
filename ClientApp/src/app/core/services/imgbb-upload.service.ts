import { HttpClient, HttpEvent } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class ImgbbUploadService {
  //* Injecting Dependencies
  private http: HttpClient = inject(HttpClient);

  private readonly API_KEY = '36b1b5b35f2b526eb066d406a7cce172';

  upload(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('image', file);

    return this.http
      .post<HttpEvent<any>>('/upload', formData, {
        params: { key: this.API_KEY },
        reportProgress: true,
        observe: 'events',
      })
  }
}
