import { Injectable, inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { AccountStoreService } from '../core/services/communication/account.store.service';

@Injectable({
  providedIn: 'root',
})
export class AdminGuard {
  //* Injecting dependencies
  private accountStoreService: AccountStoreService =
    inject(AccountStoreService);

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    return this.accountStoreService.isAdmin();
  }
}
