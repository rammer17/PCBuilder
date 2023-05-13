import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuItem } from 'primeng/api';
import { MenuModule } from 'primeng/menu';
import { TieredMenuModule } from 'primeng/tieredmenu';
@Component({
  selector: 'app-account',
  standalone: true,
  imports: [CommonModule, TieredMenuModule],
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
})
export class AccountComponent {
  items: MenuItem[] = [
    {
      label: 'Profile',
      // routerLink: 'profile',
      icon: 'pi pi-user',
    },
    {
      separator: true,
    },
    {
      label: 'Personal Builds',
      // routerLink: 'builds',
      icon: 'pi pi-list',
    },
  ];
}
