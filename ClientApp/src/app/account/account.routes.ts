import { Route } from '@angular/router';
import { AccountInfoComponent } from './account-info/account-info.component';
import { AccountBuildsComponent } from './account-builds/account-builds.component';
import { AccountComponent } from './account.component';

export const ACCOUNT_ROUTES: Route[] = [
  {
    path: '',
    component: AccountComponent,
    children: [
      { path: '', redirectTo: 'info', pathMatch: 'full' },
      { path: 'info', component: AccountInfoComponent },
      { path: 'builds', component: AccountBuildsComponent },
      { path: '**', redirectTo: 'info', pathMatch: 'full' },
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
