import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, RouterModule, MenubarModule],
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent {
  menuItems: MenuItem[] = [
    {
      label: 'PC Components',
      icon: 'pi pi-fw pi-cog',
      items: [
        {
          label: 'New',
          icon: 'pi pi-plus',
          items: [
            {
              label: 'CPU',
            },
            {
              label: 'CPU Cooler',
            },
            {
              label: 'Motherboard',
            },
            {
              label: 'Memory',
            },
            {
              label: 'Storage',
            },
            {
              label: 'GPU',
            },
            {
              label: 'Case',
            },
            {
              label: 'PSU',
            },
          ],
        },
        {
          separator: true,
        },
        {
          label: 'Search',
          icon: 'pi pi-search',
        },
      ],
    },
  ];
}
