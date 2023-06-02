import { Route } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { PcBuilderComponent } from './pc-builder/pc-builder.component';

export const APP_ROUTES: Route[] = [
  { path: '', component: PcBuilderComponent },
  {
    path: 'signin',
    loadComponent: () =>
      import('./auth/signin/signin.component').then((c) => c.SignInComponent),
    canActivate: [AuthGuard],
  },
  {
    path: 'signup',
    loadComponent: () =>
      import('./auth/signup/signup.component').then((c) => c.SignUpComponent),
    canActivate: [AuthGuard],
  },
  { path: 'builder', component: PcBuilderComponent },
  {
    path: 'community',
    loadComponent: () =>
      import('./pc-community-builds/pc-community-builds.component').then(
        (c) => c.PcCommunityBuildsComponent
      ),
  },
  {
    path: 'account',
    loadChildren: () =>
      import('./account/account.routes').then((r) => r.ACCOUNT_ROUTES),
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('./admin/admin.routes').then((r) => r.ADMIN_ROUTES),
  },
  { path: '**', redirectTo: 'builder', pathMatch: 'full' },
];
