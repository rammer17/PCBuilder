import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuItem } from 'primeng/api';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { AccountStoreService } from '../core/services/communication/account.store.service';
import { Observable } from 'rxjs';
import { Account } from '../core/models/user.model';
@Component({
  selector: 'app-account',
  standalone: true,
  imports: [CommonModule, TieredMenuModule],
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
})
export class AccountComponent {
  //* Injecting dependencies
  private accountStoreService: AccountStoreService =
    inject(AccountStoreService);

  accountInfo$?: Observable<Account | null>;

  ngOnInit(): void {
    this.accountInfo$ = this.accountStoreService.accountInfo;
    this.accountStoreService.onLoad();
  }

  items: MenuItem[] = [
    {
      label: 'Profile',
      routerLink: 'info',
      icon: 'pi pi-user',
    },
    {
      separator: true,
    },
    {
      label: 'Personal Builds',
      routerLink: 'builds',
      icon: 'pi pi-list',
    },
    {
      separator: true,
    },
    {
      label: 'Admin Panel',
      routerLink: '',
      icon: 'pi pi-user-plus',
      items: [
        {
          label: 'Users',
          routerLink: '/admin/users',
          icon: 'pi pi-users',
        },
        {
          separator: true,
        },
        {
          label: 'Components',
          routerLink: '/components',
          icon: 'pi pi-list',
        },
      ],
    },
  ];
}
