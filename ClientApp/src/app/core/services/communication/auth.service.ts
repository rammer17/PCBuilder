import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private isLoggedIn: boolean = localStorage.getItem('token') ? true : false;;

  get isSignedIn(): boolean {
    return this.isLoggedIn;
  }

  signedIn(): void {
    this.isLoggedIn = true;
  }
  signedOut(): void {
    this.isLoggedIn = false;
  }
}
