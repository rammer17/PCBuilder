import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserSignInRequest, UserSignUpRequest } from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly url = 'http://localhost:5001';

  constructor(private http: HttpClient) {}

  signIn(body: UserSignInRequest): Observable<any> {
    return this.http.post(`${this.url}/User/SignIn`, body, {
      responseType: 'text',
    });
  }

  signUp(body: UserSignUpRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/User/SignUp`, body);
  }

  delete(id: number): Observable<void> {
    const queryParams = new HttpParams().set('id', id);
    return this.http.delete<void>(`${this.url}/User/Delete`, {
      params: queryParams,
    });
  }
}
