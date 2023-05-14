import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuItem } from 'primeng/api';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { Router } from '@angular/router';
@Component({
  selector: 'app-account',
  standalone: true,
  imports: [CommonModule, TieredMenuModule],
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
})
export class AccountComponent {
  private router: Router = inject(Router);

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
  ];

  checkActiveState(givenLink: any) {
    console.log(this.router.url);
    if (this.router.url.indexOf(givenLink) === -1) {
      console.log(false);
      return false;
    } else {
      console.log(true);
      return true;
    }
  }
}
