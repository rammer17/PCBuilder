import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private isSignedIn$ = new BehaviorSubject<boolean>(this.validateToken());

  test() {
    return this.isSignedIn$.asObservable();
  }

  constructor(private jwtHelperService: JwtHelperService) {}

  private validateToken() {
    const token = localStorage.getItem('token');
    if(!token) return false;
    return !this.jwtHelperService.isTokenExpired(token);
  } 

  update() {
    this.isSignedIn$.next(this.validateToken());
  }

}
