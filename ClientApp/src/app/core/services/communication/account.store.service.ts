import { Injectable, inject } from '@angular/core';
import { BehaviorSubject, Observable, take } from 'rxjs';
import { Account, UserGetInfoResponse } from '../../models/user.model';
import { UserService } from '../user.service';

import * as _ from 'lodash';

@Injectable({
  providedIn: 'root',
})
export class AccountStoreService {
  //* Injecting dependencies
  private userService: UserService = inject(UserService);

  private accountData$: BehaviorSubject<Account | null>;

  firstTimeLoading: boolean = true;

  constructor() {
    this.accountData$ = new BehaviorSubject<Account | null>(null);
  }

  get accountInfo(): Observable<Account | null> {
    return this.accountData$.asObservable();
  }

  update(newData: Account | null): void {
    if (newData !== null) {
      console.log({ ...this.accountData$.value, ...{ fullName: 'gergi' } });
      this.accountData$.next({ ...this.accountData$.value, ...newData });
    }
    this.accountData$.next(newData);
  }

  onLoad(): void {
    if (this.firstTimeLoading) {
      this.userService
        .getInfo()
        .pipe(take(1))
        .subscribe({
          next: (resp: UserGetInfoResponse) => {
            this.update(resp);
          },
        });
      this.firstTimeLoading = false;
    }
  }
}
