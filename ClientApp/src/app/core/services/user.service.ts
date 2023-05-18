import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import {
  UserChangeAvatarRequest,
  UserChangeDescriptionRequest,
  UserChangePasswordRequest,
  UserGetInfoResponse,
  UserSignInRequest,
  UserSignUpRequest,
} from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  //* Injecting dependencies
  private http: HttpClient = inject(HttpClient);

  private readonly url = 'http://localhost:5001';

  getInfo(): Observable<UserGetInfoResponse> {
    return this.http.get<UserGetInfoResponse>(`${this.url}/User/GetInfo`);
  }

  signIn(body: UserSignInRequest): Observable<any> {
    return this.http.post(`${this.url}/User/SignIn`, body, {
      responseType: 'text',
    });
  }

  signUp(body: UserSignUpRequest): Observable<void> {
    return this.http.post<void>(`${this.url}/User/SignUp`, body);
  }

  changePassword(body: UserChangePasswordRequest): Observable<void> {
    return this.http.put<void>(`${this.url}/User/ChangePassword`, body);
  }

  changeAvatar(body: UserChangeAvatarRequest): Observable<void> {
    return this.http.put<void>(`${this.url}/User/ChangeAvatar`, body);
  }

  changeDescription(body: UserChangeDescriptionRequest): Observable<void> {
    return this.http.put<void>(`${this.url}/User/ChangeDescription`, body);
  }

  delete(): Observable<void> {
    return this.http.delete<void>(`${this.url}/User/Delete`);
  }
}
