import { Route } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { AdminGuard } from './admin.guard';
import { AdminPcPartsComponent } from './admin-pc-parts/admin-pc-parts.component';

export const ADMIN_ROUTES: Route[] = [
  {
    path: '',
    component: AdminComponent,
    canActivate: [AdminGuard],
    children: [
      { path: '', redirectTo: 'users', pathMatch: 'full' },
      { path: 'users', component: AdminUsersComponent },
      { path: 'components', component: AdminPcPartsComponent },
      { path: '**', redirectTo: '', pathMatch: 'full' },
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
